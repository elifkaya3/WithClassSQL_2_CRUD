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
    public partial class FormRandevu : Form
    { VeriTabani vt = new VeriTabani();
        public FormRandevu()
        {
            InitializeComponent();
        }

        void BolumDoldur()
        {
            cmbBolum.DataSource = vt.KayıtListele("SELECT*FROM tblBolumler");
            cmbBolum.DisplayMember = "BolumAd";
            cmbBolum.ValueMember = "ID";
        }
        void DoktorDoldur()
        {
            string bolumID = cmbBolum.SelectedValue.ToString();
            string sorguCumlesi = $"SELECT*FROM tblDoktorlar";
            lstDoktorlar.DataSource = vt.KayıtListele(sorguCumlesi);
            lstDoktorlar.DisplayMember = "AdSoyad";
            lstDoktorlar.ValueMember = "ID";
        }
        void HastalarıDoldur()
        {
            string sorguCumlesi = $"SELECT ID,Ad,Soyad FROM tblHastalar";
            dgvHasta.DataSource = vt.KayıtListele(sorguCumlesi);
        }
        private void FormRandevu_Load(object sender, EventArgs e)
        {
            BolumDoldur();
            DoktorDoldur();
            HastalarıDoldur();
        }

        private void cmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DoktorDoldur();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string bolumID = cmbBolum.SelectedValue.ToString();
                string hastaID = dgvHasta.CurrentRow.Cells[0].Value.ToString();
                string doktorID = lstDoktorlar.SelectedValue.ToString();
                string tarih = dtpTarih.Text;
                string saat = dtpSaat.Text;
                string sorguCumlesi = $"INSERT INTO tblDoktorlar VALUES('{bolumID}','{doktorID}','{hastaID}','{tarih}','{saat}')";
                vt.islem(sorguCumlesi);
                MessageBox.Show("tamamdır");
            }
            catch (Exception) 
            {
                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
