using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeView.Model;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel.Design.Serialization;
using FungiParadise.Model;

namespace FungiParadise.Gui
{
    public partial class TreeTab : UserControl
    {
        //Attributes
        private Manager manager;
        private TreeNode<CircleNode> root;

        //Constructor
        public TreeTab()
        {
            InitializeComponent();
        }

        //Initializers
        public void InitializeOrientationComboBox()
        {
            orientationComboBox.Items.Add("Vertical");
            orientationComboBox.Items.Add("Horizontal");
            orientationComboBox.SelectedIndex = 0;
            orientationComboBox.Enabled = true;
        }

        public void InitializeLabel()
        {
            successLabel.Text = "Success Percentage: " + (manager.DecisionTreeSuccessPercentageOrg() * 100) + "%";
        }

        //Method
        public void InitializeTreeTab(Manager manager)
        {
            this.manager = manager;
            GenerateDecisionTree();
            InitializeOrientationComboBox();
            InitializeLabel();
        }

        private void GenerateDecisionTree()
        {
            //Generate Tree
            manager.GenerateDecisionTreeOrg();

            //Root
            this.root = new TreeNode<CircleNode>(new CircleNode(manager.DecisionTreeOrg.RootNode.ToString()));

            //Branches
            for (int i = 0; i < manager.DecisionTreeOrg.RootNode.Children.Length; i++)
            {
                AddNode(root, manager.DecisionTreeOrg.RootNode.Questions[i], manager.DecisionTreeOrg.RootNode.Children[i]);
            }

            //Arrange
            VerticalOrientation();
        }

        private void AddNode(TreeNode<CircleNode> parent, string question, DecisionTree.Model.Node child)
        {
            TreeNode<CircleNode> parentDraw = new TreeNode<CircleNode>(new CircleNode(question + ". " + child.ToString()));
            parent.AddChild(parentDraw);

            if (child is DecisionTree.Model.Decision)
            {
                DecisionTree.Model.Decision dChild = (DecisionTree.Model.Decision)child;
                for (int i = 0; i < dChild.Children.Length; i++)
                {
                    AddNode(parentDraw, dChild.Questions[i], dChild.Children[i]);
                }
            }
        }

        private void VerticalOrientation()
        {
            root.SetTreeDrawingParameters(20, 2, 20, 8, TreeNode<CircleNode>.Orientations.Vertical);
            ArrangeTree();
            picTree.Size = new Size(500, 900);
        }

        private void HorizontalOrientation()
        {
            root.SetTreeDrawingParameters(5, 80, 20, 5, TreeNode<CircleNode>.Orientations.Horizontal);
            ArrangeTree();
            picTree.Size = new Size(2080, 600);
        }

        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                if (root.orientation == TreeNode<CircleNode>.Orientations.Horizontal)
                {
                    float xmin = 0, ymin = 0;
                    root.Arrange(gr, ref xmin, ref ymin);

                    xmin = (picTree.ClientSize.Width - xmin) / 2;
                    ymin = 10;
                    root.Arrange(gr, ref xmin, ref ymin);
                }
                else
                {
                    float xmin = root.indent;
                    float ymin = xmin;
                    root.Arrange(gr, ref xmin, ref ymin);
                }
            }

            picTree.Refresh();
        }

        //Trigger
        private void PicTreePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            if (root != null)
                root.DrawTree(e.Graphics);
        }

        private void PicTreeReSize(object sender, EventArgs e)
        {
            if (root != null)
                ArrangeTree();
        }

        public void OrientationComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = orientationComboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    VerticalOrientation();
                    break;

                case 1:
                    HorizontalOrientation();
                    break;
            }
        }
    }
}
