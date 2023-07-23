using System;
using System.Windows.Forms;

namespace Film_Arsivim
{
    public partial class FormTamEkran : Form
    {
        public FormTamEkran()
        {
            InitializeComponent();
        }

        public string url = "";

        private void FormTamEkran_Load(object sender, EventArgs e)
        {
            if (url != "")
            {
                this.WindowState= FormWindowState.Maximized;
                webBrowser1.Navigate(url);
            }
        }

        private void FormTamEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form=new Form1();
            form.Show();
            this.Hide();
        }
    }
}
