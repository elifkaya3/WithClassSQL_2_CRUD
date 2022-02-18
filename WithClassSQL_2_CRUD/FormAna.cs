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
    public partial class FormAna : Form
    {
        SqlConnection bag;
        VeriTabani vt = new VeriTabani();
        string sorguCumlesi;

        public FormAna()
        {
            InitializeComponent();
        }
        void Doldur()
        {
            sorguCumlesi = "SELECT * FROM tblBolumler ";
            dgvHastalar.DataSource =vt.KayıtListele(sorguCumlesi);
            dgvHastalar.Columns[0].Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            sorguCumlesi = "SELECT * FROM tblHastalar";
            dgvHastalar.DataSource = vt.KayıtListele(sorguCumlesi);

        }

        private void FormAna_Activated(object sender, EventArgs e)
        {
            Doldur();
        }

        private void FormAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /*private void btnDuzelt_Click(object sender, EventArgs e)
        {

            //FormHastalar formduzelt = new FormHastalar();
            //formduzelt.Show();
        }*/

        private void btnHastalar_Click(object sender, EventArgs e)
        {
            FormHastalar formhst = new FormHastalar();
            formhst.Show();
            this.Hide();
        }

        private void btnBolumler_Click(object sender, EventArgs e)
        {
            FormBolumler formhst = new FormBolumler();
            formhst.Show();
        }
    }
}
