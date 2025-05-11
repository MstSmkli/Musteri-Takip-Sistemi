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

namespace PROJE
{
    public partial class Form3 : Form
    {
        static string constring = (@"Data Source=MESUT35\SQLEXPRESS01;Initial Catalog=Proje;Integrated Security=True");
        SqlConnection giris = new SqlConnection(constring);

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1sec = new Form1();
            form1sec.Show();
            this.Hide();
        }

        public void verisil(int id)
        {
            try
            {
                string sil = "Delete From musteri_tablo where veri_id=@id";
                if (giris.State == ConnectionState.Closed)
                    giris.Open();
                SqlCommand komut = new SqlCommand(sil, giris);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
                giris.Close();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen hata: " + ex.Message);
            }
        }

        public void kayitlari_getir()
        {
            try
            {
                string getir = "select * from musteri_tablo";
                SqlCommand komut = new SqlCommand(getir, giris);
                SqlDataAdapter ad = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıtları getirme hatası: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string kayit = "select * From musteri_tablo where Giris_tarih=@Giris_tarih";
                SqlCommand komut = new SqlCommand(kayit, giris);
                komut.Parameters.AddWithValue("@Giris_tarih", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                giris.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıtları getirme hatası: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
                {
                    int id = Convert.ToInt32(drow.Cells[0].Value);
                    verisil(id);
                }
                kayitlari_getir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt silme hatası: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kayitlari_getir();
        }

        int i = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (giris.State == ConnectionState.Closed)
                    giris.Open();
                string kayıtguncelle = "Update musteri_tablo Set musteri_adi=@Musteri_adi, Musteri_tel_no=@Musteri_tel_no Where veri_id=@id";
                SqlCommand komut = new SqlCommand(kayıtguncelle, giris);
                komut.Parameters.AddWithValue("@Musteri_adi", textBox2.Text);
                komut.Parameters.AddWithValue("@Musteri_tel_no", textBox3.Text);
                komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
                komut.ExecuteNonQuery();
                giris.Close();
                kayitlari_getir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt güncelleme hatası: " + ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (giris.State == ConnectionState.Closed)
                    giris.Open();
                string kayit = "insert into musteri_tablo (Musteri_adi, Musteri_tel_no,Giris_tarih) values (@Musteri_adi, @Musteri_tel_no,@Giris_tarih)";
                SqlCommand komut = new SqlCommand(kayit, giris);
                komut.Parameters.AddWithValue("@Musteri_adi", textBox2.Text);
                komut.Parameters.AddWithValue("@Musteri_tel_no", textBox3.Text);
                komut.Parameters.AddWithValue("@Giris_tarih", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                giris.Close();
                kayitlari_getir();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt ekleme hatası: " + ex.Message);
            }
        }
    }
}
