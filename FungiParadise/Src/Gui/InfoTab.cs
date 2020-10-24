using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FungiParadise.Gui
{
    public partial class InfoTab : UserControl
    {
        //Constants
        public const string INFO_PATH = "../../Data/info.html";

        public InfoTab()
        {
            InitializeComponent();
        }

        public void GenerateInfo()
        {
            string[] lines = File.ReadAllLines(INFO_PATH);

            info.Text = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                info.Text += "\n" + lines[i];
            }
        }

    }
}
