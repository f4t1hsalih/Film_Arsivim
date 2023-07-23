using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Film_Arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = krsDbFilmArsivim; Integrated Security = True");

        string link;

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Link from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER(Ad,Kategori,Link)values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@p2", txtKategori.Text);
            komut.Parameters.AddWithValue("@p3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            link = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje 23 Temmuz 2023'de Kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRenkDegistir_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int c = rnd.Next(0, 255);
            this.BackColor = System.Drawing.Color.FromArgb(a, b, c);
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            if (link != "" && link != null)
            {
                FormTamEkran tamEkran = new FormTamEkran();
                tamEkran.url = link;
                tamEkran.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Link Seçiniz");
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
