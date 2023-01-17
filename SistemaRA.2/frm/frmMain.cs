using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SistemaRA._2.frm.Reportes;

namespace SistemaRA._2.frm
{
    public partial class frmMain : Form
    {
       
        
        public frmMain()
        {
            InitializeComponent();
            //Form2 frm = new Form2();
            //lbnombre.Text = frm.txtnombre.Text;
        }

        public frmMain(String text)
        {
            InitializeComponent();
            lbnombre.Text = text;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 60;
            }
            else
                MenuVertical.Width = 250;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {
           
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

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuVertical_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmProductos());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmUsuarios());
        }

        private void panelContenedor_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String texto = lbnombre.Text;
            //frmCompras frmcompras = new frmCompras();
            AbrirFormInPanel(new frmCompras(texto));
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbnombre_Click(object sender, EventArgs e)
        {

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

        private void button6_Click(object sender, EventArgs e)
        {
            String texto = lbnombre.Text;
            //frmCompras frmcompras = new frmCompras();
            AbrirFormInPanel(new Separados(texto));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMainR());
        }
    }
}
