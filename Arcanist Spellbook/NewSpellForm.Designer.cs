namespace Arcanist_Spellbook
{
    partial class NewSpellForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SpellNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SchoolComboBox = new System.Windows.Forms.ComboBox();
            this.SubSchoolComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LevelsListBox = new System.Windows.Forms.ListBox();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.LevelNumberBox = new System.Windows.Forms.NumericUpDown();
            this.AddClassBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CastingTimeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComponentsTextBox = new System.Windows.Forms.TextBox();
            this.EffectTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RangeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TargetTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.SavingThrowTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SpellResistanceTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CreateSpellBtn = new System.Windows.Forms.Button();
            this.AddDescriptorBtn = new System.Windows.Forms.Button();
            this.DescriptorComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptorListBox = new System.Windows.Forms.ListBox();
            this.ShortDescriptionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spell Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SpellNameBox
            // 
            this.SpellNameBox.Location = new System.Drawing.Point(172, 14);
            this.SpellNameBox.Name = "SpellNameBox";
            this.SpellNameBox.Size = new System.Drawing.Size(224, 20);
            this.SpellNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "School: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SchoolComboBox
            // 
            this.SchoolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchoolComboBox.FormattingEnabled = true;
            this.SchoolComboBox.Location = new System.Drawing.Point(172, 36);
            this.SchoolComboBox.Name = "SchoolComboBox";
            this.SchoolComboBox.Size = new System.Drawing.Size(111, 21);
            this.SchoolComboBox.TabIndex = 3;
            // 
            // SubSchoolComboBox
            // 
            this.SubSchoolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubSchoolComboBox.FormattingEnabled = true;
            this.SubSchoolComboBox.Location = new System.Drawing.Point(289, 36);
            this.SubSchoolComboBox.Name = "SubSchoolComboBox";
            this.SubSchoolComboBox.Size = new System.Drawing.Size(107, 21);
            this.SubSchoolComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Levels:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LevelsListBox
            // 
            this.LevelsListBox.FormattingEnabled = true;
            this.LevelsListBox.Location = new System.Drawing.Point(16, 84);
            this.LevelsListBox.Name = "LevelsListBox";
            this.LevelsListBox.Size = new System.Drawing.Size(184, 95);
            this.LevelsListBox.TabIndex = 6;
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(16, 185);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(133, 21);
            this.ClassComboBox.TabIndex = 7;
            // 
            // LevelNumberBox
            // 
            this.LevelNumberBox.Location = new System.Drawing.Point(155, 186);
            this.LevelNumberBox.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.LevelNumberBox.Name = "LevelNumberBox";
            this.LevelNumberBox.Size = new System.Drawing.Size(45, 20);
            this.LevelNumberBox.TabIndex = 8;
            // 
            // AddClassBtn
            // 
            this.AddClassBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddClassBtn.Location = new System.Drawing.Point(16, 212);
            this.AddClassBtn.Name = "AddClassBtn";
            this.AddClassBtn.Size = new System.Drawing.Size(184, 23);
            this.AddClassBtn.TabIndex = 9;
            this.AddClassBtn.Text = "Add Class";
            this.AddClassBtn.UseVisualStyleBackColor = true;
            this.AddClassBtn.Click += new System.EventHandler(this.AddClassBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(12, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Casting Time:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CastingTimeTextBox
            // 
            this.CastingTimeTextBox.Location = new System.Drawing.Point(172, 247);
            this.CastingTimeTextBox.Name = "CastingTimeTextBox";
            this.CastingTimeTextBox.Size = new System.Drawing.Size(224, 20);
            this.CastingTimeTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(12, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Components:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ComponentsTextBox
            // 
            this.ComponentsTextBox.Location = new System.Drawing.Point(172, 271);
            this.ComponentsTextBox.Name = "ComponentsTextBox";
            this.ComponentsTextBox.Size = new System.Drawing.Size(224, 20);
            this.ComponentsTextBox.TabIndex = 13;
            // 
            // EffectTextBox
            // 
            this.EffectTextBox.Location = new System.Drawing.Point(172, 295);
            this.EffectTextBox.Name = "EffectTextBox";
            this.EffectTextBox.Size = new System.Drawing.Size(224, 20);
            this.EffectTextBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(12, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Effect:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RangeTextBox
            // 
            this.RangeTextBox.Location = new System.Drawing.Point(172, 319);
            this.RangeTextBox.Name = "RangeTextBox";
            this.RangeTextBox.Size = new System.Drawing.Size(224, 20);
            this.RangeTextBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(12, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Range:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TargetTextBox
            // 
            this.TargetTextBox.Location = new System.Drawing.Point(172, 343);
            this.TargetTextBox.Name = "TargetTextBox";
            this.TargetTextBox.Size = new System.Drawing.Size(224, 20);
            this.TargetTextBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(12, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Target:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Location = new System.Drawing.Point(172, 367);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(224, 20);
            this.DurationTextBox.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(12, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 24);
            this.label9.TabIndex = 20;
            this.label9.Text = "Duration:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(12, 492);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(384, 136);
            this.DescriptionBox.TabIndex = 22;
            // 
            // SavingThrowTextBox
            // 
            this.SavingThrowTextBox.Location = new System.Drawing.Point(172, 391);
            this.SavingThrowTextBox.Name = "SavingThrowTextBox";
            this.SavingThrowTextBox.Size = new System.Drawing.Size(224, 20);
            this.SavingThrowTextBox.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(12, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 24);
            this.label10.TabIndex = 23;
            this.label10.Text = "Saving Throw:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SpellResistanceTextBox
            // 
            this.SpellResistanceTextBox.Location = new System.Drawing.Point(172, 415);
            this.SpellResistanceTextBox.Name = "SpellResistanceTextBox";
            this.SpellResistanceTextBox.Size = new System.Drawing.Size(224, 20);
            this.SpellResistanceTextBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(12, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "Spell Resistance:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(151, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 24);
            this.label12.TabIndex = 27;
            this.label12.Text = "Description";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CreateSpellBtn
            // 
            this.CreateSpellBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CreateSpellBtn.Location = new System.Drawing.Point(12, 634);
            this.CreateSpellBtn.Name = "CreateSpellBtn";
            this.CreateSpellBtn.Size = new System.Drawing.Size(384, 23);
            this.CreateSpellBtn.TabIndex = 28;
            this.CreateSpellBtn.Text = "Create Spell";
            this.CreateSpellBtn.UseVisualStyleBackColor = true;
            this.CreateSpellBtn.Click += new System.EventHandler(this.CreateSpellBtn_Clk);
            // 
            // AddDescriptorBtn
            // 
            this.AddDescriptorBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddDescriptorBtn.Location = new System.Drawing.Point(206, 212);
            this.AddDescriptorBtn.Name = "AddDescriptorBtn";
            this.AddDescriptorBtn.Size = new System.Drawing.Size(190, 23);
            this.AddDescriptorBtn.TabIndex = 32;
            this.AddDescriptorBtn.Text = "Add Descriptor";
            this.AddDescriptorBtn.UseVisualStyleBackColor = true;
            this.AddDescriptorBtn.Click += new System.EventHandler(this.AddDescriptorBtn_Click);
            // 
            // DescriptorComboBox
            // 
            this.DescriptorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DescriptorComboBox.FormattingEnabled = true;
            this.DescriptorComboBox.Location = new System.Drawing.Point(206, 185);
            this.DescriptorComboBox.Name = "DescriptorComboBox";
            this.DescriptorComboBox.Size = new System.Drawing.Size(190, 21);
            this.DescriptorComboBox.TabIndex = 30;
            // 
            // DescriptorListBox
            // 
            this.DescriptorListBox.FormattingEnabled = true;
            this.DescriptorListBox.Location = new System.Drawing.Point(206, 84);
            this.DescriptorListBox.Name = "DescriptorListBox";
            this.DescriptorListBox.Size = new System.Drawing.Size(190, 95);
            this.DescriptorListBox.TabIndex = 29;
            // 
            // ShortDescriptionTextBox
            // 
            this.ShortDescriptionTextBox.Location = new System.Drawing.Point(12, 466);
            this.ShortDescriptionTextBox.Name = "ShortDescriptionTextBox";
            this.ShortDescriptionTextBox.Size = new System.Drawing.Size(384, 20);
            this.ShortDescriptionTextBox.TabIndex = 33;
            // 
            // NewSpellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(408, 669);
            this.Controls.Add(this.ShortDescriptionTextBox);
            this.Controls.Add(this.AddDescriptorBtn);
            this.Controls.Add(this.DescriptorComboBox);
            this.Controls.Add(this.DescriptorListBox);
            this.Controls.Add(this.CreateSpellBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SpellResistanceTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SavingThrowTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TargetTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RangeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EffectTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComponentsTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CastingTimeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddClassBtn);
            this.Controls.Add(this.LevelNumberBox);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.LevelsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubSchoolComboBox);
            this.Controls.Add(this.SchoolComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpellNameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewSpellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Spell";
            this.Load += new System.EventHandler(this.NewSpellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SpellNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SchoolComboBox;
        private System.Windows.Forms.ComboBox SubSchoolComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LevelsListBox;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.NumericUpDown LevelNumberBox;
        private System.Windows.Forms.Button AddClassBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CastingTimeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ComponentsTextBox;
        private System.Windows.Forms.TextBox EffectTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RangeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TargetTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DurationTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox SavingThrowTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SpellResistanceTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button CreateSpellBtn;
        private System.Windows.Forms.Button AddDescriptorBtn;
        private System.Windows.Forms.ComboBox DescriptorComboBox;
        private System.Windows.Forms.ListBox DescriptorListBox;
        private System.Windows.Forms.TextBox ShortDescriptionTextBox;
    }
}