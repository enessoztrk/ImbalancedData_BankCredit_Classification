using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip
{
    public partial class Satı : Form
    {
        public Satı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(connectionString.connection);
        DataSet daset = new DataSet();
        int indirimYuzdesi = 0;
        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM sepet",baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            baglanti.Close(); 
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            sepetlistele();
            comboBox1.Items.Add("Yurt içi %0");
            comboBox1.Items.Add("Yurt içi %10");
            comboBox1.Items.Add("Yurt içi %20");
            comboBox1.Items.Add("Yurt dışı %0");
            comboBox1.Items.Add("Yurt dışı %10");
            comboBox1.Items.Add("Yurt dışı %20");
            comboBox1.SelectedIndex = 0;

            //Arka plan rengi sürekli değişiyordu, bu kod sabitledi.
            dataGridView1.BackgroundColor = Color.White;

            OvalButton o_buton = new OvalButton();
            o_buton.Size = new Size(60, 60);
            o_buton.Location = new Point(4, 8);
            o_buton.FlatStyle = FlatStyle.Flat;
            o_buton.FlatAppearance.BorderSize = 0;
            o_buton.Text = "H E L P";
            o_buton.BackColor = Color.Red;
            o_buton.ForeColor = Color.White;
            groupBox3.Controls.Add(o_buton);
            o_buton.Click += O_buton_Click;

        }
        private void O_buton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başlangıç Ekranı:\nSağ kısımda ürünlerimiz barkod numarasına göre ekrana getirilip indirim seçeneğini " +
                "seçip onayla dedikten sonra indirim uygulanır, ekle seçeneği ile ürünümüz sepete başarılı şekilde eklenir. \n\n" +
                "Şirket Ekleme:\nMüşterilerimizi bu sekmeden ekleyebiliriz. \n\n" +
                "Şirket Listeleme:\nMevcut şirketleri buradan görüntüleyebiliriz.Ek olarak satırların üzerine çift tıklayarak güncelleme yapabiriz. \n\n" +
                "Ürün Ekleme:\nÜrün ve azalan stoklara bu sekmeden ekleme yapabiliriz.\n\n" +
                "Ürün Listeleme:\nÜrünlerimizin üzerine çift tıklayarak güncelleme yapabiliriz.\n\n" +
                "Satışlar:\nSatılan ürünler burada listelenir.Herhangi bi değiştirme işlemi yapılamaz bu ekranda. ");
        }
        private void hesapla()
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT SUM(toplamfiyati) " +
                "FROM sepet ", baglanti);
                lblGenelToplam.Text = komut.ExecuteScalar() + " TL";
                baglanti.Close();
                
            }
            catch(Exception)
            {
                ;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(txtŞirket.Text=="")
            {
                txtAdSoyad.Text = "";
                txtTelefon.Text = "";
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM müşteri WHERE sirketadi " +
            "LIKE'" + txtŞirket.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtTelefon.Text = read["telefon"] .ToString();
            }
            read.Close();
            baglanti.Close();
        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmÜrünGüncelleme listele = new frmÜrünGüncelleme();
            listele.ShowDialog();
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmÜrünStokEkleme ekle = new frmÜrünStokEkleme();
            ekle.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSirketEkle ekle = new frmSirketEkle();
            ekle.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        
        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }
        bool check;
        private void barkodcheck()
        {
            check = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM sepet", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                if (txtBarkodNo.Text ==read["barkodno"].ToString()); 
                {
                    check = true;
                }
            }
            baglanti.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtBarkodNo.Text == "")
            {
                MessageBox.Show("BarkodNo boş kalamaz...");
                return;
            }
            barkodcheck();
            if(check == false || check ==true)             
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO sepet(sirketadi,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih)" +
                    "VALUES(@sirketadi,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@sirketadi", txtŞirket.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@urunadi", txtÜrünAdı.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktari.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışFiyatı.Text));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(txtToplamFiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();

                SqlCommand komut2 = new SqlCommand("UPDATE sepet SET miktari = miktari+'" + int.Parse(txtMiktari.Text) +
                "'WHERE barkodno='" + txtBarkodNo.Text + "'", baglanti);
                komut2.ExecuteNonQuery();

                SqlCommand komut3 = new SqlCommand("UPDATE sepet SET toplamfiyati = miktari*satisfiyati " +
                "WHERE barkodno='" + txtBarkodNo.Text + "'", baglanti);
                komut3.ExecuteNonQuery();

                baglanti.Close();
            }
                
            txtMiktari.Text = "1";
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtMiktari)
                    {
                        item.Text = "";
                    }
                }
            }
        }
                

        private void button9_Click(object sender, EventArgs e)
        {
             frmSatışlar listele = new frmSatışlar();
            listele.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSirketler listele = new frmSirketler();
            listele.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmKatagori katagori = new frmKatagori();
            katagori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKategoriMarka marka = new frmKategoriMarka();
            marka.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtBarkodNo_TextChanged(object sender , EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                txtÜrünAdı.Text = "";
                txtSatışFiyatı.Text = "";
                txtToplamFiyat.Text = "";
                txtMiktari.Text = "1";

            }

            
            Yenile();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM urun WHERE barkodno LIKE'" + txtBarkodNo.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())

            {
                txtÜrünAdı.Text = read["urunadi"].ToString();
                txtSatışFiyatı.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }
        private void FiyatYenile()
        {
            if (txtBarkodNo.Text == "")
            {
                txtÜrünAdı.Text = "";
                txtSatışFiyatı.Text = "";
                txtToplamFiyat.Text = "";
                txtMiktari.Text = "1";
            }
            Yenile();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM urun " +
            "WHERE barkodno LIKE'" + txtBarkodNo.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtÜrünAdı.Text = read["urunadi"].ToString();
                txtSatışFiyatı.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }
        private void Yenile() 
        {
            if (txtBarkodNo.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtMiktari)
                        {
                            item.Text = "";
                        }
                    }
                }

            }
        }

        private void txtMiktari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) 
                * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void txtSatışFiyatı_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) 
               * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }     
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM sepet WHERE id = '"+dataGridView1.CurrentRow.Cells["id"].Value.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            hesapla();
            MessageBox.Show("Sepetten çıkarıldı...");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void btnSatışİptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM sepet", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Ürünler iptal edildi...");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void btnSatışYap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO satis(sirketadi,adsoyad,telefon,barkodno,urunadi,miktari," +
                "satisfiyati,toplamfiyati,tarih)" +
                "VALUES(@sirketadi,@adsoyad,@telefon,@barkodno,@urunadi,@miktari," +
                "@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@sirketadi", txtŞirket.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now);
                komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("UPDATE urun SET miktari=miktari-'" + 
                int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) 
                + "' WHERE barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);

                komut2.ExecuteNonQuery();
                baglanti.Close();
            }

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("DELETE FROM sepet", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
            MessageBox.Show("Satış başarıyla yapıldı...");
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            indirimAyarla();
        }

        private void indirimAyarla()
        {
            int indirimOrani;
            int q;
            if (int.TryParse(comboBox1.SelectedItem.ToString().Split('%')[1], out q))
            {
               indirimOrani = int.Parse(comboBox1.SelectedItem.ToString().Split('%')[1]);
            }
            else
            {
                indirimOrani = 0;
            }
            //MessageBox.Show("%" + indirimOrani.ToString() + "indirim ayarlandı...");
            //İşlemlerin daha hızlı olabilmesi için mesaj yazdırmadım bu işlemde.

            indirimYuzdesi = indirimOrani;
            label5.Text = "%" + indirimOrani + " indirim \n yapıldı.";
            if (txtSatışFiyatı.Text == "")
            {
                return;
            }
            FiyatYenile();
            decimal simdikiFiyati = decimal.Parse(txtSatışFiyatı.Text);
            var indirimUygula = (decimal.Parse(txtSatışFiyatı.Text) - 
            (decimal.Parse(txtSatışFiyatı.Text) * indirimOrani) / 100);
            txtSatışFiyatı.Text = indirimUygula.ToString();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }
    }
}

