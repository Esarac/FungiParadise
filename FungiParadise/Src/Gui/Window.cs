using DecisionTree.Model;
using FungiParadise.Model;
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
    public partial class Window : MetroFramework.Forms.MetroForm
    {
        public Window()
        {
            InitializeComponent();
            infoTab.GenerateInfo();
        }

        //Attributes
        private Manager manager;

        //Triggers
        private void ImportButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();

            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                this.manager = new Manager(fileChooser.FileName);
                //Init
                tableTab.InitializeTableTab(manager);
                chartTab.InitializeChartTab(manager);
                treeTab.InitializeTreeTab(manager);
                classifyTab.InitializeClassifyTab(manager);
            }
        }

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
