using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreeView.Model
{
    public class CircleNode : IDrawable
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

            SizeF mySize = GetSize(gr, font);
            RectangleF rect = new RectangleF((x - mySize.Width / 2), (y - mySize.Height / 2), mySize.Width, mySize.Height);
            gr.FillEllipse(bgBrush, rect);
            gr.DrawEllipse(pen, rect);

            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, textBrush, x, y, stringFormat);
            }
        }
    }
}
