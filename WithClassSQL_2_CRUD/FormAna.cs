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

        public FormAna()
        {
            InitializeComponent();
        }
        void Doldur()
        {
            
            dgvHastalar.DataSource =vt.HastalariGetir(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
           
        }

        private void FormAna_Activated(object sender, EventArgs e)
        {
            Doldur();
        }

        private void FormAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            Duzelt formYeni = new Duzelt();
            formYeni.Show();
        }
    }
}
