using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stok_takip
{
    public partial class frmKatagori : Form
    {
        public frmKatagori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(connectionString.connection);
        private void frmKatagori_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO kategoribilgileri(kategori) " +
            "VALUES('"+textBox1.Text+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            MessageBox.Show("Kategori başarıyla eklendi..");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
