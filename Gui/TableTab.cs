using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FungiParadise.Model;

namespace FungiParadise.Gui
{
    public partial class TableTab : UserControl
    {
        //Attributes
        private Manager manager;

        public TableTab()
        {
            InitializeComponent();
        }

        //Initializers
        public void InitializeTableTab(Manager manager)
        {
            this.manager = manager;
            GenerateTable();
            InitializeAttributeComboBox();
            attributeComboBox.Enabled = true;
            filterButton.Enabled = true;
        }

        public void InitializeAttributeComboBox()
        {
            attributeComboBox.Items.Add("All");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                attributeComboBox.Items.Add(table.Columns[i].HeaderText);
            }

            attributeComboBox.SelectedIndex = 0;
        }

        //Methods
        public void GenerateTable()
        {
            //Config
            table.DataSource = manager.GenerateDataTable();
            table.EnableHeadersVisualStyles = false;
            table.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            //...
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void attributeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = attributeComboBox.SelectedIndex;

            switch (index)
            {
                //All
                case 0:

                    valueComboBox.DataSource = null;
                    valueComboBox.Enabled = false;
                    break;

                //Type
                case 1:

                    valueComboBox.DataSource = Enum.GetValues(typeof(Mushroom.MushroomType));
                    valueComboBox.Enabled = true;
                    break;

                //Cap Shape
                case 2:

                    valueComboBox.DataSource = Mushroom.CAP_SHAPE;
                    valueComboBox.Enabled = true;
                    break;
            }
        }

        //Triggers
        private void OnMouseHoverFilterButton(object sender, EventArgs e)
        {
            filterButton.BackColor = Color.FromArgb(58, 145, 84);
            filterButton.ForeColor = Color.White;
        }

        private void OnMouseLeaveFilterButton(object sender, EventArgs e)
        {
            filterButton.BackColor = Color.White;
            filterButton.ForeColor = Color.Black;
        }
    }
}
