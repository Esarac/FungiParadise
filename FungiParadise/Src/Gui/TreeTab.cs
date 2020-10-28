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

namespace FungiParadise.Src.Gui
{
    public partial class TreeTab : UserControl
    {
        //Attributes
        private Manager manager;
        private TreeNode<CircleNode> root = new TreeNode<CircleNode>(new CircleNode(""));

        public TreeTab()
        {
            InitializeComponent();
        }

        public void InitializeTreeTab(Manager manager)
        {
            this.manager = manager;
            GenerateDecisionTree();
        }

        private void GenerateDecisionTree()
        {
            //Generate Tree
            manager.GenerateDecisionTree();

            //Root
            this.root = new TreeNode<CircleNode>(new CircleNode(manager.DecisionTree.RootNode.ToString()));

            List<Tuple<string, string>> questionsPerClasses = new List<Tuple<string, string>>();
            //Branches
            for (int i = 0; i < manager.DecisionTree.RootNode.Childrens.Length; i++)
            {
                AddNode(root, manager.DecisionTree.RootNode.Questions[i], manager.DecisionTree.RootNode.Childrens[i]);
                /*if (manager.DecisionTree.RootNode.Childrens[i] is DecisionTree.Model.Decision)
                {
                    AddNode(root, manager.DecisionTree.RootNode.Questions[i], manager.DecisionTree.RootNode.Childrens[i]);
                }
                else
                {
                    DecisionTree.Model.Answer answ = (DecisionTree.Model.Answer)manager.DecisionTree.RootNode.Childrens[i];

                    for (int j = 0; j < questionsPerClasses.Count; j++)
                    {
                        if (questionsPerClasses[i].Item1 == answ.ClassValue)
                        {

                        }
                        
                    }
                }*/
            }

            //Arrnage
            ArrangeTree();
            verticalOrientation();
        }

        private void AddNode(TreeNode<CircleNode> parent, string question, DecisionTree.Model.Node child)
        {
            TreeNode<CircleNode> parentDraw = new TreeNode<CircleNode>(new CircleNode(question + ". " + child.ToString()));
            parent.AddChild(parentDraw);

            if (child is DecisionTree.Model.Decision)
            {
                DecisionTree.Model.Decision dChild = (DecisionTree.Model.Decision)child;
                for (int i = 0; i < dChild.Childrens.Length; i++)
                {
                    AddNode(parentDraw, dChild.Questions[i], dChild.Childrens[i]);
                }
            }
        }

        //Triggers
        private void PicTreePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        private void PictTreeReSize(object sender, EventArgs e)
        {
            ArrangeTree();
        }

        //Methods
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

        private void verticalOrientation()
        {
            //Horizontal
            //root.SetTreeDrawingParameters(15, 80, 20, 5, TreeNode<CircleNode>.Orientations.Horizontal);
            //Vertical
            root.SetTreeDrawingParameters(5, 2, 20, 5, TreeNode<CircleNode>.Orientations.Vertical);
            ArrangeTree();
        }
    }
}
