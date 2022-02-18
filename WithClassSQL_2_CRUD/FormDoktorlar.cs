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
    public partial class FormDoktorlar : Form
    {
        VeriTabani vt = new VeriTabani();
        public FormDoktorlar()
        {
            InitializeComponent();
        }

        private void FormDoktorlar_Load(object sender, EventArgs e)
        {
            cmbBolumAd.DataSource = vt.KayıtListele("SELECT*FROM tblBolumler");
            cmbBolumAd.DisplayMember ="BolumAd";
            cmbBolumAd.ValueMember = "ID";

        }

        private void cmbBolumAd_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    MessageBox.Show(cmbBolumAd.SelectedValue.ToString()) ;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string sorguCumlesi = $"INSERT INTO tblDoktorlar VALUES('{txtSicilNo.Text}','{txtAdSoyad.Text}','{txtTel.Text}','{txtMail.Text}','{cmbBolumAd.SelectedValue.ToString()}')";
            vt.islem(sorguCumlesi);
        }
    }
}
