using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanist_Spellbook
{
    public partial class MsgBox : Form
    {
        public MsgBox(string message)
        {
            InitializeComponent();
            MsgTextBox.Text = message;

            Clipboard.SetText(message, TextDataFormat.Text);
        }

        public MsgBox(string title, string message)
        {
            InitializeComponent();
            MsgTextBox.Text = message;
            this.Text = title;

            Clipboard.SetText(message, TextDataFormat.Text);
        }
    }
}
