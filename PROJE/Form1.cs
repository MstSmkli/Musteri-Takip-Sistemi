using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PROJE
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection(@"Data Source=MESUT35\SQLEXPRESS01;Initial Catalog=Proje;Integrated Security=True");
            com = new SqlCommand();

            con.Open();
            com.Connection = con;
            com.CommandText = "Select*from tablo_login where kullanici_adi='" + textBox1.Text + "'and sifre = '" + textBox2.Text + "'";

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form2 kayıt = new Form2();
                 kayıt.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Giriş Hatalı");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            con = new SqlConnection(@"Data Source=MESUT35\SQLEXPRESS01;Initial Catalog=Proje;Integrated Security=True");
            com = new SqlCommand();

            con.Open();
            com.Connection = con;
            com.CommandText = "Select*from tablo_login where kullanici_adi='" + textBox1.Text + "'and sifre = '" + textBox2.Text + "'";

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form3 form3sec = new Form3();
                form3sec.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Giriş Hatalı");
            }

            con.Close();

        }
    }
}
