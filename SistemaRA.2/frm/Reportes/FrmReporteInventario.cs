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

namespace SistemaRA._2.frm.Productos
{
    public partial class FrmReporteInventario : Form
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");
        string razon = "";
        string fecha= "";
        string hora = "";      
        int id = 0;
        int idusuario = 0;
        int codigo = 0;
        conexion conectandose = new conexion();
        frepinv frep = new frepinv();
        public FrmReporteInventario()
        {
            InitializeComponent();
            dataGridViewInv.DataSource = frep.Consultar();
        }

        private void FrmReporteInventario_Load(object sender, EventArgs e)
        {

        }

        private void TxtRMbuscar_TextChanged(object sender, EventArgs e)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";

            conexion.Open();

            if(cmbBuscar.Text == "Por nombre")
            {
                string query = "select idproducto, productos.nombre, precio, descripcion, nmarca, cantidad, estatus, premayoreo from \"productos\",\"marca\" where productos.marca_idmarca = marca.idmarca and nombre like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridViewInv.DataSource = tabla;
                conexion.Close();
            }

            if (cmbBuscar.Text == "Por descripcion")
            {
                string query = "select idproducto, productos.nombre, precio, descripcion, nmarca, cantidad, estatus, premayoreo from \"productos\",\"marca\" where productos.marca_idmarca = marca.idmarca and descripcion like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridViewInv.DataSource = tabla;
                conexion.Close();
            }

            if (cmbBuscar.Text == "Por marca")
            {
                string query = "select idproducto, productos.nombre, precio, descripcion, nmarca, cantidad, estatus, premayoreo from \"productos\",\"marca\" where productos.marca_idmarca = marca.idmarca and nmarca like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridViewInv.DataSource = tabla;
                conexion.Close();
            }



        }

        private void DataGridViewInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewInv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewInv.Columns[e.ColumnIndex].Name == "cantidad")
            {
                try
                {
                    if (Convert.ToInt32(e.Value) > 5)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }

                    if (Convert.ToInt32(e.Value) <= 5 && Convert.ToInt32(e.Value) >= 1)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                    }

                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(e.Value) == null)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
                catch(Exception error)
                {
                    Console.WriteLine("ERROR: " + error.Message);
                }
                

            }
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
