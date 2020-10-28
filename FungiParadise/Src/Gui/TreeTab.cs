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

namespace FungiParadise.Src.Gui
{
    public partial class TreeTab : UserControl
    {
        public TreeTab()
        {
            InitializeComponent();
        }

        //Attributes
        private TreeNode<CircleNode> root = new TreeNode<CircleNode>(new CircleNode("Root"));

        private void load(object sender, EventArgs e)
        {
            TreeNode<CircleNode> aNode = new TreeNode<CircleNode>(new CircleNode("RO2"));
            TreeNode<CircleNode> bNode = new TreeNode<CircleNode>(new CircleNode("Cr"));
            TreeNode<CircleNode> cNode = new TreeNode<CircleNode>(new CircleNode("Cfg3"));
            TreeNode<CircleNode> dNode = new TreeNode<CircleNode>(new CircleNode("F34"));
            TreeNode<CircleNode> eNode = new TreeNode<CircleNode>(new CircleNode("cv"));
            TreeNode<CircleNode> fNode = new TreeNode<CircleNode>(new CircleNode("G"));
            TreeNode<CircleNode> gNode = new TreeNode<CircleNode>(new CircleNode("Ft"));
            TreeNode<CircleNode> hNode = new TreeNode<CircleNode>(new CircleNode("45g"));
            TreeNode<CircleNode> iNode = new TreeNode<CircleNode>(new CircleNode("Edible"));
            TreeNode<CircleNode> jNode = new TreeNode<CircleNode>(new CircleNode("Edible"));
            TreeNode<CircleNode> kNode = new TreeNode<CircleNode>(new CircleNode("Poison"));


            root.AddChild(aNode);
            root.AddChild(bNode);
            aNode.AddChild(cNode);
            aNode.AddChild(dNode);
            bNode.AddChild(eNode);
            bNode.AddChild(fNode);
            bNode.AddChild(gNode);
            eNode.AddChild(hNode);
            hNode.AddChild(iNode);
            cNode.AddChild(jNode);
            cNode.AddChild(kNode);

            ArrangeTree();
            verticalOrientation();
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

        private void addNode(string text, TreeNode<CircleNode> father)
        {
            TreeNode<CircleNode> child = new TreeNode<CircleNode>(new CircleNode(text));
            father.AddChild(child);
            ArrangeTree();
        }

        private void verticalOrientation()
        {
            root.SetTreeDrawingParameters(5, 2, 20, 5, TreeNode<CircleNode>.Orientations.Vertical);
            ArrangeTree();
        }
    }
}
