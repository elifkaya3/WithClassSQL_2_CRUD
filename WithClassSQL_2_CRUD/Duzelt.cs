﻿using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WithClassSQL_2_CRUD
{
    public partial class Duzelt : Form
    {
        VeriTabani vt = new VeriTabani();
        SqlConnection bag;
        SqlCommand komut;

        public Duzelt()
        {
            InitializeComponent();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {

            if(vt.KontrolEt(txtTc.Text,txtAd.Text,txtSoyad.Text,txtAdres.Text,cmbCinsiyet.Text)
                {
                string Cinsiyet = cmbCinsiyet.Text == "Kadın" ? "K" : "E";
                vt.Ekle(txtTc.Text, txtAd.Text, txtSoyad.Text, Cinsiyet, txtAdres.Text, txtTelefon.Text, txtMail.Text);
                Doldur();
            }
            else
            {

            }
        }
        void Doldur()
        {
            dgvHastalar.DataSource = vt.HastalariGetir();

        }
        void Aktar()
        {

            txtTc.Text = dgvHastalar.CurrentRow.Cells[1].Value.ToString();
            txtAd.Text = dgvHastalar.CurrentRow.Cells[2].Value.ToString();
            txtSoyad.Text = dgvHastalar.CurrentRow.Cells[3].Value.ToString();
            cmbCinsiyet.Text = dgvHastalar.CurrentRow.Cells[4].Value.ToString() == "K" ? "Kadın" : "Erkek";
            txtAdres.Text = dgvHastalar.CurrentRow.Cells[5].Value.ToString();
            txtTelefon.Text = dgvHastalar.CurrentRow.Cells[6].Value.ToString();
            txtMail.Text = dgvHastalar.CurrentRow.Cells[7].Value.ToString();

        }
        private void Duzelt_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        
        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            vt.Duzelt(txtTc.Text, txtAd.Text, txtSoyad.Text,  cmbCinsiyet.Text,  txtAdres.Text, txtTelefon.Text, txtMail.Text, txtID.Text);
        }

        private void dgvHastalar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Aktar();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            vt.Sil(txtTc.Text,txtAd.Text,txtSoyad.Text, cmbCinsiyet.Text, txtAdres.Text,txtTelefon.Text,txtMail.Text,txtID.Text);
        }
    }
}
