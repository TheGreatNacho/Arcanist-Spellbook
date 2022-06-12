namespace Arcanist_Spellbook
{
    partial class MsgBox
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
            this.MsgTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MsgTextBox
            // 
            this.MsgTextBox.Location = new System.Drawing.Point(12, 12);
            this.MsgTextBox.Multiline = true;
            this.MsgTextBox.Name = "MsgTextBox";
            this.MsgTextBox.ReadOnly = true;
            this.MsgTextBox.Size = new System.Drawing.Size(337, 169);
            this.MsgTextBox.TabIndex = 0;
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 193);
            this.Controls.Add(this.MsgTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MsgBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MsgTextBox;
    }
}