using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;

namespace Arcanist_Spellbook
{
    public static class SpellList
    {
        public static List<Spell> FullSpellList = new List<Spell>();

        public static Spell GetFromName(string name)
        {
            foreach (Spell spell in FullSpellList)
            {
                if (spell.Name == name)
                    return spell;
            }
            return null;
        }

        public static void LoadSpells()
        {
            FullSpellList.Clear();
            using (var connection = new SqliteConnection("Data Source=spells.db;Mode=ReadOnly"))
            {
                try
                {
                    connection.Open();

                    var spellsQuery = connection.CreateCommand();
                    spellsQuery.CommandText = @"SELECT * FROM spells";
                    using (var spellReader = spellsQuery.ExecuteReader())
                    {
                        while (spellReader.Read())
                        {
                            Spell spell = new Spell
                            {
                                Name = spellReader.GetString(0),
                                CastingTime = spellReader.GetString(1),
                                Components = spellReader.GetString(2),
                                Target = spellReader.GetString(4),
                                Effect = spellReader.GetString(5),
                                Duration = spellReader.GetString(6),
                                Save = spellReader.GetString(7),
                                SpellResistance = spellReader.GetString(8),
                                Description = spellReader.GetString(9),
                                ShortDescription = spellReader.GetString(10),
                                Source = spellReader.GetString(11)
                            };

                            // Calculate the spell value
                            spell.CalculateSpellValue();                          
                            

                            // Get the School and Subschool
                            var schoolQuery = connection.CreateCommand();
                            schoolQuery.CommandText = @"SELECT school, subschool FROM schools WHERE spellname = $name";
                            schoolQuery.Parameters.AddWithValue("$name", spell.Name);

                            using (var schoolReader = schoolQuery.ExecuteReader())
                            {
                                schoolReader.Read();
                                string school = schoolReader.GetString(0);
                                string subschool = schoolReader.GetString(1);


                                try
                                {
                                    spell.School = (Spell.SchoolEnum)Enum.Parse(typeof(Spell.SchoolEnum), school, true);
                                    spell.SubSchool = (subschool != "") ? (Spell.SubSchoolEnum)Enum.Parse(typeof(Spell.SubSchoolEnum), subschool, true) : Spell.SubSchoolEnum.None;
                                }
                                catch (Exception e)
                                {
                                    MainWindow.PublicLog.Log(e);
                                }
                            }

                            // Get the Casting Levels
                            var levelQuery = connection.CreateCommand();
                            levelQuery.CommandText = @"SELECT class, level FROM castinglevelbyclass WHERE spellname = $name";
                            levelQuery.Parameters.AddWithValue("$name", spell.Name);

                            using (var levelReader = levelQuery.ExecuteReader())
                            {
                                spell.SpellLevels = new List<SpellLevel>();
                                while (levelReader.Read())
                                {
                                    SpellLevel cl = new SpellLevel((Spell.SpelllistEnum)Enum.Parse(typeof(Spell.SpelllistEnum), levelReader.GetString(0), true), levelReader.GetByte(1));
                                    spell.SpellLevels.Add(cl);
                                }
                            }

                            // Get the spell descriptors
                            var discriptorQuery = connection.CreateCommand();
                            discriptorQuery.CommandText = @"SELECT descriptor FROM descriptors WHERE spellname = $name";
                            discriptorQuery.Parameters.AddWithValue("$name", spell.Name);

                            using (var discriptorReader = discriptorQuery.ExecuteReader())
                            {
                                spell.Descriptors = new List<Spell.DescriptorEnum>();
                                while (discriptorReader.Read())
                                {
                                    spell.Descriptors.Add((Spell.DescriptorEnum)Enum.Parse(typeof(Spell.DescriptorEnum), discriptorReader.GetString(0), true));
                                }
                            }
                            // Get the Range
                            spell.CalculateSpellRange(spellReader.GetString(3).ToLower());
                                

                            SpellList.FullSpellList.Add(spell);
                        }
                    }
                }
                catch (SqliteException e)
                {
                    MainWindow.PublicLog.Log(e);
                }
                /*catch (Exception e)
                {
                    MainWindow.PublicLog.Log(e);
                }*/

            }
        }

    }

    public struct SpellLevel
    {
        public SpellLevel(Spell.SpelllistEnum classname, byte level)
        {
            Class = classname;
            Level = level;
        }

        public Spell.SpelllistEnum Class { get; }
        public byte Level { get; }

        public override string ToString() => $"{Class} {Level}";
    }
    public class Spell
    {
        public string Name;
        public string Description;
        public string ShortDescription;
        public string Components;
        public string CastingTime;
        public string Target;
        public string Save;
        public string Effect;
        public string SpellResistance;
        public string Duration;
        public string Source;
        public int SpellValue;
        public List<SpellLevel> SpellLevels;
        public SchoolEnum School;
        public SubSchoolEnum SubSchool;
        public List<DescriptorEnum> Descriptors;
        public RangeEnum Range;
        public string RangeInc="";

        public bool HasClass(SpelllistEnum cs)
        {
            foreach (SpellLevel cl in this.SpellLevels)
            {
                if (cl.Class == cs)
                {
                    return true;
                }
            }
            return false;
        }

        public void CalculateSpellValue()
        {
            // Remove Verbal and Somantic (V, S) components from the components we want to calculate
            string startingComponents = Regex.Replace(this.Components, @"[VS], ", "");
            // Split the components at ),
            // Eg. M (test item worth 10gp, another item worth 5 gp), F (a focus item)
            // will give us {"M (test item worth 10gp, another item worth 5 gp", "F (a focus item)"}
            string[] components = Regex.Split(startingComponents, @"\), ");
            foreach (string comp in components)
            {
                // Get the Material component (only if it has gp in it)
                if (comp.Trim().StartsWith("M") && comp.Contains("gp"))
                {
                    // Get the first match for x gp
                    Match m = Regex.Match(comp, @"([0-9,]*) gp");
                    // Format the number by removing commas and gp. (5,000 gp => 5000)
                    string SpellCostString = m.Groups[1].Value.Replace(",", "");
                    int SpellCost = 0;
                    try
                    {
                        // If the SpellCostString has a value
                        if (SpellCostString != "")
                            // Parse that value into a string
                            SpellCost = int.Parse(SpellCostString);
                    }
                    catch (FormatException e)
                    {
                        // Something went wrong. Log it.
                        MainWindow.PublicLog.Log(e);
                    }
                    this.SpellValue = SpellCost;
                }
            }
        }

        public void CalculateSpellRange(string rangeString)
        {
            if (rangeString.Contains("touch")) this.Range = Spell.RangeEnum.Touch;
            else if (rangeString.Contains("close")) this.Range = Spell.RangeEnum.Close;
            else if (rangeString.Contains("medium")) this.Range = Spell.RangeEnum.Medium;
            else if (rangeString.Contains("long")) this.Range = Spell.RangeEnum.Long;
            else if (rangeString.Contains("personal")) this.Range = Spell.RangeEnum.Personal;
            else if (rangeString.Contains("unlimited")) this.Range = Spell.RangeEnum.Unlimited;
            else
            {
                this.Range = Spell.RangeEnum.Fixed;
                this.RangeInc = rangeString;
            }
        }

        public string GetSchoolString()
        {
            string SchoolString = this.School + " ";

            if (this.SubSchool != Spell.SubSchoolEnum.None)
            {
                SchoolString += $"[{this.SubSchool}] ";
            }
            if (this.Descriptors.Count > 0)
            {
                SchoolString += "(";
                SchoolString += String.Join(", ", this.Descriptors);
                SchoolString += ") ";
            }
            return SchoolString;
        }

        public string GetRangeString(int CasterLevel)
        {
            string RangeString="";
            switch (this.Range)
            {
                case (Spell.RangeEnum.Touch):
                    RangeString = "Touch";
                    break;
                case (Spell.RangeEnum.Personal):
                    RangeString = "Personal";
                    break;
                case (Spell.RangeEnum.Unlimited):
                    RangeString = "Unlimited";
                    break;
                case (Spell.RangeEnum.Fixed):
                    RangeString = this.RangeInc;
                    break;
                case (Spell.RangeEnum.Close):
                    RangeString = $"Close ({20 + (CasterLevel / 2) * 5} ft.)";
                    break;
                case (Spell.RangeEnum.Medium):
                    RangeString = $"Medium ({100 + CasterLevel * 10} ft.)";
                    break;
                case (Spell.RangeEnum.Long):
                    RangeString = $"Long ({400 + CasterLevel * 20} ft.)";
                    break;
            }
            return RangeString;
        }

        public string GetRoll20Query(int CasterLevel, int AbilityMod)
        {
            string shouldSave = (this.Save.Contains("none")||this.Save=="") ? "" : $"{{{{save=1}}}} {{{{savedc=[[{10+AbilityMod+this.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level}]]}}}} {{{{saveeffect={this.Save}}}}}";
            string shouldResist = (this.SpellResistance.Contains("None")||this.SpellResistance=="") ? "" : $"{{{{sr=1}}}} {{{{spellresistance=Yes}}}}";
            string Query= $"&{{template:pc}}" +
                $"{{{{name={this.Name}}}}}" +
                shouldResist +
                $"{{{{type=spell}}}}" +
                $"{{{{showchar=0}}}}" +
                $"{{{{school={this.GetSchoolString()}}}}}" +
                $"{{{{castingtime={this.CastingTime}}}}}" +
                $"{{{{component={this.Components}}}}}" +
                $"{{{{range={this.GetRangeString(CasterLevel)}}}}}" +
                $"{{{{effect={this.Effect}}}}}" +
                $"{{{{duration={this.Duration}}}}}" +
                shouldSave +
                $"{{{{descflag=[[1]]}}}} {{{{desc={this.Description}}}}}";

            return Query;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Spell);
        }

        public bool Equals(Spell spell)
        {
            if (spell == null) return this == null;
            return (this.Name == spell.Name && this.SpellLevels == spell.SpellLevels);
        }
        public override string ToString()
        {
            return $"[Lvl:{this.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level}] {this.Name}";
        }

        public enum SchoolEnum
        {
            Universal,
            Abjuration,
            Conjuration,
            Divination,
            Enchantment,
            Evocation,
            Illusion,
            Necromancy,
            Transmutation
        }
        public enum SubSchoolEnum
        {
            None,
            Calling,
            Creation,
            Healing,
            Summoning,
            Teleportation,
            Scrying,
            Charm,
            Compulsion,
            Figment,
            Glamer,
            Pattern,
            Phantasm,
            Shadow,
            Polymorph,
            Light
        }
        public enum DescriptorEnum
        {
            None,
            Acid,
            Air,
            Chaotic,
            Cold,
            Curse,
            Darkness,
            Death,
            Disease,
            Draconic,
            Earth,
            Electricity,
            Emotion,
            Evil,
            Fear,
            Fire,
            Force,
            Good,
            Language_Dependent,
            Lawful,
            Light,
            Meditative,
            Mind_Affecting,
            Pain,
            Poison,
            Ruse,
            Shadow,
            Sonic,
            Water
        }
        public enum RangeEnum
        {
            None,
            Touch,
            Close,
            Medium,
            Long,
            Unlimited,
            Personal,
            Fixed
        }

        public enum SpelllistEnum
        {
            Adept,
            Alchemist,
            Antipaladin,
            Bard,
            Cleric,
            Druid,
            Inquisitor,
            Magus,
            Oracle,
            Paladin,
            Ranger,
            Sorceror,
            Summoner,
            Witch,
            Wizard
        }

        public static int CompareByName(Spell x, Spell y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return String.Compare(x.Name, y.Name);
                }
            }
        }

        public static int CompareBySchool(Spell x, Spell y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    int xEnum = (int) x.School;
                    int yEnum = (int) y.School;
                    if (xEnum > yEnum) return 1;
                    else if (xEnum < yEnum) return -1;
                    else return CompareByName(x, y);
                }
            }
        }

        public static int CompareByWizardLevel(Spell x, Spell y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    byte xWizLevel = x.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
                    byte yWizLevel = y.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
                    if (xWizLevel > yWizLevel) return 1;
                    else if (xWizLevel < yWizLevel) return -1;
                    else return CompareBySchool(x, y);
                }
            }
        }
        public SpellLevel GetCastingLevel(Spell.SpelllistEnum sl)
        {
            foreach (SpellLevel cl in this.SpellLevels)
            {
                if (cl.Class == sl)
                {
                    return cl;
                }
            }

            return new SpellLevel();
        }

        public float GetScrollPrice(float CasterLevel)
        {
            float SpellLevel = this.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
            if (SpellLevel == 0) SpellLevel = 0.5f;
            return (SpellLevel * CasterLevel * 25)+this.SpellValue;
        }

        public float GetCastingPrice(float CasterLevel)
        {
            float SpellLevel = this.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
            if (SpellLevel == 0) SpellLevel = 0.5f;
            return (SpellLevel * CasterLevel * 10)+this.SpellValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class SpellBook
    {
        public List<Spell> Spells;
        public Spell.SpelllistEnum Class {
            get => this.Class;
            set => this.Class = value;
        }

        public SpellBook()
        {
            this.Spells = new List<Spell>();
        }

        public SpellBook Clone()
        {
            SpellBook newsb = new SpellBook();
            foreach (Spell spell in this.Spells)
            {
                newsb.Add(spell);
            }
            return newsb;
        }

        public void Add(Spell spell)
        {
            this.Spells.Add(spell);
        }
        public bool Remove(Spell spell)
        {
            return this.Spells.Remove(spell);
        }

        public void RemoveAt(int index)
        {
            this.Spells.RemoveAt(index);
        }

        public int IndexOf(Spell spell)
        {
            return this.Spells.IndexOf(spell);
        }

        public void Insert(int index, Spell spell)
        {
            this.Spells.Insert(index, spell);
        }

        public void Clear()
        {
            this.Spells.Clear();
        }

        public bool Contains(Spell spell)
        {
            return this.Spells.Contains(spell);
        }

        public void CopyTo(Spell[] spells, int arrayIndex)
        {
            this.Spells.CopyTo(spells, arrayIndex);
        }
        public void CopyTo(Spell[] spells)
        {
            this.Spells.CopyTo(spells);
        }

        public int Count
        {
            get => this.Spells.Count;
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public Spell this[int index]
        {
            get => this.Spells[index];
        }

        public void SaveSpellbook(string location)
        {
            try
            {
                // Open a new StreamWriter
                Stream stream = File.Open(location, FileMode.OpenOrCreate);
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    // Save Header Information
                    bw.Write("NSB" + MainWindow.VersionNumber);
                    
                    // Save each spell in spell list
                    foreach (Spell spell in this.Spells)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);
                }
            }
            catch (Exception e)
            {
                MainWindow.PublicLog.Log(e);
            }
                
        }

        public void LoadSpellbook(string location)
        {
            try
            {
                // Open a new StreamReader
                Stream stream = File.Open(location, FileMode.Open);
                using (BinaryReader br = new BinaryReader(stream))
                {
                    string FormatHeader = br.ReadString();
                    if (FormatHeader != "NSB" + MainWindow.VersionNumber)
                    {
                        throw new FileFormatException("File format is not Nacho Spell Book " + MainWindow.VersionNumber);
                    }
                    while (br.ReadBoolean())
                    {
                        string SpellName = br.ReadString();
                        Spell spell = SpellList.GetFromName(SpellName);
                        if (spell != null)
                            this.Add(spell);
                    }
                }
            }
            catch (Exception e)
            {
                MainWindow.PublicLog.Log(e);
            }
        }
    }
}