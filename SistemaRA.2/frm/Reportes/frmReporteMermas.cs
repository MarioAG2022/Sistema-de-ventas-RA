
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
using SistemaRA._2.Datos;
namespace SistemaRA._2.frm
{
    public partial class frmReporteMermas : Form
    {
        string razon = "";
        string fecha= "";
        string hora = "";
        string empleado = "";
        int id = 0;
        int perdida = 0;
        int idusuario = 0;
        int codigo = 0;
        conexion conectandose = new conexion();
        ReporteMermas ReporteMermas = new ReporteMermas();
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");
        validar val = new validar();
        public frmReporteMermas()
        {
          
            InitializeComponent();
        
           
            
    
        }

        private void frmReporteMermas_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxRmBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtRMbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewmermaRe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";

            conexion.Open();

        

            if (cbBuscar.Text == "Por producto")
            {
                string query = " select productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detallemerma.cantidad,mermas.hora,productos.precio,productos.precio*detallemerma.cantidad from \"mermas\",\"detallemerma\",\"productos\",\"usuarios\" where mermas.fecha ='" + txtRMbuscar.Text + "' AND mermas.usuarios_idusuario = usuarios.idusuario AND detallemerma.mermas_idmermas = mermas.idmermas AND detallemerma.productos_idproducto = productos.idproducto and productos.nombre like '" + txtEmpleado.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridViewmermaRe.DataSource = tabla;
                conexion.Close();
            }

            if (cbBuscar.Text == "Por Empleado")
            {
                string query = " select productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detallemerma.cantidad,mermas.hora,productos.precio,productos.precio*detallemerma.cantidad from \"mermas\",\"detallemerma\",\"productos\",\"usuarios\" where mermas.fecha ='" + txtRMbuscar.Text + "' AND mermas.usuarios_idusuario = usuarios.idusuario AND detallemerma.mermas_idmermas = mermas.idmermas AND detallemerma.productos_idproducto = productos.idproducto and usuarios.nombre like '" + txtEmpleado.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridViewmermaRe.DataSource = tabla;
                conexion.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtRMbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.fechas(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(txtRMbuscar.Text != "")
            {
                
                dataGridViewmermaRe.DataSource = ReporteMermas.Llenartabla(txtRMbuscar.Text);
                dataGridViewmermaRe.Columns[7].HeaderText = "Total del la Merma";
                double total = 0;
                for (int i = 0; i < dataGridViewmermaRe.RowCount - 1; i++)
                {
                    total += double.Parse(dataGridViewmermaRe.Rows[i].Cells[7].Value.ToString());
                }
                lbtotal.Visible = true;
                lbtotal.Text = Convert.ToString(total);

            }
            else
            {
                MessageBox.Show("No a seleccionado ninguna fecha");
            }
        }
    }
}
