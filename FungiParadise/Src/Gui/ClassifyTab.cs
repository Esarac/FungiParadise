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
    public partial class ClassifyTab : UserControl
    {
        //Attributes
        private Manager manager;

        //Aux
        private DataTable table;
        private List<string> attributes;
        private List<char> values;
        private int attributeIndex;

        public ClassifyTab()
        {
            InitializeComponent();
        }

        //Initializers 
        public void InitializeClassifyTab(Manager manager)
        {
            this.manager = manager;
            InitializeAttributeList();
            InitializeValueComboBox();
            InitializeAttributeLabel();
            InitializeButtons();
        }

        public void InitializeAttributeList()
        {
            table = manager.GenerateEmptyTable();
            attributes = new List<string>();

            foreach (DataColumn column in table.Columns)
            {
                attributes.Add(column.ColumnName);
            }

            attributes.RemoveAt(0);
        }

        public void InitializeValueComboBox()
        {
            valueComboBox.DataSource = Mushroom.CAP_SHAPE;
            valueComboBox.Visible = true;
            values = new List<char>();
        }
        
        public void InitializeAttributeLabel()
        {
            attributeLabel.Text = attributes[0];
            attributeIndex = 0;
        }

        public void InitializeButtons()
        {
            nextButton.Visible = true;
            backButton.Visible = true;
        }

        //Triggers
        public void OnActionNextButton(object sender, EventArgs e)
        {
            values.Add((char)valueComboBox.SelectedValue);
            if (attributeIndex == 0)
                backButton.Enabled = true;

            attributeIndex++;

            if (attributeIndex < (table.Columns.Count - 1))
            {
                attributeLabel.Text = attributes[attributeIndex];
                ChangeValueComboBox();
            }
            else
            {
                nextButton.Text = "Classify";
                nextButton.Click -= new EventHandler(OnActionNextButton);
                nextButton.Click += new EventHandler(Classify);

                backButton.Text = "Reset";
                backButton.Click -= new EventHandler(OnActionBackButton);
                backButton.Click += new EventHandler(Reset);
            }
        }

        public void OnActionBackButton(object sender, EventArgs e)
        {
            attributeIndex--;

            if (attributeIndex == 0)
                backButton.Enabled = false;
            values.RemoveAt(values.Count - 1);
            attributeLabel.Text = attributes[attributeIndex];
            ChangeValueComboBox();
        }

        public void Classify(object sender, EventArgs e)
        {
            DataRow row = table.NewRow();

            for (int i = 0; i < values.Count; i++)
            {
                row[attributes[i]] = values[i];
            }

            table.Rows.Add(row);
            string classification = manager.DecisionTree.Classify(table)[0];

            MessageClassify message = new MessageClassify();
            message.InitializeClassifyMessage(attributes, values, classification, this);
            message.Show();
        }

        public void Reset(object sender, EventArgs e)
        {
            InitializeAttributeList();
            InitializeValueComboBox();
            InitializeAttributeLabel();

            nextButton.Text = "Next";
            nextButton.Click -= new EventHandler(Classify);
            nextButton.Click += new EventHandler(OnActionNextButton);

            backButton.Text = "Back";
            backButton.Click -= new EventHandler(Reset);
            backButton.Click += new EventHandler(OnActionBackButton);
            backButton.Enabled = false;
        }

        public void OnMouseEnter(object sender, EventArgs e)
        {
            MouseEnterColor((Button)sender);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            MouseLeavesColor((Button)sender);
        }

        //Methods
        public void ChangeValueComboBox()
        {
            switch (attributeIndex)
            {
                //Cap shape
                case 0:

                    valueComboBox.DataSource = Mushroom.CAP_SHAPE;
                    break;

                //Cap surface
                case 1:

                    valueComboBox.DataSource = Mushroom.CAP_SURFACE;
                    break;

                //Cap color
                case 2:

                    valueComboBox.DataSource = Mushroom.CAP_COLOR;
                    break;

                //Bruises
                case 3:

                    valueComboBox.DataSource = Mushroom.BRUISES;
                    break;

                //Odor
                case 4:

                    valueComboBox.DataSource = Mushroom.ODOR;
                    break;

                //Gill attachment
                case 5:

                    valueComboBox.DataSource = Mushroom.GILL_ATTACHMENT;
                    break;

                //Gill spacing
                case 6:

                    valueComboBox.DataSource = Mushroom.GILL_SPACING;
                    break;

                //Gill size
                case 7:

                    valueComboBox.DataSource = Mushroom.GILL_SIZE;
                    break;


                //Gill color
                case 8:

                    valueComboBox.DataSource = Mushroom.GILL_COLOR;
                    break;


                //Stalk shape
                case 9:

                    valueComboBox.DataSource = Mushroom.STALK_SHAPE;
                    break;

                //Stalk root
                case 10:

                    valueComboBox.DataSource = Mushroom.STALK_ROOT;
                    break;

                //Stalk surface above ring
                case 11:

                    valueComboBox.DataSource = Mushroom.STALK_SURFACE_ABOVE_RING;
                    break;

                //Stalk suprface below ring
                case 12:

                    valueComboBox.DataSource = Mushroom.STALK_SURFACE_BELOW_RING;
                    break;

                //Stalk color above ring
                case 13:

                    valueComboBox.DataSource = Mushroom.STALK_COLOR_ABOVE_RING;
                    break;

                //Stalk color below ring
                case 14:

                    valueComboBox.DataSource = Mushroom.STALK_COLOR_BELOW_RING;
                    break;

                //Veil Type
                case 15:

                    valueComboBox.DataSource = Mushroom.VEIL_TYPE;
                    break;

                //Veil color
                case 16:

                    valueComboBox.DataSource = Mushroom.VEIL_COLOR;
                    break;

                //Ring number
                case 17:

                    valueComboBox.DataSource = Mushroom.RING_NUMBER;
                    break;


                //Ring type
                case 18:

                    valueComboBox.DataSource = Mushroom.RING_TYPE;
                    break;


                //Spore print color
                case 19:

                    valueComboBox.DataSource = Mushroom.SPORE_PRINT_COLOR;
                    break;

                //Population
                case 20:

                    valueComboBox.DataSource = Mushroom.POPULATION;
                    break;

                //Habitad
                case 21:

                    valueComboBox.DataSource = Mushroom.HABITAT;
                    break;
            }
        }

        public void MouseEnterColor<T>(T button) where T : Button
        {
            button.BackColor = Color.FromArgb(58, 145, 84);
            button.ForeColor = Color.White;
        }

        public void MouseLeavesColor<T>(T button) where T : Button
        {
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
        }
    }
}
