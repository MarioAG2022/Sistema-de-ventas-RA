using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRA._2.frm
{
    public partial class frmMainE : Form
    {
        public frmMainE()
        {
            InitializeComponent();
        }
        public frmMainE(String text)
        {
            InitializeComponent();
            lbnombre.Text = text;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximisar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximisar.Visible = true;
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.Wrapper.Controls.Count > 0)
                this.Wrapper.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Wrapper.Controls.Add(fh);
            this.Wrapper.Tag = fh;
            fh.Show();
        }
        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmProductos());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if(Sidebar.Width == 230)
            {
                Sidebar.Width = 51;
                SidebarWrapper.Width = 60;
            }
            else
            {
                Sidebar.Width = 230;
                SidebarWrapper.Width = 255;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String texto = lbnombre.Text;
            //frmCompras frmcompras = new frmCompras();
            AbrirFormInPanel(new Separados(texto));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String texto = lbnombre.Text;
            //frmCompras frmcompras = new frmCompras();
            AbrirFormInPanel(new frmMermas(texto));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String texto = lbnombre.Text;
            //frmCompras frmcompras = new frmCompras();
            AbrirFormInPanel(new frmVentas(texto));
        }
    }
}
