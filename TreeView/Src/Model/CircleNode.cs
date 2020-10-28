using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreeView.Src.Model
{
    class CircleNode : IDrawable
    {
        //Attributes
        public string text;

        //Constructor
        public CircleNode(string text)
        {
            this.text = text;
        }

        //Methods
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(text, font) + new SizeF(10, 10);
        }

        void IDrawable.Draw(float x, float y, Graphics gr, Pen pen, Brush bgBrush, Brush textBrush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = GetSize(gr, font);
            RectangleF rect = new RectangleF(
                x - my_size.Width / 2,
                y - my_size.Height / 2,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bgBrush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, textBrush, x, y, string_format);
            }
        }
    }
}
