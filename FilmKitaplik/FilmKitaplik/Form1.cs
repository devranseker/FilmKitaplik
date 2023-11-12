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


namespace FilmKitaplik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlbaglantisi = new SqlConnection(@"Data Source=DEVRAN-PC\SQLEXPRESS;Initial Catalog=FilmArsivim1;Integrated Security=True");
        // method olarak cagıralım da ekleme isleminden sonra cagıralım 
        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLFILMLER", sqlbaglantisi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        // Kaydet Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            sqlbaglantisi.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (NAME,CATEGORY,LINK) values (@P1,@P2,@P3)", sqlbaglantisi);
            // Parametre ataması 
            komut.Parameters.AddWithValue("@P1", TxtFilmName.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();
            sqlbaglantisi.Close();
            MessageBox.Show("Film Listenize Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        // CellDoubleClick cift tıkladıgında ne olsun 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        // Hakkıızda Butonu
        private void BtnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhaba Hoşgeldiniz Bu Proje Devran ŞEKER Tarafından Kodlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        // Cıksı ;Butonu
        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Tam ekran Butonu Odev
        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            // Burası Ödev Güncellemem gerekiyor

        }

    }
}
