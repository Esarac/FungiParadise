using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreeView.Model
{
    public class TreeNode<T> where T : IDrawable
    {
        //Attributes
        public T data;
        public List<TreeNode<T>> children;
        public Orientations orientation;

        //Drawing properties
        public Font font;
        public Pen pen;
        public Brush fontBrush;
        public Brush bgBrush;

        //Spacing properties
        public float hOffSet;
        public float vOffSet;
        public float indent;
        public float spotRadius;

        //Node properties
        private PointF dataCenter;
        private PointF spotCenter;

        //Enum
        public enum Orientations
        {
            Horizontal,
            Vertical
        }

        //Constructor
        public TreeNode(T data)
        {
            //Attributes
            this.data = data;
            children = new List<TreeNode<T>>();

            //Drawing properties
            this.font = new Font("Microsoft Sans Serif", 10);
            pen = Pens.Black;
            fontBrush = Brushes.Black;
            bgBrush = Brushes.White;

            //Spacing properties
            hOffSet = 5;
            vOffSet = 10;
            indent = 20;
            spotRadius = 5;
        }

        //Methods
        public void SetTreeDrawingParameters(float hOffSet, float vOffSet, float indent, float spotRadius, Orientations orientation)
        {
            this.hOffSet = hOffSet;
            this.vOffSet = vOffSet;
            this.indent = indent;
            this.spotRadius = spotRadius;
            this.orientation = orientation;

            foreach (TreeNode<T> child in children)
                child.SetTreeDrawingParameters(hOffSet, vOffSet, indent, spotRadius, orientation);
        }

        public void AddChild(TreeNode<T> child)
        {
            children.Add(child);
        }

        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
            if (orientation == TreeNode<T>.Orientations.Horizontal)
            {
                ArrangeHorizontally(gr, ref xmin, ref ymin);
            }
            else
            {
                ArrangeVertically(gr, xmin, ref ymin);
            }
        }

        public void ArrangeHorizontally(Graphics gr, ref float xmin, ref float ymin)
        {
            SizeF mySize = data.GetSize(gr, font);

            float x = xmin;
            float biggestYmin = ymin + mySize.Height;
            float subtreeYmin = ymin + mySize.Height + vOffSet;

            foreach (TreeNode<T> child in children)
            {
                float childYmin = subtreeYmin;
                child.Arrange(gr, ref x, ref childYmin);

                if (biggestYmin < childYmin) 
                    biggestYmin = childYmin;

                x += hOffSet;
            }

            if (children.Count > 0) 
                x -= hOffSet;

            float subtreeWidth = x - xmin;
            if (mySize.Width > subtreeWidth)
            {
                x = xmin + (mySize.Width - subtreeWidth) / 2;
                foreach (TreeNode<T> child in children)
                {
                    child.Arrange(gr, ref x, ref subtreeYmin);
                    x += hOffSet;
                }

                subtreeWidth = mySize.Width;
            }

            dataCenter = new PointF((xmin + subtreeWidth / 2), (ymin + mySize.Height / 2));

            xmin += subtreeWidth;
            ymin = biggestYmin;
        }

        public void ArrangeVertically(Graphics gr, float xmin, ref float ymin)
        {
            SizeF mySize = data.GetSize(gr, font);
            mySize.Width += 3 * spotRadius;

            spotCenter = new PointF((xmin + spotRadius), (ymin + (mySize.Height - 2 * spotRadius) / 2));
            dataCenter = new PointF((spotCenter.X + spotRadius + mySize.Width / 2), (spotCenter.Y));

            ymin += mySize.Height + vOffSet;

            foreach (TreeNode<T> child in children)
            {
                child.ArrangeVertically(gr, (xmin + indent), ref ymin);
            }
        }

        public void DrawTree(Graphics gr, ref float x, float y)
        {
            Arrange(gr, ref x, ref y);
            DrawTree(gr);
        }

        public void DrawTree(Graphics gr)
        {
            DrawSubtreeLinks(gr);
            DrawSubtreeNodes(gr);
        }

        private void DrawSubtreeLinks(Graphics gr)
        {
            if (orientation == TreeNode<T>.Orientations.Horizontal)
            {
                DrawSubtreeLinksHorizontal(gr);
            }
            else
            {
                DrawSubtreeLinksVertical(gr);
            }
        }

        private void DrawSubtreeLinksHorizontal(Graphics gr)
        {
            foreach (TreeNode<T> child in children)
            {
                gr.DrawLine(pen, dataCenter, child.dataCenter);
                child.DrawSubtreeLinksHorizontal(gr);
            }
        }

        private void DrawSubtreeLinksVertical(Graphics gr)
        {
            foreach (TreeNode<T> child in children)
            {
                gr.DrawLine(pen, spotCenter.X, spotCenter.Y, spotCenter.X, child.spotCenter.Y);
                gr.DrawLine(pen, spotCenter.X, child.spotCenter.Y, child.spotCenter.X, child.spotCenter.Y);
                child.DrawSubtreeLinksVertical(gr);
            }
        }

        private void DrawSubtreeNodes(Graphics gr)
        {
            bool circle = true;
            if (orientation == TreeNode<T>.Orientations.Vertical)
                circle = false;
            data.Draw(dataCenter.X, dataCenter.Y, gr, pen, bgBrush, fontBrush, font, circle);

            if (orientation == TreeNode<T>.Orientations.Vertical)
            {
                RectangleF rect = new RectangleF((spotCenter.X - spotRadius), (spotCenter.Y - spotRadius), (2 * spotRadius), (2 * spotRadius));

                if (children.Count > 0)
                {
                    gr.FillEllipse(Brushes.DarkGreen, rect);
                }
                else
                {
                    gr.FillEllipse(Brushes.LightGreen, rect);
                }

                gr.DrawEllipse(pen, rect);

            }

            foreach (TreeNode<T> child in children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }
    }
}
