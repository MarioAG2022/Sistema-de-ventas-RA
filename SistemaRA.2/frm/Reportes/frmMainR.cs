using SistemaRA._2.frm.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRA._2.frm.Reportes
{
    public partial class frmMainR : Form
    {
        public frmMainR()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmRepVen m = new frmRepVen();
            m.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmReporteInventario m = new FrmReporteInventario();
            m.Show();
        }

        private void frmMainR_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmReporteInventario m = new FrmReporteInventario();
            m.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmReporteMermas r = new frmReporteMermas();
            r.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmReporteMermas r = new frmReporteMermas();
            r.Show();
        }

        private void lbrventas_Click(object sender, EventArgs e)
        {
            frmRepVen m = new frmRepVen();
            m.Show();
        }
    }
}
