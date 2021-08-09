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
    public partial class frmSatışlar : Form
    {
        public frmSatışlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(connectionString.connection);
        DataSet daset = new DataSet();
        private void satışlistele()
        {
            baglanti.Open();

            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM satis", baglanti);
            adtr.Fill(daset, "satis");
            dataGridView1.DataSource = daset.Tables["satis"];


            baglanti.Close();
        }

        private void frmSatışListele_Load(object sender, EventArgs e)
        {
            satışlistele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
