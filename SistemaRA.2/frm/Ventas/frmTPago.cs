using SistemaRA._2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRA._2.frm.Ventas
{
    public partial class frmTPago : Form
    {
        public frmTPago()
        {
            InitializeComponent();
        }
        public frmTPago(String id,String pago)
        {
            InitializeComponent();
            txtVenta.Text = id;
            txtPago.Text = pago;
        }
        private void frmTPago_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String efectivo ="Efectivo";
            int id = Convert.ToInt32(txtVenta.Text);
            fventas frm = new fventas();
            frm.tipodepago(id, efectivo);
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String efectivo = "Tarjeta";
            int id = Convert.ToInt32(txtVenta.Text);
            fventas frm = new fventas();
            frm.tipodepago(id, efectivo);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
