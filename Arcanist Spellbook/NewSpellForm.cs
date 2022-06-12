using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Arcanist_Spellbook
{
    public partial class NewSpellForm : Form
    {
        public NewSpellForm()
        {
            InitializeComponent();
        }

        private void NewSpellForm_Load(object sender, EventArgs e)
        {
            // Populate School Combobox
            foreach (Spell.SchoolEnum School in Enum.GetValues(typeof(Spell.SchoolEnum)))
            {
                SchoolComboBox.Items.Add(School);
            }
            SchoolComboBox.SelectedIndex = 0;

            // Populate Subschool Combobox
            foreach (Spell.SubSchoolEnum SubSchool in Enum.GetValues(typeof(Spell.SubSchoolEnum)))
            {
                SubSchoolComboBox.Items.Add(SubSchool);
            }
            SubSchoolComboBox.SelectedIndex = 0;

            // Populate Class Combobox
            foreach (Spell.SpelllistEnum SpellList in Enum.GetValues(typeof(Spell.SpelllistEnum)))
            {
                ClassComboBox.Items.Add(SpellList);
            }
            ClassComboBox.SelectedIndex = 0;

            // Populate Descriptor Combobox
            foreach (Spell.DescriptorEnum Descriptor in Enum.GetValues(typeof(Spell.DescriptorEnum)))
            {
                DescriptorComboBox.Items.Add(Descriptor);
            }
            DescriptorComboBox.SelectedIndex = 0;

        }

        private void AddClassBtn_Click(object sender, EventArgs e)
        {
            SpellLevel cl = new SpellLevel((Spell.SpelllistEnum) ClassComboBox.SelectedItem, (byte) LevelNumberBox.Value);
            LevelsListBox.Items.Add(cl);
        }

        private void AddDescriptorBtn_Click(object sender, EventArgs e)
        {
            Spell.DescriptorEnum Descriptor = (Spell.DescriptorEnum) DescriptorComboBox.SelectedItem;
            DescriptorListBox.Items.Add(Descriptor);
        }

        private void CreateSpellBtn_Clk(object sender, EventArgs e)
        {
            // Insert into Schools
            string SubSchool = SubSchoolComboBox.SelectedItem.ToString();
            if (SubSchool == "None")
                SubSchool = "";

            using (var connection = new SqliteConnection("Data Source=spells.db;"))
            {
                try
                {
                    connection.Open();
                    Spell spell;

                    using (SqliteCommand cmd = new SqliteCommand("INSERT INTO spells (spellname, casting_time, components, range, target, effect, duration, saving_throw, spell_resistance,description, short_description,resource)" +
                        " VALUES (@NAME,@CASTINGTIME,@COMPONENTS,@RANGE,@TARGET,@EFFECT,@DURATION,@SAVE,@SR,@DESCRIPTION,@SHORTDESCRIPTION,\"Custom Spell\")", connection))
                    {
                        cmd.Parameters.AddWithValue("@NAME", SpellNameBox.Text);
                        cmd.Parameters.AddWithValue("@CASTINGTIME", CastingTimeTextBox.Text);
                        cmd.Parameters.AddWithValue("@COMPONENTS", ComponentsTextBox.Text);
                        cmd.Parameters.AddWithValue("@RANGE", RangeTextBox.Text);
                        cmd.Parameters.AddWithValue("@TARGET", TargetTextBox.Text);
                        cmd.Parameters.AddWithValue("@EFFECT", EffectTextBox.Text);
                        cmd.Parameters.AddWithValue("@DURATION", DurationTextBox.Text);
                        cmd.Parameters.AddWithValue("@SAVE", SavingThrowTextBox.Text);
                        cmd.Parameters.AddWithValue("@SR", SpellResistanceTextBox.Text);
                        cmd.Parameters.AddWithValue("@DESCRIPTION", DescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@SHORTDESCRIPTION", ShortDescriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@SCHOOL", SchoolComboBox.SelectedItem.ToString().ToLower());
                        cmd.Parameters.AddWithValue("@SUBSCHOOL", SubSchool.ToLower());
                        cmd.Parameters.AddWithValue("@CLASS", "");
                        cmd.Parameters.AddWithValue("@LEVEL", 0);
                        cmd.Parameters.AddWithValue("@DESCRIPTOR", "");

                        spell = new Spell()
                        {
                            Name = SpellNameBox.Text,
                            CastingTime = CastingTimeTextBox.Text,
                            Components = ComponentsTextBox.Text,
                            Target = TargetTextBox.Text,
                            Effect = EffectTextBox.Text,
                            Duration = DurationTextBox.Text,
                            Save = SavingThrowTextBox.Text,
                            SpellResistance = SpellResistanceTextBox.Text,
                            Description = DescriptionBox.Text,
                            ShortDescription = ShortDescriptionTextBox.Text,
                            School = (Spell.SchoolEnum)SchoolComboBox.SelectedItem,
                            SubSchool = (Spell.SubSchoolEnum)SubSchoolComboBox.SelectedItem,
                            Source = "Custom Spell"
                        };

                        // Add Range to Spell()
                        spell.CalculateSpellRange(RangeTextBox.Text);

                        // Calculate spell value
                        spell.CalculateSpellValue();

                        // Add Spell Query
                        cmd.ExecuteNonQuery();

                        // Add School Query
                        cmd.CommandText = "INSERT INTO schools (spellname, school, subschool) VALUES (@NAME, @SCHOOL, @SUBSCHOOL)";
                        cmd.ExecuteNonQuery();

                        // Add Class Query
                        cmd.CommandText = "INSERT INTO castinglevelbyclass (spellname, class, level) VALUES (@NAME, @CLASS, @LEVEL)";
                        foreach (SpellLevel cl in LevelsListBox.Items)
                        {
                            cmd.Parameters["@CLASS"].Value = cl.Class.ToString().ToLower();
                            cmd.Parameters["@LEVEL"].Value = cl.Level;
                            cmd.ExecuteNonQuery();

                            spell.SpellLevels.Add(cl);
                        }

                        // Add Descriptors Query
                        cmd.CommandText = "INSERT INTO descriptors (spellname, descriptor) VALUES (@NAME, @DESCRIPTOR)";
                        foreach (Spell.DescriptorEnum descriptor in DescriptorListBox.Items)
                        {
                            cmd.Parameters["@DESCRIPTOR"].Value = descriptor.ToString().ToLower();
                            cmd.ExecuteNonQuery();

                            spell.Descriptors.Add(descriptor);
                        }
                    }

                    SpellList.FullSpellList.Add(spell);
                }
                catch (Exception ex)
                {
                    MainWindow.PublicLog.Log(ex);
                }
            }

            // Close the Form
            this.Close();
            this.Dispose();
        }
    }
}
