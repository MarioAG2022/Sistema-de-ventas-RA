using Npgsql;
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
using NpgsqlTypes;

namespace SistemaRA._2.frm.Reportes
{
    public partial class frmRepVen : Form
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");
        frepven frm = new frepven();
        validar val = new validar();
        public frmRepVen()
        {
            InitializeComponent();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //5

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(txtCaja.Text != "")
            {
                double a = Convert.ToDouble(txtCaja.Text);
                txtTotal.Text = Convert.ToString(a);
            }
            if(txtBuscar.Text != "")
            {
                //if (frm.Fecha(txtBuscar.Text) != 0)
                //{
                    dataGridView1.DataSource = frm.Llenartabla(txtBuscar.Text);
                    dataGridView1.Columns[0].HeaderText = "CODIGO";
                    dataGridView1.Columns[1].HeaderText = "NOMBRE";
                    dataGridView1.Columns[2].HeaderText = "DESCRIPCION";
                    dataGridView1.Columns[3].HeaderText = "EMPLEADO";
                    dataGridView1.Columns[4].HeaderText = "CANTIDAD";
                    dataGridView1.Columns[5].HeaderText = "HORA";
                    dataGridView1.Columns[6].HeaderText = "Tipo de Pago";
                    dataGridView1.Columns[7].HeaderText = "Precio";
                    dataGridView1.Columns[8].HeaderText = "TOTAL DE LA VENTA";
                    double total = 0;
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        total += double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    }
                    txtTotal.Text = Convert.ToString(total);
                //}
                //else
                //{
                  //  Console.Write("No se realizo ninguna venta en esa fecha");
                //}
            }
            else
            {
                MessageBox.Show("No se selecionado la fecha que se quiere el reporte");
            }
            

             


            
           

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCaja.Text != "" && txtContado.Text != "")
            {
                double b = Convert.ToDouble(txtTotal.Text);
                double a = Convert.ToDouble(txtCaja.Text);
                double c = Convert.ToDouble(txtContado.Text);
                double d = (b+a)- c;
                lbtotal.Text = Convert.ToString(d);
            }
            else
            {
                MessageBox.Show("No a designado el dinero de lla caja  o el contado");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";

            conexion.Open();

            if (cbBuscar.Text == "Por nombre")
            {
                
                string query = "select  productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detalleventa.cantidad,ventas.hora,ventas.tipodepago,productos.precio,productos.precio*detalleventa.cantidad from \"ventas\",\"detalleventa\",\"productos\",\"usuarios\" where ventas.fecha ='" + txtBuscar.Text + "' AND ventas.usuarios_idusuario = usuarios.idusuario AND detalleventa.ventas_idventas = ventas.idventas AND detalleventa.productos_idproducto = productos.idproducto and productos.nombre like '" + txtBusqueda.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }

            if (cbBuscar.Text == "Por descripcion")
            {
                string query = "select  productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detalleventa.cantidad,ventas.hora,ventas.tipodepago,productos.precio,productos.precio*detalleventa.cantidad from \"ventas\",\"detalleventa\",\"productos\",\"usuarios\" where ventas.fecha ='" + txtBuscar.Text + "' AND ventas.usuarios_idusuario = usuarios.idusuario AND detalleventa.ventas_idventas = ventas.idventas AND detalleventa.productos_idproducto = productos.idproducto and productos.descripcion like '" + txtBusqueda.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }

            if (cbBuscar.Text == "Por Empleado")
            {
                string query = "select  productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detalleventa.cantidad,ventas.hora,ventas.tipodepago,productos.precio,productos.precio*detalleventa.cantidad from \"ventas\",\"detalleventa\",\"productos\",\"usuarios\" where ventas.fecha ='" + txtBuscar.Text + "' AND ventas.usuarios_idusuario = usuarios.idusuario AND detalleventa.ventas_idventas = ventas.idventas AND detalleventa.productos_idproducto = productos.idproducto and usuarios.nombre like '" + txtBusqueda.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }


        }

        private void frmRepVen_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.fechas(e);
        }

        private void txtCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }

        private void txtContado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContado_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }
    }
}
