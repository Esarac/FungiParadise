using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FungiParadise.Gui
{
    public partial class window : MetroFramework.Forms.MetroForm
    {
        public window()
        {
            InitializeComponent();
        }

        //Triggers
        private void OnMouseHoverImportButton(object sender, EventArgs e)
        {
            importButton.BackColor = Color.FromArgb(58, 145, 84);
            importButton.ForeColor = Color.White;
        }

        private void OnMouseLeaveImportButton(object sender, EventArgs e)
        {
            importButton.BackColor = Color.White;
            importButton.ForeColor = Color.Black;
        }
    }
}
