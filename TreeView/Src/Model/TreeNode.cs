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
        public Brush BgBrush;

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
            BgBrush = Brushes.White;

            //Spacing properties
            hOffSet = 5;
            vOffSet = 10;
            indent = 20;
            spotRadius = 5;
        }
    }
}
