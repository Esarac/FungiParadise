using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreeView.Src.Model
{
    class TreeNode<T> where T : IDrawable
    {
        //Attributes
        public T data;
        public List<TreeNode<T>> children;

        //Drawing properties
        public Font font;
        public Pen pen;
        public Brush frontBrush;
        public Brush bgBrush;

        //Spacing properties
        public float hOffSet;
        public float vOffSet;
        public float indent;
        public float spotRadius;

        //Node properties
        private PointF dataCenter;
        private PointF spotCenter;

        //Constructor
        public TreeNode(T data, Font font)
        {
            //Attributes
            this.data = data;
            children = new List<TreeNode<T>>();

            //Drawing properties
            this.font = font;
            pen = Pens.Black;
            frontBrush = Brushes.Black;
            bgBrush = Brushes.White;

            //Spacing properties
            hOffSet = 5;
            vOffSet = 10;
            indent = 20;
            spotRadius = 5;
        }

        //Methods
        public void AddChild(TreeNode<T> child)
        {
            children.Add(child);
        }

        public void Arrange(Graphics gr, float xmin, float ymin)
        {
            SizeF mySize = data.GetSize(gr, font);
            mySize.Width += 3 * spotRadius;

            spotCenter = new PointF((xmin + spotRadius), (ymin + (mySize.Height - 2 * spotRadius) / 2));
            dataCenter = new PointF((spotCenter.X + spotRadius + mySize.Width / 2), (spotCenter.Y));

            ymin += mySize.Height + vOffSet;

            foreach (TreeNode<T> child in children)
            {
                child.Arrange(gr, (xmin + indent), ymin);
            }
        }

        public void DrawTree(Graphics gr, float x, float y)
        {
            Arrange(gr, x, y);
            DrawTree(gr);
        }

        public void DrawTree(Graphics gr)
        {
            DrawSubtreeLinks(gr);
            DrawSubtreeNodes(gr);
        }

        public void DrawSubtreeLinks(Graphics gr)
        {
            foreach (TreeNode<T> child in children)
            {
                gr.DrawLine(pen, spotCenter.X, spotCenter.Y, spotCenter.X, child.spotCenter.Y);
                gr.DrawLine(pen, spotCenter.X, child.spotCenter.Y, child.spotCenter.X, child.spotCenter.Y);

                child.DrawSubtreeLinks(gr);
            }
        }

        public void DrawSubtreeNodes(Graphics gr)
        {
            data.Draw(dataCenter.X, dataCenter.Y, gr, pen, bgBrush, frontBrush, font);

            RectangleF rect = new RectangleF((spotCenter.X - spotRadius), (spotCenter.Y - spotRadius), (2 * spotRadius), (2 * spotRadius));

            if (children.Count > 0)
                gr.FillEllipse(Brushes.DarkSeaGreen, rect);
            else
                gr.FillEllipse(Brushes.LightGreen, rect);

            gr.DrawEllipse(pen, rect);

            foreach (TreeNode<T> child in children)
            {
                child.DrawSubtreeLinks(gr);
            }
        }
    }
}
