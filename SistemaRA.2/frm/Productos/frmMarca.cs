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

namespace SistemaRA._2.frm.Productos
{
    public partial class frmMarca : Form
    {
        string nombre = "";
        String contacto = "";
        fproductos fproductos = new fproductos();
        public frmMarca()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton de Registrar
            if (txtNombre.Text != "" & txtContacto.Text != "")
            {
                //codigo = Convert.ToInt32(textBox5.Text);
                nombre = txtNombre.Text;
                //rol = textBox2.Text;
                contacto = txtContacto.Text;
                fproductos.InsertarMarca(nombre,contacto);
                txtNombre.Clear();
                txtContacto.Clear();

            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }
            //dataGridView1.DataSource = fusuarios.Consultar();

        }
    }
}
