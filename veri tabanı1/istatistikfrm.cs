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
    public partial class istatistikfrm : Form
    {
        public istatistikfrm()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-H2V6Q7S\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void istatistikfrm_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From tbl_personel  ", baglan);
            SqlDataReader dr1 = komut1.ExecuteReader(); // okuma işlemini başlat 
            while (dr1.Read())
            {
                lblpersosayı.Text = dr1[0].ToString();

            }
            baglan.Close();


            // bekar peersonel

            baglan.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From tbl_personel where perdurum =0 ", baglan);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                bkrpersonal.Text = dr2[0].ToString();   
            }
            baglan.Close();


            // evli personel

            baglan.Open();

            SqlCommand komut3 = new SqlCommand("Select Count(*) From tbl_personel where perdurum=1", baglan);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                evlipersonel.Text = dr3[0].ToString();
            }
            baglan.Close();

            // sehir sayısı

            baglan.Open();

            SqlCommand komut4 = new SqlCommand("Select Count(distinct(sehir)) From tbl_personel", baglan);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                sehirsayı.Text = dr4[0].ToString();
            }
            baglan.Close();


            // toplam maas hesaplama

            baglan.Open();

            SqlCommand komut5 = new SqlCommand("Select Sum(permaas) From tbl_personel",baglan);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                topmaas.Text= dr5[0].ToString();    
            }
            baglan.Close();


            // ortalama maas
            baglan.Open();

            SqlCommand komut6 = new SqlCommand("Select avg(permaas) From tbl_personel", baglan);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                ortmaas.Text = dr6[0].ToString();
            }
            baglan.Close();



        }
    }
}
