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
    public partial class Form2 : Form
    {
        static string constring =(@"Data Source=MESUT35\SQLEXPRESS01;Initial Catalog=Proje;Integrated Security=True");
        SqlConnection giris = new SqlConnection(constring);



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1sec = new Form1();
                        form1sec.Show();
                       this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (giris.State == ConnectionState.Closed)
                {
                    giris.Open();
                    string kayit = "insert into tablo_login (kullanici_adi,sifre)values(@kullanici_adi,@sifre)";
                    SqlCommand komut = new SqlCommand(kayit, giris);
                    komut.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                }
              
            }
            catch(Exception hata)
            {
                MessageBox.Show("Kayıt Ekleme Başarısız" + hata.Message);
            }
        }
    }
}
