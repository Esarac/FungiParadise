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
            
            TreeNode<CircleNode> a_node = new TreeNode<CircleNode>(new CircleNode("RO2"));
            TreeNode<CircleNode> b_node = new TreeNode<CircleNode>(new CircleNode("Cr"));
            TreeNode<CircleNode> c_node = new TreeNode<CircleNode>(new CircleNode("Cfg3"));
            TreeNode<CircleNode> d_node = new TreeNode<CircleNode>(new CircleNode("F34"));
            TreeNode<CircleNode> e_node = new TreeNode<CircleNode>(new CircleNode("cv"));
            TreeNode<CircleNode> f_node = new TreeNode<CircleNode>(new CircleNode("G"));
            TreeNode<CircleNode> g_node = new TreeNode<CircleNode>(new CircleNode("ht"));
            TreeNode<CircleNode> h_node = new TreeNode<CircleNode>(new CircleNode("45g"));

            root.AddChild(a_node);
            root.AddChild(b_node);
            a_node.AddChild(c_node);
            a_node.AddChild(d_node);
            b_node.AddChild(e_node);
            b_node.AddChild(f_node);
            b_node.AddChild(g_node);
            e_node.AddChild(h_node);

            // Position the tree.
            ArrangeTree();
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
                float xmin = root.indent;
                float ymin = xmin;
                root.Arrange(gr, xmin, ref ymin);
            }

            picTree.Refresh();
        }

        private void addNode(string text, TreeNode<CircleNode> father)
        {
            TreeNode<CircleNode> child = new TreeNode<CircleNode>(new CircleNode(text));
            father.AddChild(child);
            ArrangeTree();
        }
    }
}
