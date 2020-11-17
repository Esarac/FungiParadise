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
using System.Text.RegularExpressions;

namespace FungiParadise.Gui
{
    public partial class TreeTab : UserControl
    {
        //Attributes
        private Manager manager;
        private TreeNode<CircleNode> root;

        //Aux
        private Dictionary<string, List<string>> children;

        //Constructor
        public TreeTab()
        {
            InitializeComponent();
        }

        //Initializers
        public void InitializeOrientationComboBox()
        {
            orientationComboBox.Items.AddRange(new string[] { "Vertical", "Horizontal" });
            orientationComboBox.SelectedIndex = 0;
            orientationComboBox.Enabled = true;
        }

        public void InitializeTypeComboBox()
        {
            typeComboBox.Items.AddRange(new string[] { "Accord .NET Framework", "Fungi Paradise" });
            typeComboBox.SelectedIndex = 0;
            typeComboBox.Enabled = true;
        }

        //Method
        public void InitializeTreeTab(Manager manager)
        {
            this.manager = manager;
            GenerateDecisionTreeLib();
            GenerateDecisionTreeOrg();
            InitializeOrientationComboBox();
            InitializeTypeComboBox();
            AccuracyPercentageTreeLib();
        }

        private void GenerateDecisionTreeOrg()
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

            //AccuracyPercentage
            AccuracyPercentageTreeOrg();

            //Arrange
            VerticalOrientation();
        }

        private void GenerateDecisionTreeLib()
        {
            //Generate Tree
            manager.GenerateDecisionTreeLib();

            string[] lines = manager.GetDesicionTreeLib().Split('\n');

            string root = new Regex(@"\(([^)]*)\)").Match(lines[0]).ToString();
            root = string.Concat(Regex.Matches(root, "[A-Z]").OfType<Match>().Select(match => match.Value));

            //Root
            this.root = new TreeNode<CircleNode>(new CircleNode(root));

            //Height of the tree
            int height = manager.GetDesicionTreeLibHeight();

            //Maps children
            MapChildren(lines, height);

            foreach (string child in children[root])
            {
                AddNodeLib(this.root, child);
            }

            //AccuracyPercentage
            AccuracyPercentageTreeLib();

            //Arrange
            VerticalOrientation();
        }

        public void MapChildren(string[] lines, int height)
        {
            children = new Dictionary<string, List<string>>();

            for (int level = 0; level < height; level++)
            {
                List<string> childrenOfThisNode = new List<string>();

                for (int i = 0; i < (lines.Length - 1); i++)
                {
                    string[] nodes = GetNodes(lines[i]);

                    if (level < nodes.Length)
                    {
                        if(!childrenOfThisNode.Contains(nodes[level]))
                        childrenOfThisNode.Add(nodes[level]);
                    }
                }

                string parent = GetParent(lines, level, height);
                children.Add(parent, childrenOfThisNode);
            }
        }

        public string GetParent(string[] lines, int level, int height)
        {
            string branch = null;

            bool found = false;

            for (int i = 0; i < (lines.Length -1) && !found; i++)
            {
                if(GetNodes(lines[i]).Length == height)
                {
                    branch = lines[i];
                    found = true;
                }
            }

            MatchCollection matches = new Regex(@"\(([^)]*)\)").Matches(branch);

            string root = matches[level].ToString();
            root = string.Concat(Regex.Matches(root, "[A-Z]").OfType<Match>().Select(match => match.Value));
            return root;
        }

        public bool isLeaf(string node)
        {
            string parent = string.Concat(Regex.Matches(node, "[A-Z]").OfType<Match>().Select(match => match.Value));
            
            return !children.ContainsKey(parent);
        }

        public string[] GetNodes(string line)
        {
            MatchCollection matches = new Regex(@"\(([^)]*)\)").Matches(line);

            string answer, variable, attribute;

            string[] nodes = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                if(i + 1 == matches.Count)
                {
                    string[] parts = line.Split('=');
                    answer = new Regex(@"\s|[().]").Replace(parts[0], "");
                    variable = new Regex("[a-z]").Match(matches[i].ToString()).ToString();
                    nodes[i] = variable + ". " + answer;
                }
                else
                {
                    variable = new Regex("[a-z]").Match(matches[i].ToString()).ToString();
                    attribute = string.Concat(Regex.Matches(matches[i+1].ToString(), "[A-Z]").OfType<Match>().Select(match => match.Value));
                    nodes[i] = variable + ". " + attribute; 
                }
            }
            return nodes;
        }

        public void AddNodeLib(TreeNode<CircleNode> parent, string child)
        {
            TreeNode<CircleNode> parentDraw = new TreeNode<CircleNode>(new CircleNode(child));
            parent.AddChild(parentDraw);

            if (!isLeaf(child))
            {
                string parentName = string.Concat(Regex.Matches(child, "[A-Z]").OfType<Match>().Select(match => match.Value));

                foreach (string childChild in children[parentName])
                {
                    AddNodeLib(parentDraw, childChild);
                }
            }

        }

        private void AccuracyPercentageTreeOrg()
        {
            accuracyLabel.Text = "Accuracy Percentage: " + (manager.DecisionTreeAccuracyPercentageOrg() * 100) + "%";
        }

        private void AccuracyPercentageTreeLib()
        {
            accuracyLabel.Text = "Accuracy Percentage: " + (manager.DecisionTreeAccuracyPercentageLib() * 100) + "%"; 
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

            if (typeComboBox.SelectedIndex == 0)
            {
                picTree.Size = new Size(500, 815);
            }
            else
            {
                picTree.Size = new Size(500, 900);
            }        
        }

        private void HorizontalOrientation()
        {
            root.SetTreeDrawingParameters(5, 80, 20, 5, TreeNode<CircleNode>.Orientations.Horizontal);
            ArrangeTree();
            if (typeComboBox.SelectedIndex == 0)
            {
                picTree.Size = new Size(1750, 700);
            }
            else
            {
                picTree.Size = new Size(2070, 600);
            }
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
        public void GenerateDecisionTree(object sender, EventArgs e)
        {
            if (typeComboBox.SelectedIndex == 0)
                GenerateDecisionTreeLib();
            else
                GenerateDecisionTreeOrg();

            orientationComboBox.SelectedIndex = 0;
        }

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
