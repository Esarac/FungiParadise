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
using DecisionTree.Model;

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

        private void InitializeAttributeComboBox()
        {
            attributeComboBox.Items.Add("All");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                attributeComboBox.Items.Add(table.Columns[i].HeaderText);
            }

            attributeComboBox.SelectedIndex = 0;
        }

        //Methods
        private void GenerateTable()
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

        private void AttributeComboBoxSelectedIndexChanged(object sender, EventArgs e)
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

                //Cap shape
                case 2:

                    valueComboBox.DataSource = Mushroom.CAP_SHAPE;
                    valueComboBox.Enabled = true;
                    break;

                //Cap surface
                case 3:

                    valueComboBox.DataSource = Mushroom.CAP_SURFACE;
                    valueComboBox.Enabled = true;
                    break;

                //Cap color
                case 4:

                    valueComboBox.DataSource = Mushroom.CAP_COLOR;
                    valueComboBox.Enabled = true;
                    break;

                //Bruises
                case 5:

                    valueComboBox.DataSource = Mushroom.BRUISES;
                    valueComboBox.Enabled = true;
                    break;

                //Odor
                case 6:

                    valueComboBox.DataSource = Mushroom.ODOR;
                    valueComboBox.Enabled = true;
                    break;

                //Gill attachment
                case 7:

                    valueComboBox.DataSource = Mushroom.GILL_ATTACHMENT;
                    valueComboBox.Enabled = true;
                    break;

                //Gill spacing
                case 8:

                    valueComboBox.DataSource = Mushroom.GILL_SPACING;
                    valueComboBox.Enabled = true;
                    break;

                //Gill size
                case 9:

                    valueComboBox.DataSource = Mushroom.GILL_SIZE;
                    valueComboBox.Enabled = true;
                    break;


                //Gill color
                case 10:

                    valueComboBox.DataSource = Mushroom.GILL_COLOR;
                    valueComboBox.Enabled = true;
                    break;


                //Stalk shape
                case 11:

                    valueComboBox.DataSource = Mushroom.STALK_SHAPE;
                    valueComboBox.Enabled = true;
                    break;

                //Stalk root
                case 12:

                    valueComboBox.DataSource = Mushroom.STALK_ROOT;
                    valueComboBox.Enabled = true;
                    break;

                //Stalk surface above ring
                case 13:

                    valueComboBox.DataSource = Mushroom.STALK_SURFACE_ABOVE_RING;
                    valueComboBox.Enabled = true;
                    break;

                //Stalk suprface below ring
                case 14:

                    valueComboBox.DataSource = Mushroom.STALK_SURFACE_BELOW_RING;
                    valueComboBox.Enabled = true;
                    break;

                //Stalk color above ring
                case 15:

                    valueComboBox.DataSource = Mushroom.STALK_COLOR_ABOVE_RING;
                    valueComboBox.Enabled = true;
                    break;

                //Stalk color below ring
                case 16:

                    valueComboBox.DataSource = Mushroom.STALK_COLOR_BELOW_RING;
                    valueComboBox.Enabled = true;
                    break;

                //Veil Type
                case 17:

                    valueComboBox.DataSource = Mushroom.VEIL_TYPE;
                    valueComboBox.Enabled = true;
                    break;

                //Veil color
                case 18:

                    valueComboBox.DataSource = Mushroom.VEIL_COLOR;
                    valueComboBox.Enabled = true;
                    break;

                //Ring number
                case 19:

                    valueComboBox.DataSource = Mushroom.RING_NUMBER;
                    valueComboBox.Enabled = true;
                    break;


                //Ring type
                case 20:

                    valueComboBox.DataSource = Mushroom.RING_TYPE;
                    valueComboBox.Enabled = true;
                    break;


                //Spore print color
                case 21:

                    valueComboBox.DataSource = Mushroom.SPORE_PRINT_COLOR;
                    valueComboBox.Enabled = true;
                    break;

                //Population
                case 22:

                    valueComboBox.DataSource = Mushroom.POPULATION;
                    valueComboBox.Enabled = true;
                    break;

                //Habitat
                case 23:

                    valueComboBox.DataSource = Mushroom.HABITAT;
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

        private void FilterButton_Click(object sender, EventArgs e)
        {
            int index = attributeComboBox.SelectedIndex;
            if (index == 0)
                table.DataSource = manager.GenerateDataTable();
            else
                table.DataSource = manager.GenerateFilteredDataTable(attributeComboBox.Items[attributeComboBox.SelectedIndex].ToString(), valueComboBox.Items[valueComboBox.SelectedIndex].ToString());
        }
    }
}
