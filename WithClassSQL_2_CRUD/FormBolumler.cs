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
    public partial class FormBolumler : Form
    {

        string sorguCumlesi;
        VeriTabani vt = new VeriTabani();
        string ID;
        public FormBolumler()
        {
            InitializeComponent();
        }

        void Tazele()
        {
            sorguCumlesi = "SELECT*FROM tblBolumler";
            dgvBolumler.DataSource = vt.KayıtListele(sorguCumlesi);
        }
        private void FormBolumler_Load(object sender, EventArgs e)
        {
            Tazele();    
        }

        private void dgvBolumler_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtBolumAd.Text = dgvBolumler.CurrentRow.Cells[0].Value.ToString();
            sorguCumlesi = $"UPDATE tblBolumler SET BolumAd='{txtBolumAd.Text}' WHERE ID='{ID}'";
            vt.islem(sorguCumlesi);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            txtBolumAd.Text = dgvBolumler.CurrentRow.Cells[1].Value.ToString();
            sorguCumlesi = $"UPDATE tblBolumler WHERE ID='{ID}";
            vt.islem(sorguCumlesi);
            Tazele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtBolumAd.Text = dgvBolumler.CurrentRow.Cells[0].Value.ToString();
            sorguCumlesi = $"DELETE tblBolumler WHERE ID='{ID}' ";
            vt.islem(sorguCumlesi);
            Tazele();
        }
    }
}
