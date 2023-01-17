using SistemaRA._2.Datos;
using SistemaRA._2.frm.Ventas;
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
    public partial class frmVentas : Form
    {
        fventas frmc = new fventas();
        String fecha;
        String hora;
        int id = 0;
        double dis;
        validar val = new validar();

        public frmVentas()
        {
            InitializeComponent();
        }

        public frmVentas(String text)
        {
            InitializeComponent();
            
            lbnombre.Text = text;
            lbventa.Text = Convert.ToString(frmc.Consultarid());
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            dataGridView1.DataSource = frmc.Consultar(frmc.Consultarid());
            dataGridView1.Columns[0].HeaderText = "CODIGO";
            dataGridView1.Columns[4].HeaderText = "TOTAL";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToShortDateString();
            lbhora.Text = DateTime.Now.ToShortTimeString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {

        }

        private void lbhora_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                int id;
                id = Convert.ToInt32(txtCodigo.Text);
                string[] valores = frmc.ConsultarProducto(id);
                if (valores != null)
                {
                    lbnombrep.Text = valores[0];
                    lbdescripcion.Text = valores[1];
                    lbprecio.Text = valores[2];
                    //txtCodigo.ReadOnly = true;
                    //btnCancelar.Visible = true;
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
            if (txtayuda.Text != "")
            {
                int num;
                //int nota = Convert.ToInt32(txtCompra.Text);
                fecha = DateTime.Now.ToShortDateString();
                hora = DateTime.Now.ToShortTimeString();
                string[] valores = frmc.ConsultarUsuario(lbnombre.Text);
                num = Convert.ToInt32(valores[0]);
                // num = frmc.ConsultarUsuario(frmM.lbnombre.Text);
                frmc.InsertarVenta(fecha,num,hora);
            }
            if (lbventa.Text != "")
            {

                if (txtCodigo.Text != "")
                {
                    
                   if (txtCantidad.Text != "")
                   {
                        int cantidad;
                        cantidad = Convert.ToInt32(txtCantidad.Text);
                        int id;
                        id = Convert.ToInt32(txtCodigo.Text);
                        string[] valores = frmc.ConsultarProducto(id);
                        if (valores != null)
                        {
                            if (frmc.ConsultarExistencia(id) >= 1 && frmc.ConsultarExistencia(id) >= cantidad)
                            {
                                double precio = Convert.ToDouble(lbprecio.Text);
                                double cantidad2 = Convert.ToDouble(txtCantidad.Text);
                                lbpreciot.Text = Convert.ToString(precio * cantidad2);
                                double multiplicacion = Convert.ToDouble(lbpreciot.Text);

                                //////////////////////////////////////////////////7


                                int nota = Convert.ToInt32(lbventa.Text);
                                frmc.insertartotal(nota, multiplicacion);

                                frmc.disminuirStock(id, cantidad);
                                frmc.insertarDVenta(id, nota, cantidad);
                                dataGridView1.DataSource = frmc.Consultar(nota);
                                txtayuda.Clear();
                                txtTotal.Text = frmc.Consultartotal(nota);
                                //lbayuda.Clear();
                                txtCodigo.Clear();
                                txtCantidad.Clear();
                                lbnombrep.Text = "";
                                lbdescripcion.Text = "";
                                lbprecio.Text = "";
                                lbpreciot.Text = "";
                                if (frmc.ConsultarExistencia(id) == 0)
                                {
                                    frmc.debaja(id);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto no se encuentra con la cantidad solicitada");
                            }


                        }
                        else
                        {
                            MessageBox.Show("El producto no esta registrado");
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
                MessageBox.Show("Tiene que hacer una venta compra antes de poder Registrar los productos");
            }
            //if (txtCodigo.Text != "")
            //{
                btnPagar.Visible = true;
            //}
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            frmTPago m = new frmTPago(lbventa.Text,txtTotal.Text);
            txtTotal.Clear();
            m.Show();
            lbventa.Text = Convert.ToString(frmc.Consultarid());
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            int nota = Convert.ToInt32(lbventa.Text);
            dataGridView1.DataSource = frmc.Consultar(nota);
            //this.Refresh();
            btnPagar.Visible = false;
            
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid
            id = Convert.ToInt32(fila.Cells[5].Value);
            dis = Convert.ToDouble(fila.Cells[4].Value);
            btnEliminar.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmc.eliminarRegistro(id);
            int nota = Convert.ToInt32(lbventa.Text);
            dataGridView1.DataSource = frmc.Consultar(nota);
            frmc.actualizartotal(nota, dis);
            String a = Convert.ToString(dis);
            MessageBox.Show("Esta es la venta cancelada´"+dis);
            //txtTotal.Clear();
            txtTotal.Text = frmc.Consultartotal(nota);
            btnEliminar.Visible = false;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }


    }
    
}
