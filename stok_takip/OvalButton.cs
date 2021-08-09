using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip
{
    public class OvalButton:Button
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(Point.Empty, this.Size);
            gp.AddEllipse(rec);
            Region = new Region(gp);
            // kütüphane ekledik
        }
    }
}
