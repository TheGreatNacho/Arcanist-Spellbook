using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arcanist_Spellbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Program Defaults
        public static int VersionNumber = 100;

        public static Logging PublicLog = new Logging("error.log");
        public static SpellBook arcanistSpells = new SpellBook();
        public static SpellBook mySpellBook = new SpellBook();
        public static string LoadedSpellBook;
        private void InitializeWindowComponents()
        {
            // Initialize Global Spells List
            SpellList.LoadSpells();
            InitiateArcanistSpellList();
            ApplyWizardFilters();
            ApplyMyFilters();

            // Initialize Spell Labels
            HideWizardSpellSection();
            HideMySpellSection();

        }
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindowComponents();
        }

        private void InitiateArcanistSpellList()
        {
            arcanistSpells.Clear();

            foreach (Spell spell in SpellList.FullSpellList)
            {
                if (spell.HasClass(Spell.SpelllistEnum.Wizard) || spell.HasClass(Spell.SpelllistEnum.Sorceror))
                {
                    arcanistSpells.Add(spell);
                }
            }
        }

        private void HideWizardSpellSection()
        {
            SpellNameLabel.Visibility = Visibility.Hidden;
            SpellCastingGrid.Visibility = Visibility.Hidden;
            SpellEffectGrid.Visibility = Visibility.Hidden;
            SpellDescriptionGrid.Visibility = Visibility.Hidden;
            SpellToolBar.Visibility = Visibility.Hidden;
        }

        private void HideMySpellSection()
        {
            SpellNameLabel1.Visibility = Visibility.Hidden;
            SpellCastingGrid1.Visibility = Visibility.Hidden;
            SpellEffectGrid1.Visibility = Visibility.Hidden;
            SpellDescriptionGrid1.Visibility = Visibility.Hidden;
            SpellToolBar1.Visibility = Visibility.Hidden;
        }

        private void ShowWizardSpellSection(Spell spell)

        {
            if (spell == null) return;

            int CasterLevel = int.Parse((ClassLevelNumberBox.Text != "") ? ClassLevelNumberBox.Text : "0");
            // Set the Visibility
            SpellNameLabel.Visibility = Visibility.Visible;
            SpellCastingGrid.Visibility = Visibility.Visible;
            SpellEffectGrid.Visibility = Visibility.Visible;
            SpellDescriptionGrid.Visibility = Visibility.Visible;
            SpellToolBar.Visibility = Visibility.Visible;

            // Set the values
            SpellNameLabel.Content = spell.Name;
            SchoolLabel.Content = spell.GetSchoolString();
            SpellLevel cl = spell.GetCastingLevel(Spell.SpelllistEnum.Wizard);
            ClassLabel.Content = $"{cl.Class} {cl.Level}";
            CastingTimeLabel.Content = spell.CastingTime;
            ComponentLabel.Content = spell.Components;

            // Range Stuff
            RangeLabel.Content = spell.GetRangeString(GetClassLevel());

            EffectLabel.Content = spell.Effect;
            DurationLabel.Content = spell.Duration;
            SavingThowLabel.Content = spell.Save;
            SRLabel.Content = spell.SpellResistance;
            TargetLabel.Content = spell.Target;
            SpellShortDescriptionBlock.Text = $"{spell.ShortDescription}";
            SpellDescriptionBlock.Text = $"{spell.Description}";


            ScrollCostLabel.Content = $"{spell.GetScrollPrice(CasterLevel)}/{spell.GetScrollPrice(CasterLevel) *2}gp";
            CastingCostLabel.Content = spell.GetCastingPrice(CasterLevel) + "gp";

        }
        private void ShowMySpellSection(Spell spell)

        {
            if (spell == null) return;

            int CasterLevel = int.Parse((ClassLevelNumberBox.Text != "") ? ClassLevelNumberBox.Text : "0");
            // Set the Visibility
            SpellNameLabel1.Visibility = Visibility.Visible;
            SpellCastingGrid1.Visibility = Visibility.Visible;
            SpellEffectGrid1.Visibility = Visibility.Visible;
            SpellDescriptionGrid1.Visibility = Visibility.Visible;
            SpellToolBar1.Visibility = Visibility.Visible;

            // Set the values
            SpellNameLabel1.Content = spell.Name;
            SchoolLabel1.Content = spell.GetSchoolString();
            SpellLevel cl = spell.GetCastingLevel(Spell.SpelllistEnum.Wizard);
            ClassLabel1.Content = $"{cl.Class} {cl.Level}";
            CastingTimeLabel1.Content = spell.CastingTime;
            ComponentLabel1.Content = spell.Components;
            // Range Stuff
            RangeLabel1.Content = spell.GetRangeString(GetClassLevel());

            EffectLabel1.Content = spell.Effect;
            DurationLabel1.Content = spell.Duration;
            SavingThowLabel1.Content = spell.Save;
            SRLabel1.Content = spell.SpellResistance;
            TargetLabel1.Content = spell.Target;
            SpellShortDescriptionBlock1.Text = $"{spell.ShortDescription}";
            SpellDescriptionBlock1.Text = $"{spell.Description}";


            ScrollCostLabel1.Content = $"{spell.GetScrollPrice(CasterLevel)}/{spell.GetScrollPrice(CasterLevel) * 2}gp";
            CastingCostLabel1.Content = spell.GetCastingPrice(CasterLevel) + "gp";

        }
        

        private void FullSpellListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Spell spell = FullSpellListBox.SelectedItem as Spell;
            ShowWizardSpellSection(spell);
            
        }
        public void ApplyWizardFilters()
        {
            // Apply Arcanist Filter
            FullSpellListBox.Items.Clear();
            FullSpellListBox.SelectedIndex = -1;
            HideWizardSpellSection();


            // Apply Sorting Algorythm
            switch (FilterBox.SelectedIndex)
            {
                case 0: // Name
                    arcanistSpells.Spells.Sort(Spell.CompareByName);
                    break;
                case 1: // School
                    arcanistSpells.Spells.Sort(Spell.CompareBySchool);
                    break;
                case 2: // Level
                    arcanistSpells.Spells.Sort(Spell.CompareByWizardLevel);
                    break;
            }

            // Apply Text Fitler
            foreach (Spell spell in arcanistSpells.Spells)
            {
                if (spell.Name.ToLower().Contains(FilterTextBox.Text.ToLower()))
                {
                    FullSpellListBox.Items.Add(spell);
                }
            }

        }
        private void ApplyMyFilters()
        {
            // Apply Arcanist Filter
            MySpellListBox.Items.Clear();
            MySpellListBox.SelectedIndex = -1;
            HideMySpellSection();


            // Apply Sorting Algorythm
            switch (MyFilterComboBox.SelectedIndex)
            {
                case 0: // Name
                    arcanistSpells.Spells.Sort(Spell.CompareByName);
                    break;
                case 1: // School
                    arcanistSpells.Spells.Sort(Spell.CompareBySchool);
                    break;
                case 2: // Level
                    arcanistSpells.Spells.Sort(Spell.CompareByWizardLevel);
                    break;
            }

            // Apply Text Fitler
            foreach (Spell spell in mySpellBook.Spells)
            {
                if (spell.Name.ToLower().Contains(MyFilterTextBox.Text.ToLower()))
                {
                    MySpellListBox.Items.Add(spell);
                }
            }

        }
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyWizardFilters();
        }
        
        // Class Level Allowed Text
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void NumberTextBoxHandler(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        // Use the DataObject.Pasting Handler
        private void ClassLevelNumberBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void ClassLevelNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FullSpellListBox.SelectedIndex > -1)
            {
                Spell spell = FullSpellListBox.SelectedItem as Spell;
                ShowWizardSpellSection(spell);
            }
            
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyWizardFilters();
        }

        private void MySpellListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Spell spell = MySpellListBox.SelectedItem as Spell;
            ShowMySpellSection(spell);
        }

        private void Add2SpellbookBtn_Click(object sender, RoutedEventArgs e)
        {
            mySpellBook.Add(FullSpellListBox.SelectedItem as Spell);
            ApplyMyFilters();
        }

        private void Save(string location)
        {
            try
            {
                // Open a new StreamWriter
                Stream stream = File.Open(location, FileMode.OpenOrCreate);
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    // Save Header Information
                    bw.Write("NSB" + MainWindow.VersionNumber);

                    // Write Caster Level box
                    bw.Write(byte.Parse(ClassLevelNumberBox.Text));

                    // Write Ability Mod box
                    bw.Write(byte.Parse(AbilityModNumberBox.Text));

                    // Save each spell in spell list
                    foreach (Spell spell in mySpellBook.Spells)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 0th spells
                    foreach (Spell spell in _0thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 1st spell slots
                    bw.Write(int.Parse(_1stUsed.Text));
                    bw.Write(int.Parse(_1stTotal.Text));

                    // Write 1st spells
                    foreach (Spell spell in _1stListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 2nd spell slots
                    bw.Write(int.Parse(_2ndUsed.Text));
                    bw.Write(int.Parse(_2ndTotal.Text));

                    // Write 2nd spells
                    foreach (Spell spell in _2ndListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 3rd spell slots
                    bw.Write(int.Parse(_3rdUsed.Text));
                    bw.Write(int.Parse(_3rdTotal.Text));

                    // Write 3rd spells
                    foreach (Spell spell in _3rdListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 4th spell slots
                    bw.Write(int.Parse(_4thUsed.Text));
                    bw.Write(int.Parse(_4thTotal.Text));

                    // Write 4th spells
                    foreach (Spell spell in _4thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 5th spell slots
                    bw.Write(int.Parse(_5thUsed.Text));
                    bw.Write(int.Parse(_5thTotal.Text));

                    // Write 5th spells
                    foreach (Spell spell in _5thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 6th spell slots
                    bw.Write(int.Parse(_6thUsed.Text));
                    bw.Write(int.Parse(_6thTotal.Text));

                    // Write 6th spells
                    foreach (Spell spell in _6thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 7th spell slots
                    bw.Write(int.Parse(_7thUsed.Text));
                    bw.Write(int.Parse(_7thTotal.Text));

                    // Write 7th spells
                    foreach (Spell spell in _7thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 8th spell slots
                    bw.Write(int.Parse(_8thUsed.Text));
                    bw.Write(int.Parse(_8thTotal.Text));

                    // Write 8th spells
                    foreach (Spell spell in _8thListBox.Items)
                    {
                        bw.Write(true);
                        // Save Spell name
                        bw.Write(spell.Name);
                        // Write true so the load can loop
                    }
                    // Write false to end the loop
                    bw.Write(false);

                    // Write 9th spell slots
                    bw.Write(int.Parse(_9thUsed.Text));
                    bw.Write(int.Parse(_9thTotal.Text));

                    // Write 9th spells
                    foreach (Spell spell in _9thListBox.Items)
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
            catch (Exception ex)
            {
                MainWindow.PublicLog.Log(ex);
            }
        }

        // https://stackoverflow.com/questions/10315188/open-file-dialog-and-select-a-file-using-wpf-controls-and-c-sharp
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedSpellBook != null)
            {
                Save(LoadedSpellBook);
                return;
            }
            // Create SaveFileDialog
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog
            {
                // Set filter for file extension and default file extensions
                DefaultExt = ".sb",
                Filter = "Spellbooks (*.sb)|*.sb",
                Title = "Save Spellbook"
            };

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dialog.ShowDialog();
            
            // Get the selected file name and do save stuff
            if (result == true)
            {
                Save(dialog.FileName);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                // Set filter for file extension and default file extensions
                DefaultExt = ".sb",
                Filter = "Spellbooks (*.sb)|*.sb",
                Title = "Load Spellbook"
            };

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dialog.ShowDialog();

            // Get the selected file name and do save stuff
            if (result == true)
            {
                try
                {
                    // Open a new StreamReader
                    Stream stream = File.Open(dialog.FileName, FileMode.Open);
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        // Read the Format Header
                        string FormatHeader = br.ReadString();
                        if (FormatHeader != "NSB" + MainWindow.VersionNumber)
                        {
                            throw new FileFormatException("File format is not Nacho Spell Book " + MainWindow.VersionNumber);
                        }
                        // Read the Class Level
                        ClassLevelNumberBox.Text = br.ReadByte().ToString();

                        // Read the Ability Modifier
                        AbilityModNumberBox.Text = br.ReadByte().ToString();

                        // Read the Spell Book
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                mySpellBook.Add(spell);
                        }

                        // Read 0th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _0thLabel, _0thListBox);
                        }

                        // Read 1st Spell Slots
                        _1stUsed.Text = br.ReadInt32().ToString();
                        _1stTotal.Text = br.ReadInt32().ToString();

                        // Read 1st Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _1stLabel, _1stListBox);
                        }

                        // Read 2nd Spell Slots
                        _2ndUsed.Text = br.ReadInt32().ToString();
                        _2ndTotal.Text = br.ReadInt32().ToString();

                        // Read 2nd Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _2ndLabel, _2ndListBox);
                        }

                        // Read 3rd Spell Slots
                        _3rdUsed.Text = br.ReadInt32().ToString();
                        _3rdTotal.Text = br.ReadInt32().ToString();

                        // Read 3rd Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _3rdLabel, _3rdListBox);
                        }

                        // Read 4th Spell Slots
                        _4thUsed.Text = br.ReadInt32().ToString();
                        _4thTotal.Text = br.ReadInt32().ToString();

                        // Read 4th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _4thLabel, _4thListBox);
                        }

                        // Read 5th Spell Slots
                        _5thUsed.Text = br.ReadInt32().ToString();
                        _5thTotal.Text = br.ReadInt32().ToString();

                        // Read 5th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _5thLabel, _5thListBox);
                        }

                        // Read 6th Spell Slots
                        _6thUsed.Text = br.ReadInt32().ToString();
                        _6thTotal.Text = br.ReadInt32().ToString();

                        // Read 6th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _6thLabel, _6thListBox);
                        }

                        // Read 7th Spell Slots
                        _7thUsed.Text = br.ReadInt32().ToString();
                        _7thTotal.Text = br.ReadInt32().ToString();

                        // Read 7th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _7thLabel, _7thListBox);
                        }

                        // Read 8th Spell Slots
                        _8thUsed.Text = br.ReadInt32().ToString();
                        _8thTotal.Text = br.ReadInt32().ToString();

                        // Read 8th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _8thLabel, _8thListBox);
                        }

                        // Read 9th Spell Slots
                        _9thUsed.Text = br.ReadInt32().ToString();
                        _9thTotal.Text = br.ReadInt32().ToString();

                        // Read 9th Level Spells
                        while (br.ReadBoolean())
                        {
                            string SpellName = br.ReadString();
                            Spell spell = SpellList.GetFromName(SpellName);
                            if (spell != null)
                                PrepareSpell(spell, _9thLabel, _9thListBox);
                        }


                    }

                    LoadedSpellBook = dialog.FileName;
                    this.Title = $"ArcList [{LoadedSpellBook}]";
                }
                catch (Exception ex)
                {
                    MainWindow.PublicLog.Log(ex);
                }
                ApplyMyFilters();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewSpellForm nsf = new NewSpellForm();
            nsf.Show();
        }

        private void PrepareSpell(Spell spell, Label headerLabel, ListBox listbox)
        {
            listbox.Items.Add(spell);
            byte WizardLevel = spell.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
            string header;
            switch (WizardLevel)
            {
                default:
                    header = "";
                    break;
                case 0:
                    header = "0th";
                    break;

                case 1:
                    header = "1st";
                    break;

                case 2:
                    header = "2nd";
                    break;

                case 3:
                    header = "3rd";
                    break;

                case 4:
                    header = "4th";
                    break;

                case 5:
                    header = "5th";
                    break;

                case 6:
                    header = "6th";
                    break;

                case 7:
                    header = "7th";
                    break;

                case 8:
                    header = "8th";
                    break;

                case 9:
                    header = "9th";
                    break;
            }
            headerLabel.Content = $"[{listbox.Items.Count}] {header}:";

        }

        private void PrepareSpellBtn_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)MySpellListBox.SelectedItem;
            byte WizardLevel = spell.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
            switch (WizardLevel)
            {
                case 0:
                    PrepareSpell(spell, _0thLabel, _0thListBox);
                    break;

                case 1:
                    PrepareSpell(spell, _1stLabel, _1stListBox);
                    break;

                case 2:
                    PrepareSpell(spell, _2ndLabel, _2ndListBox);
                    break;

                case 3:
                    PrepareSpell(spell, _3rdLabel, _3rdListBox);
                    break;

                case 4:
                    PrepareSpell(spell, _4thLabel, _4thListBox);
                    break;

                case 5:
                    PrepareSpell(spell, _5thLabel, _5thListBox);
                    break;

                case 6:
                    PrepareSpell(spell, _6thLabel, _6thListBox);
                    break;

                case 7:
                    PrepareSpell(spell, _7thLabel, _7thListBox);
                    break;

                case 8:
                    PrepareSpell(spell, _8thLabel, _8thListBox);
                    break;

                case 9:
                    PrepareSpell(spell, _9thLabel, _9thListBox);
                    break;
            }
        }

        private void PrepareSpellDoubleClk(object sender, MouseButtonEventArgs e)
        {
            Spell spell = (Spell)MySpellListBox.SelectedItem;
            byte WizardLevel = spell.GetCastingLevel(Spell.SpelllistEnum.Wizard).Level;
            switch (WizardLevel)
            {
                case 0:
                    PrepareSpell(spell, _0thLabel, _0thListBox);
                    break;

                case 1:
                    PrepareSpell(spell, _1stLabel, _1stListBox);
                    break;

                case 2:
                    PrepareSpell(spell, _2ndLabel, _2ndListBox);
                    break;

                case 3:
                    PrepareSpell(spell, _3rdLabel, _3rdListBox);
                    break;

                case 4:
                    PrepareSpell(spell, _4thLabel, _4thListBox);
                    break;

                case 5:
                    PrepareSpell(spell, _5thLabel, _5thListBox);
                    break;

                case 6:
                    PrepareSpell(spell, _6thLabel, _6thListBox);
                    break;

                case 7:
                    PrepareSpell(spell, _7thLabel, _7thListBox);
                    break;

                case 8:
                    PrepareSpell(spell, _8thLabel, _8thListBox);
                    break;

                case 9:
                    PrepareSpell(spell, _9thLabel, _9thListBox);
                    break;
            }
        }

        private void _0thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_0thListBox.SelectedItem;
            _0thListBox.Items.Remove(spell);
        }

        private void _1stUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_1stListBox.SelectedItem;
            _1stListBox.Items.Remove(spell);
        }

        private void _2ndUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_2ndListBox.SelectedItem;
            _2ndListBox.Items.Remove(spell);
        }

        private void _3rdUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_3rdListBox.SelectedItem;
            _3rdListBox.Items.Remove(spell);
        }

        private void _4thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_4thListBox.SelectedItem;
            _4thListBox.Items.Remove(spell);
        }

        private void _5thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_5thListBox.SelectedItem;
            _5thListBox.Items.Remove(spell);
        }

        private void _6thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_6thListBox.SelectedItem;
            _6thListBox.Items.Remove(spell);
        }

        private void _7thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_7thListBox.SelectedItem;
            _7thListBox.Items.Remove(spell);
        }

        private void _8thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_8thListBox.SelectedItem;
            _8thListBox.Items.Remove(spell);
        }

        private void _9thUnprepare_Click(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)_9thListBox.SelectedItem;
            _9thListBox.Items.Remove(spell);
        }

        private int GetClassLevel()
        {
            return int.Parse(ClassLevelNumberBox.Text);
        }

        private int GetAbilityMod()
        {
            return int.Parse(AbilityModNumberBox.Text);
        }

        private void CastPreparedSpell(object sender, MouseButtonEventArgs e)
        {
            ListBox lb = (ListBox) e.Source;
            Spell spell = (Spell) lb.SelectedItem;
            MsgBox msg = new MsgBox(spell.Name, spell.GetRoll20Query(GetClassLevel(), GetAbilityMod()));
            msg.Show();            
        }

        private void CastSpellBtn_Clk(object sender, RoutedEventArgs e)
        {
            Spell spell = (Spell)MySpellListBox.SelectedItem;
            MsgBox msg = new MsgBox(spell.Name, spell.GetRoll20Query(GetClassLevel(), GetAbilityMod()));
            msg.Show();
        }
    }
}
