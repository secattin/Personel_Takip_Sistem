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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-H2V6Q7S\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");


        void temizle()
        {
            textıd.Text = "";
            textad.Text = "";
            textsoyad.Text = "";
            combsehir.Text = "";
            maskmaas.Text = "";
            radiobekar.Text = "false";
            radioevli.Text = "false";   
            textad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into tbl_personel (perad,persoyad,sehir,permaas,perdurum) values (@p1,@p2,@p3,@p4,@p5) " , baglan);
            komut.Parameters.AddWithValue("@p1", textad.Text);
            komut.Parameters.AddWithValue("@p2", textsoyad.Text);
            komut.Parameters.AddWithValue("@p3",combsehir.Text);
            komut.Parameters.AddWithValue("@p4", maskmaas.Text);
            komut.Parameters.AddWithValue("@p5",label7.Text );
            komut.ExecuteNonQuery();
            baglan.Close();
            
               
            MessageBox.Show("basarılı şekide eklendi");


        }

        private void radioevli_CheckedChanged(object sender, EventArgs e)
        {
            if (radioevli.Checked == true)
            {
                label7.Text = "True";

            }
        }


        private void radiobekar_CheckedChanged(object sender, EventArgs e)
        { 
                if (radiobekar.Checked==true)
                {
                    label7.Text = "False";
                }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;

            textıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            combsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();   
            maskmaas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();



            

        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if (label7.Text == "True")
            {
                radioevli.Checked = true;
            }

            if(label7.Text == "False")
            {
                radiobekar.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            
            SqlCommand silkomut = new SqlCommand("Delete From tbl_personel where perıd =@c1", baglan);
            silkomut.Parameters.AddWithValue("@c1", textıd.Text);
            silkomut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btnguncel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand güncelkomut = new SqlCommand("Update tbl_personel Set perad=@a1, persoyad=@a2,sehir=@a3, perdurum=@a4,permaas=@a5  where perıd=@a6", baglan);
            güncelkomut.Parameters.AddWithValue("@a1", textad.Text);
            güncelkomut.Parameters.AddWithValue("@a2", textsoyad.Text);
            güncelkomut.Parameters.AddWithValue("@a3", combsehir.Text);
            güncelkomut.Parameters.AddWithValue("@a4", label7.Text);
            güncelkomut.Parameters.AddWithValue("@a5", maskmaas.Text);
            güncelkomut.Parameters.AddWithValue("@a6", textıd.Text);
            güncelkomut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("personel bilgiler güncelledi");
        }

        private void btnistatik_Click(object sender, EventArgs e)
        {
            istatistikfrm fr = new istatistikfrm();
            fr.Show();

        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            grafikfrm grafik = new grafikfrm();
            grafik.Show();
        }
    }
}
