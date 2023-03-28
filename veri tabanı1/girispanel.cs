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

namespace veri_tabanı1
{
    public partial class girispanel : Form
    {
        public girispanel()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-H2V6Q7S\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void btngiris_Click(object sender, EventArgs e)
        {
           baglan.Open();
           SqlCommand komut = new SqlCommand("Select * From tbl_yonetici where kullani_ad=@p1 and sifre=@p2",baglan);
            komut.Parameters.AddWithValue("@p1", txtkullanıad.Text);
            komut.Parameters.AddWithValue("@p2",txtsifre.Text);
           
           SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AnaMenu menu= new AnaMenu();
                menu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("kullanici ad veya şifreyi hatalı girdiniz");
            }

           baglan.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
