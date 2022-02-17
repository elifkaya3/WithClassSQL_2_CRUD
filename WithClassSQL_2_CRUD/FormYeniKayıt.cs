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
        public FormYeniKayıt()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string Cinsiyet=cmbCinsiyet.Text=="Kadın"?"K":"E";
            vt.Ekle(txtTc.Text,txtAd.Text,txtSoyad.Text,Cinsiyet,txtAdres.Text,txtTelefon.Text,txtMail.Text);
       
        }

        private void FormYeniKayıt_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAna formAna1 = new FormAna();
            formAna1.Show();
            this.Hide();
        }

        
    }
}
