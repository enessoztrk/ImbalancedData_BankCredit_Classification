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
    public partial class frmÜrünGüncelleme : Form
    {
        public frmÜrünGüncelleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(connectionString.connection);
        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
        DataSet daset = new DataSet();
        private void frmÜrünListele_Load(object sender, EventArgs e)
        {
            ÜrünListele();
            kategorigetir();
        }

        private void ÜrünListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM urun ", baglanti);
            adtr.Fill(daset, "urun");
            dataGridView1.DataSource = daset.Tables["urun"];
            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BarkodNotxt.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            Kategoritxt.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            Markatxt.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            ÜrünAdıtxt.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            Miktarıtxt.Text = dataGridView1.CurrentRow.Cells["miktari"].Value.ToString();
            SatışFiyatıtxt.Text = dataGridView1.CurrentRow.Cells["satisfiyati"].Value.ToString();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE urun SET urunadi=@urunadi,miktari=@miktari,satisfiyati=@satisfiyati Where barkodno=@barkodno ", baglanti);
            komut.Parameters.AddWithValue("barkodno", BarkodNotxt.Text);
            komut.Parameters.AddWithValue("urunadi", ÜrünAdıtxt.Text);
            komut.Parameters.AddWithValue("miktari", int.Parse(Miktarıtxt.Text));
            komut.Parameters.AddWithValue("satisfiyati", double.Parse(SatışFiyatıtxt.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urun"].Clear();
            ÜrünListele();

            MessageBox.Show("Güncellendi..");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnMarkaGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE urun set kategori=@kategori,marka=@marka WHERE barkodno=@barkodno ", baglanti);
            komut.Parameters.AddWithValue("barkodno", BarkodNotxt.Text);
            komut.Parameters.AddWithValue("kategori", comboKategori.Text);
            komut.Parameters.AddWithValue("marka", comboMarka.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi..");
            daset.Tables["urun"].Clear();
            ÜrünListele();
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM markabilgileri WHERE kategori='" + comboKategori.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            var silinecekTc = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            SqlCommand komut = new SqlCommand("DELETE FROM urun WHERE barkodno = '" + silinecekTc + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urun"].Clear();
  
            ÜrünListele();
            MessageBox.Show("Kayıt başarıyla silindi..");
        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            //Geçiçi Tablo
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM urun where barkodno LIKE '%" + txtBarkodNoAra.Text + "%'", baglanti);
            //Kayıtları gösterme
            adtr.Fill(tablo);
            //Tablo atama
            dataGridView1.DataSource = tablo;
            //Tablo eşitleme
            baglanti.Close();
            
        }

        private void Miktarıtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }

}