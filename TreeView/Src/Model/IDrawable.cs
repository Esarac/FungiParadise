using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TreeView.Src.Model
{
    interface IDrawable
    {
        // Return the object's needed size.
        SizeF GetSize(Graphics gr, Font font);

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font);
    }
}
