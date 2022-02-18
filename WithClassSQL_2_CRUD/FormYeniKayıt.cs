using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WithClassSQL_2_CRUD
{
    public partial class FormYeniKayıt : Form
    {
        VeriTabani vt = new VeriTabani();
        string sorguCumlesi;
        public FormYeniKayıt()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (vt.KontrolEt(txtTc.Text,txtAd.Text,txtSoyad.Text,cmbCinsiyet.Text,txtAdres.Text,txtTelefon.Text,txtMail.Text))
            {
                string Cinsiyet = cmbCinsiyet.Text == "Kadın" ? "K" : "E";
                sorguCumlesi = $"INSERT INTO tblHastalar VALUES('{txtTc.Text}','{txtAd.Text}','{txtSoyad.Text}','{Cinsiyet}','{txtAdres.Text}','{txtTelefon.Text}','{txtMail.Text}')";
                vt.islem(sorguCumlesi);
                temizle();
            }
            else
            {
               MessageBox.Show("Lütfen boş bırakılan alanları doldurun.");
            }
        }
        void temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            txtMail.Clear();

        }
        private void FormYeniKayıt_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormBolumler formbolum = new FormBolumler();
            formbolum.Show();
            this.Hide();
        }

        
    }
}
