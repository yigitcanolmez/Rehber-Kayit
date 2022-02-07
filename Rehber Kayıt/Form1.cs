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

namespace Rehber_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Sql bağlantısını class içinde tanımladık onu çağıralım
        baglanti bgl = new baglanti();


        // textbox'ları temizlemek için gerekli olan metot
        public void temizle()
        {
            txtid.Clear();
            txtad.Clear();
            txtsoyad.Clear();
            txtmail.Clear();
            txttelefon.Clear();
        }
        //DataGrid'e veri listeleme metodu
       public void listele()
        {
            baglanti.bgl();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_kisiler", baglanti.bgl());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.bgl();
            SqlCommand komut = new SqlCommand("Delete from tbl_kisiler where ID=@p1",baglanti.bgl());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            listele();
            temizle();
            MessageBox.Show("Kişi başarıyla silinmiştir.");

        }


        private void btntemizle_Click(object sender, EventArgs e)
        {

            //textboxları temizliyoruz
            temizle();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGrid'de üzerine tıklanan verileri yazdırma

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txttelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtmail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
       
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            // Veriyi güncelleme işlemi
            baglanti.bgl();

            SqlCommand komutguncelle = new SqlCommand("Update tbl_kisiler set AD=@p1, SOYAD = @p2, TELEFON = @p3, MAİL=@p4 where ID = @p5 ",baglanti.bgl());
           
            komutguncelle.Parameters.AddWithValue("@p1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txttelefon.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtmail.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtid.Text);

            komutguncelle.ExecuteNonQuery();

            MessageBox.Show("Kişi başarıyla güncellenmiştir.");

            listele();
            temizle();

            baglanti.bgl().Close();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.bgl();

            SqlCommand komut = new SqlCommand("Insert into tbl_kisiler  (AD,SOYAD,TELEFON,MAİL) values (@p1,@p2,@p3,@p4)", baglanti.bgl());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txttelefon.Text);
            komut.Parameters.AddWithValue("@p4", txtid.Text);
            komut.ExecuteNonQuery();
            listele();
            temizle();
            MessageBox.Show("Kişi başarıyla eklenmiştir.");
            baglanti.bgl().Close();
        }
    }
}
