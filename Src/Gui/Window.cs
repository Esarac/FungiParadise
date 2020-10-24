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

            //Test
            DataTable table = new DataTable();

            table.Columns.Add("TYPE", typeof(string));//Class
            table.Columns.Add("COLOR", typeof(char));//1
            table.Columns.Add("SIZE", typeof(char));//2
            table.Columns.Add("ODOR", typeof(char));//3

            //1
            DataRow row1 = table.NewRow();
            row1["TYPE"] = "Good";//0
            row1["COLOR"] = 'r';//1
            row1["SIZE"] = 's';//2
            row1["ODOR"] = 'g';//3
            table.Rows.Add(row1);

            //2
            DataRow row2 = table.NewRow();
            row2["TYPE"] = "Good";//0
            row2["COLOR"] = 'b';//1
            row2["SIZE"] = 's';//2
            row2["ODOR"] = 'b';//3
            table.Rows.Add(row2);

            //3
            DataRow row3 = table.NewRow();
            row3["TYPE"] = "Bad";//0
            row3["COLOR"] = 'y';//1
            row3["SIZE"] = 'b';//2
            row3["ODOR"] = 'b';//3
            table.Rows.Add(row3);

            //4
            DataRow row6 = table.NewRow();
            row6["TYPE"] = "Good";//0
            row6["COLOR"] = 'y';//1
            row6["SIZE"] = 'b';//2
            row6["ODOR"] = 'g';//3
            table.Rows.Add(row6);

            //5
            DataRow row4 = table.NewRow();
            row4["TYPE"] = "Bad";//0
            row4["COLOR"] = 'r';//1
            row4["SIZE"] = 'b';//2
            row4["ODOR"] = 'g';//3
            table.Rows.Add(row4);

            //6
            DataRow row5 = table.NewRow();
            row5["TYPE"] = "Good";//0
            row5["COLOR"] = 'b';//1
            row5["SIZE"] = 'b';//2
            row5["ODOR"] = 'g';//3
            table.Rows.Add(row5);

            Tree tree = new Tree(table);
            Console.WriteLine(tree.ToString());
            //...
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
