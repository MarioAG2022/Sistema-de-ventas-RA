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

namespace SistemaRA._2.frm
{
    public partial class frmCompras : Form
    {
        String fecha;
       
        fcompras frmc = new fcompras();
        frmMain frmM = new frmMain();
        validar val = new validar();

        int id = 0;
        




        public frmCompras()
        {
            InitializeComponent();
           

        }
        public frmCompras(String text)
        {
            InitializeComponent();
            lbnombre.Text = text;
            //int num;
            //string[] valores = frmc.ConsultarUsuario(lbnombre.Text);
            //num = Convert.ToInt32(valores[0]);
            lbcompra.Text =Convert.ToString(frmc.Consultarid());
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            //int numero = Convert.ToInt32(lbcompra.Text);
            dataGridView1.DataSource = frmc.Consultar(frmc.Consultarid());
            dataGridView1.Columns[0].HeaderText = "CODIGO";
            dataGridView1.Columns[5].HeaderText = "TOTAL";



        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void lbfecha_Click(object sender, EventArgs e)
        {

        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (txtCodigo.Text != "")
            {
                int id;
                id = Convert.ToInt32(txtCodigo.Text);
                string[] valores = frmc.ConsultarProducto(id);
                if(valores != null)
                {
                    lbnombrep.Text = valores[0];
                    lbdescripcion.Text = valores[1];
                    lbprecio.Text = valores[2];
                    //txtCodigo.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("El producto buscado no esta registrado");
                }
               
            }
            else
            {
                MessageBox.Show("No a Digitano ningun codigo de Producto");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtayuda.Text != "")
            {
                
                //int nota = Convert.ToInt32(txtCompra.Text);
                fecha = DateTime.Now.ToShortDateString();
                string[] valores = frmc.ConsultarUsuario(lbnombre.Text);
                int num = Convert.ToInt32(valores[0]);
                // num = frmc.ConsultarUsuario(frmM.lbnombre.Text);
                frmc.InsertarCompra(fecha, num);
                
                
            }

            if (lbcompra.Text != "")
            {
                
                if (txtCodigo.Text != "")
                {
                    if (txtCantidad.Text != "")
                    {
                       
                        if(txtPCompra.Text != "")
                        {
                            int id;
                            id = Convert.ToInt32(txtCodigo.Text);
                            string[] valores = frmc.ConsultarProducto(id);
                            if (valores != null)
                            {
                                //int id;
                                id = Convert.ToInt32(txtCodigo.Text);
                                int cantidad;
                                int nota = Convert.ToInt32(lbcompra.Text);
                                double precio = Convert.ToDouble(txtPCompra.Text);
                                cantidad = Convert.ToInt32(txtCantidad.Text);
                                frmc.aumentarStock(id, cantidad);
                                //frmc.insertarPCompra(id,precio);
                                frmc.insertarDCompra(id, nota, cantidad, precio);
                                dataGridView1.DataSource = frmc.Consultar(nota);
                                txtayuda.Clear();
                                txtCodigo.Clear();
                                txtCantidad.Clear();
                                txtPCompra.Clear();
                                lbdescripcion.Text = "";
                                lbnombrep.Text = "";
                                lbprecio.Text = "";
                                //lbayuda.Clear();
                                if (frmc.ConsultarExistencia(id) >= 1)
                                {
                                    frmc.cambiarestatus(id);
                                }


                                double total = 0;
                                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                                {
                                    total += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                                }
                                lbtotal.Visible = true;
                                lbtotal.Text = Convert.ToString(total);

                                btnGuardar.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("El producto que intentas insertar no esta registrado");
                            }

                            }
                        else
                        {
                            MessageBox.Show("No a indicado el precio de la compra");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("No a Seleccionado la cantidad de la compra");
                    }
                    
                }
                else
                {
                    MessageBox.Show("No a seleccionado ningun producto a Registrar");
                    
                }
                
            }
            else
            {
                MessageBox.Show("Tiene que hacer una nueva compra antes de poder Registrar los productos");
            }
            
               
            
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid



            id = Convert.ToInt32(fila.Cells[0].Value);
            lbpeliminar.Visible = true;
            lbpeliminar.Text = Convert.ToString(fila.Cells[0].Value);
            //txtCodigo.Text = Convert.ToString(fila.Cells[0].Value);
            txtCodigo.Visible = false;
            btnCancelar.Visible = true;
            btnEliminar.Visible = true;
            //textBox1.Text = Convert.ToString(fila.Cells[1].Value);//optengo el valor de la columna seleccionada

            //cbRol.Text = Convert.ToString(fila.Cells[2].Value);

           // txtContraseña.Text = Convert.ToString(fila.Cells[3].Value);

            //textBox4.Text = Convert.ToString(fila.Cells[4].Value);
        }

        private void txtCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lbcompra.Text =Convert.ToString(frmc.Consultarid());
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            int nota = Convert.ToInt32(lbcompra.Text);
            dataGridView1.DataSource = frmc.Consultar(nota);
            txtPCompra.Clear();
            lbprecio.Text = " ";
            lbtotal.Text = "";
            //this.Refresh();
            MessageBox.Show("Compra Guardada");
            btnGuardar.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(lbpeliminar.Text);
            frmc.eliminarRegistro(a);
            int nota = Convert.ToInt32(lbcompra.Text);
            dataGridView1.DataSource = frmc.Consultar(nota);
            txtCodigo.Clear();
            txtCodigo.Visible = true;
            btnEliminar.Visible = false;
            lbtotal.Text = "";
            
            lbpeliminar.Visible = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid


            txtCodigo.Text = Convert.ToString(fila.Cells[0].Value);
            

            btnEliminar.Visible = true;

           // (fila.Cells[1].Value);//optengo el valor de la columna seleccionada

            //cbRol.Text = Convert.ToString(fila.Cells[2].Value);

            //txtContraseña.Text = Convert.ToString(fila.Cells[3].Value);

            //textBox4.Text = Convert.ToString(fila.Cells[4].Value);
        }

        private void txtPCompra_TextChanged(object sender, EventArgs e)
        {
            if(lbprecio.Text != "")
            {
                if (txtPCompra.Text != "")
                {
                    double a = Convert.ToDouble(txtPCompra.Text);
                    double b = Convert.ToDouble(lbprecio.Text);
                    if (a > b)
                    {
                        MessageBox.Show("El precio de compra no puede ser mayor que el de venta");
                        txtPCompra.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero tienes que buscar un producto");
                txtPCompra.Clear();
            }
            
            

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigo.Visible = true;
            btnEliminar.Visible = false;
            lbpeliminar.Text = "";
            lbpeliminar.Visible = false;
            btnCancelar.Visible = false;
            txtCodigo.Text = "";
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
