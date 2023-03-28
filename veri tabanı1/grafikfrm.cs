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
    public partial class grafikfrm : Form
    {
        public grafikfrm()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-H2V6Q7S\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        private void grafikfrm_Load(object sender, EventArgs e)
        {
            //chart1
            baglan.Open();

            SqlCommand grafk = new SqlCommand("Select sehir, Count(*) From tbl_personel group by sehir",baglan);
            SqlDataReader gf = grafk.ExecuteReader();
            while (gf.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(gf[0], gf[1]);

            }
            baglan.Close();

            //chart2


            baglan.Open();

            SqlCommand grafk2 = new SqlCommand("Select perad,avg(permaas) From tbl_personel group by perad", baglan);
            SqlDataReader gf2 = grafk2.ExecuteReader();
            while (gf2.Read())
            {
                chart2.Series["meslek-Maas"].Points.AddXY(gf2[0], gf2[1]);
            }

            baglan.Close();

        }
    }
}
