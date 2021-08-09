using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip
{
    public partial class frmHelpButon : Form
    {
        public frmHelpButon()
        {
            InitializeComponent();
        }
      class ovalbuton:Button
        {
            //method ezme, geriye değer döndürmeyen method
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                GraphicsPath gp = new GraphicsPath();
                Rectangle rec = new Rectangle(Point.Empty,this.Size);
                gp.AddEllipse(rec);
                Region = new Region(gp);
            }
        }
        private void frmHelp_Load(object sender, EventArgs e)
        {
            ovalbuton o_buton = new ovalbuton();
            o_buton.Size = new Size(100, 100);
            o_buton.Location = new Point(100, 50);
            o_buton.FlatStyle = FlatStyle.Flat;
            o_buton.FlatAppearance.BorderSize = 2;
            o_buton.Text = "HELP";
            o_buton.BackColor = Color.Red;
            o_buton.ForeColor = Color.Black;
            this.Controls.Add(o_buton);
            o_buton.Click += O_buton_Click;
        }

        private void O_buton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help butonu açılıyor.");
        }
    }
}
