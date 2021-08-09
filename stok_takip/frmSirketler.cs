using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip
{
    public partial class frmSirketler : Form
    {
        public frmSirketler()
        {
            InitializeComponent();
        }
        // SqlConnection baglanti = new SqlConnection("Data Source=192.168.78.184;Initial Catalog=Stok_Takip;Persist Security Info=True;User ID=SA;Password=Password1");
        SqlConnection baglanti = new SqlConnection(connectionString.connection);
        DataSet daset = new DataSet();

        private void frmMüşteriListele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();
        }

        private void Kayıt_Göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM müşteri",baglanti);
            adtr.Fill(daset, "müşteri");
            dataGridView1.DataSource = daset.Tables["müşteri"];
            baglanti.Close();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE müşteri set adsoyad=@adsoyad,telefon=" +
            "@telefon,adres=@adres,email=@email WHERE sirketadi=@sirketadi",baglanti);
            komut.Parameters.AddWithValue("@sirketadi", txtŞirket.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Müşteri kaydı başarıyla güncellendi..");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            var silinecekTc = dataGridView1.CurrentRow.Cells["sirketadi"].Value.ToString();
            SqlCommand komut = new SqlCommand("DELETE FROM müşteri WHERE sirketadi = '" +silinecekTc+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Kayıt başarıyla silindi..");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtŞirket.Text = dataGridView1.CurrentRow.Cells["sirketadi"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString(); 
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM müşteri WHERE sirketadi " +
            "LIKE '%" + txtŞirketAra.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}





