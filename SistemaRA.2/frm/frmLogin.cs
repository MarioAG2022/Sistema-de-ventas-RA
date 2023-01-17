using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.Runtime.InteropServices;
using SistemaRA._2.frm;
using SistemaRA._2.Datos;

namespace SistemaRA._2
{
    public partial class Form2 : Form
    {
        
        //String nombre;
        fmain fmain = new fmain();
        frmMain frm = new frmMain();
        conexion cn = new conexion();

        public Form2()
        {
            InitializeComponent();
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button1_Click(object sender, EventArgs e)
        {

            NpgsqlConnection conexion = new NpgsqlConnection();
            string sentencia = "SELECT* FROM usuarios WHERE nombre= '"+txtnombre.Text+"' AND contraseña='"+txtpassword.Text+"' ";
            conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";

            conexion.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(sentencia ,conexion);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);

            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            //nombre = txtnombre.Text;
            //nombreO.Text = txtnombre.Text;

            string user;

            //if (reader.Read())
            if (tabla.Rows.Count == 1)
            {

                //MessageBox.Show("Que pedo");
                //user = reader.GetString(1);
                if (tabla.Rows[0][2].ToString() == "Administrador")
                {
                    frmMain frm1 = new frmMain();
                    MessageBox.Show("Bienvenido '" + txtnombre.Text + "'");
                    
                    //frm1.Show();
                   // string valores = fmain.ConsultarInfo(txtnombre.Text);
                   // MessageBox.Show(valores);
                   String texto = txtnombre.Text;
                    frmMainA m = new frmMainA(texto);
                    m.Show();
                    //variable = "Aver que pedo";
                    //frm.txtUsuario.Text = valores;
                    
                    this.Hide();
                   
                }
                else if(tabla.Rows[0][2].ToString() == "Empleado")
                {
                    String texto = txtnombre.Text;
                    frmMainE frm2 = new frmMainE(texto);
                    MessageBox.Show("Bienvenido '" + txtnombre.Text + "'");
                    frm2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("No se encontro Usuario o la contraseña es equivocada");
            }
            conexion.Close();


            //cn.Consultarid();
        }

        public String nombre(String A)
        {

            String nombre;
            nombre = A;
            return nombre;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            if(txtnombre.Text == "USUARIO")
            {
                txtnombre.Text = "";
                txtnombre.ForeColor = Color.LightGray;
            }
            
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                //txtnombre.Text = "USUARIO";
                txtnombre.ForeColor = Color.DimGray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "CONTRASEÑA")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.LightGray;
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "CONTRASEÑA";
                txtpassword.ForeColor = Color.DimGray;
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncerrar_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nombreO_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
