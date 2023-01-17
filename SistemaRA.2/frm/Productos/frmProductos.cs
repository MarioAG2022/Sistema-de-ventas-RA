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
using Npgsql;
using NpgsqlTypes;
using SistemaRA._2.frm.Productos;

namespace SistemaRA._2.frm
{
    public partial class frmProductos : Form
    {
        string nombre = "";
        double precio = 0.0;
        double precioM = 0.0;
        string descripcion = "";
        int codigo = 0;
        int marca = 0;




        validar val = new validar();
        string dato1 = string.Empty;
        string dato2 = string.Empty;
        int id = 0;
       

        conexion conectandose = new conexion();
        fproductos fproductos = new fproductos();
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");

        public frmProductos()
        {
            InitializeComponent();
            fproductos.ConsultarMarca(cbMarca);
            dataGridView1.DataSource = fproductos.Consultar();
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[0].HeaderText = "CODIGO";
            dataGridView1.Columns[1].HeaderText = "MARCA";
            dataGridView1.Columns[2].HeaderText = "NOMBRE";
            dataGridView1.Columns[3].HeaderText = "PRECIO";
            dataGridView1.Columns[4].HeaderText = "DESCRIPCION";
            dataGridView1.Columns[5].HeaderText = "CANTIDAD";
            dataGridView1.Columns[6].HeaderText = "ESTATUS";
            dataGridView1.Columns[7].HeaderText = "IMAGEN";
            dataGridView1.Columns[8].HeaderText = "PRECIO MAYOREO";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMarca.SelectedIndex > 0)
            {
                string[] valores = fproductos.ConsultarInfo(cbMarca.Text);
                txtMarca.Text = valores[0];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

           
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
           //try
            //{
              //  btnSeleccionar.openFileDialog

            //}
            //catch
            //{

            //}

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Boton de Registrar
            if (txtCodigo.Text != "" & txtNombre.Text != "" & txtPrecio.Text != "" & txtPrecioM.Text != "" & txtMarca.Text != ""
                & txtDescripcion.Text != "")
            {

                
                    int id;
                    id = Convert.ToInt32(txtCodigo.Text);
                    string[] valores = fproductos.ConsultarProducto(id);
                    if (valores == null)
                    {
                        codigo = Convert.ToInt32(txtCodigo.Text);
                        fproductos.ConsultarProducto(codigo);
                        precio = Convert.ToDouble(txtPrecio.Text);
                        precioM = Convert.ToDouble(txtPrecioM.Text);
                        if (precio > precioM)
                        {

                            nombre = txtNombre.Text;
                            marca = Convert.ToInt32(txtMarca.Text);
                            //rol = textBox2.Text;
                            descripcion = txtDescripcion.Text;

                            //rol = cbRol.Text;


                            fproductos.Insertar(codigo, marca, nombre, precio, descripcion, precioM);
                            txtCodigo.Clear();
                            txtNombre.Clear();
                            txtMarca.Clear();
                            txtDescripcion.Clear();
                            txtPrecio.Clear();
                            txtPrecioM.Clear();
                            dataGridView1.DataSource = fproductos.Consultar();
                            }
                            else
                            {
                                MessageBox.Show("El precio de mayoreo no puede ser mayor ");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Este codigo ya es usado por otro producto");
                    }

                
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //frmBuscar frm1 = new frmBuscar();
            //frm1.Show();
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtMarca.Text != "" && txtPrecio.Text !="" && txtDescripcion.Text != "" && txtPrecioM.Text != "")
            {
                // frmBuscar frmbuscar = new frmBuscar();
                int id = Convert.ToInt32(txtCodigo.Text);
                String nombre = txtNombre.Text;
                int marca = Convert.ToInt32(txtMarca.Text);
                double precio = Convert.ToDouble(txtPrecio.Text);

                string descripcion = txtDescripcion.Text;
                double preciom = Convert.ToDouble(txtPrecioM.Text);
                fproductos.actualizarProducto(id, marca, nombre, precio, descripcion, preciom);
                // DataGridViewRow fila = frmbuscar.dataGridView1.CurrentRow;//Obtengo la fila actualment seleccionada
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtDescripcion.Clear();
                txtPrecioM.Clear();
                txtCodigo.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }



            if (txtCodigo.Text != "" & txtNombre.Text != "" & txtPrecio.Text != ""
               & txtDescripcion.Text != "" & txtPrecioM.Text != "")
            {
               
                //textBox1.Clear();
                //textBox3.Clear();
                //textBox4.Clear();
                //textBox5.Clear();
            }
            

            dataGridView1.DataSource = fproductos.Consultar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmMarca frm2 = new frmMarca();

            frm2.Show();

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //frmBuscar frmbuscar = new frmBuscar();
            int id = Convert.ToInt32(txtCodigo.Text);
            nombre = txtNombre.Text;
            marca = Convert.ToInt32(txtMarca.Text);
            double precio = Convert.ToDouble(txtPrecio.Text); 
            
            string descripcion =txtDescripcion.Text;
            double preciom = Convert.ToInt32(txtPrecioM.Text);
            //DataGridViewRow fila = frmbuscar.dataGridView1.CurrentRow;//Obtengo la fila actualment seleccionada


            if (txtCodigo.Text != "" & txtNombre.Text != "" & txtPrecio.Text != ""
               & txtDescripcion.Text != "" & txtPrecioM.Text != "")
            {
                fproductos.actualizarProducto(id,marca,nombre, precio, descripcion, preciom);
                //textBox1.Clear();
                //textBox3.Clear();
                //textBox4.Clear();
                //textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }

            //frmbuscar.dataGridView1.DataSource = fproductos.Consultar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fproductos.ConsultarMarca(cbMarca);
        }

        private void pboxImagen_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid

            txtCodigo.Text = Convert.ToString(fila.Cells[0].Value);

            cbMarca.Text = Convert.ToString(fila.Cells[1].Value);

            txtNombre.Text = Convert.ToString(fila.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(fila.Cells[3].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells[4].Value);
            lb0.Text = Convert.ToString(fila.Cells[5].Value);
            txtPrecioM.Text = Convert.ToString(fila.Cells[8].Value);
            btnBuscar.Visible = true;
            txtCodigo.ReadOnly = true;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

                NpgsqlConnection conexion = new NpgsqlConnection();
                conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";
                
                conexion.Open();
                
            //MessageBox.Show("Datos Actualizados");
            if (cbRol.Text == "Nombre")
            {

                string query = "select idproducto,nmarca,nombre,precio,descripcion,cantidad,estatus,imagen,premayoreo from \"productos\",\"marca\" where productos.marca_idmarca=marca.idmarca and nombre like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close(); 
            }
            if (cbRol.Text == "Marca")
            {

                string query = "select idproducto,nmarca,nombre,precio,descripcion,cantidad,estatus,imagen,premayoreo from \"productos\",\"marca\" where productos.marca_idmarca=marca.idmarca and nmarca like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }
        }

        private void txtPrecioM_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
