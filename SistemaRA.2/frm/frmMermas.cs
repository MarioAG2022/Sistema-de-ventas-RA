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
    public partial class frmMermas : Form
    {
        String fecha;
        String hora;
        fmermas frmc = new fmermas();
        int id = 0;
        double dis;
        validar val = new validar();
        public frmMermas()
        {
            InitializeComponent();
        }
        public frmMermas(String text)
        {
            InitializeComponent();
            lbnombre.Text = text;
            txtmerma.Text = Convert.ToString(frmc.Consultarid());
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            dataGridViewmerma.DataSource = frmc.Consultar(frmc.Consultarid());
            dataGridViewmerma.Columns[0].Visible = false;
            dataGridViewmerma.Columns[4].HeaderText = "TOTAL";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMermas_Load(object sender, EventArgs e)
        {

        }

        private void lbfecha_Click(object sender, EventArgs e)
        {
            //lbfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtmermas1.Text != "")
            {
                int id;
                id = Convert.ToInt32(txtmermas1.Text);
                
                string[] valores = frmc.ConsultarProducto(id);
                if (valores != null)
                {
                    textnombreNom5.Text = valores[0];
                    txtmermadescripcion3.Text = valores[1];
                    lbprecio.Text = valores[2];
                }
                else
                {
                    MessageBox.Show("El producto buscado no esta registrado");
                }
            }
            else {
                MessageBox.Show("Inserte Codigo !Por Favor¡");
            }

        }

        private void btnmerma1_Click(object sender, EventArgs e)
        {
            int num;
            if (txtayuda.Text != "")
            {
                if (txtRazonmerma4.Text != "")
                {
                    //MessageBox.Show("que pedo");
                    //int nota = Convert.ToInt32(txtmerma.Text);
                    String razon = txtRazonmerma4.Text;
                    string[] valores = frmc.ConsultarUsuario(lbnombre.Text);
                    num = Convert.ToInt32(valores[0]);
                    fecha = DateTime.Now.ToShortDateString();
                    hora = DateTime.Now.ToShortTimeString();
                    frmc.InsertarMerma(fecha, hora, razon, num);
                }
                else
                {
                    MessageBox.Show("No se le asignado una Razon a la merma");
                }
            }



            //////////////////////////////////////////////
            if (txtRazonmerma4.Text != "")
            {
                if (txtmerma.Text != "")
                {
                    if (txtmermas1.Text != "")
                    {
                        if (txtcantidad2.Text != "")
                        {
                            if(lbprecio.Text != "")
                            {
                                int id;
                                int cantidad;
                                cantidad = Convert.ToInt32(txtcantidad2.Text);
                                id = Convert.ToInt32(txtmermas1.Text);
                                if (frmc.ConsultarExistencia(id) >= 1 && frmc.ConsultarExistencia(id) >= cantidad)
                                {
                                    double precio = Convert.ToDouble(lbprecio.Text);
                                    double cantidad2 = Convert.ToDouble(txtcantidad2.Text);
                                    lbpreciot.Text = Convert.ToString(precio * cantidad2);
                                    double multiplicacion = Convert.ToDouble(lbpreciot.Text);

                                    int nota = Convert.ToInt32(txtmerma.Text);
                                    frmc.insertartotal(nota, multiplicacion);


                                    String razon = txtRazonmerma4.Text;
                                    frmc.actualizarRegistroMer(id, cantidad);
                                    frmc.insertarDMerma(id, nota, cantidad);
                                    dataGridViewmerma.DataSource = frmc.Consultar(nota);
                                    txtayuda.Clear();
                                    txtTotal.Text = frmc.Consultartotal(nota);
                                    if (frmc.ConsultarExistencia(id) == 0)
                                    {
                                        frmc.debaja(id);
                                    }
                                    txtcantidad2.Clear();
                                    txtmermas1.Clear();
                                    textnombreNom5.Clear();
                                    txtmermadescripcion3.Clear();
                                    lbprecio.Text = "";
                                    btnGuardar.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("El producto no se encuentra con la cantidad solicitada");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se a buscado el producto");
                            }
                            
                            ////////////////////////////////////////


                        }
                        else
                        {
                            MessageBox.Show("Inserte cantidad !Por Favor¡");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No a seleccionado ningun producto a Registrar");
                    }
                }
                else
                {
                    MessageBox.Show("Tiene que hacer una nueva merma antes de registrar un producto ");
                }
            }
            
        }

        private void btnmerma2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtmerma_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            //label12.Text = DateTime.Now.ToShortTimeString();
        }

        private void txtmerma_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToShortDateString();
            label12.Text = DateTime.Now.ToShortTimeString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtTotal.Clear();
            txtmerma.Text = Convert.ToString(frmc.Consultarid());
            txtRazonmerma4.Clear();
            txtayuda.Text = Convert.ToString(frmc.Consultarid());
            int nota = Convert.ToInt32(txtmerma.Text);
            dataGridViewmerma.DataSource = frmc.Consultar(nota);
            btnGuardar.Visible = false;
            
        }

        private void textnombreNom5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewmerma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewmerma.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid
            id = Convert.ToInt32(fila.Cells[0].Value);
            dis = Convert.ToDouble(fila.Cells[4].Value);
            btnEliminar.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmc.eliminarRegistro(id);
            int nota = Convert.ToInt32(txtmerma.Text);
            dataGridViewmerma.DataSource = frmc.Consultar(nota);
            frmc.actualizartotal(nota, dis);
            //txtTotal.Clear();
            txtTotal.Text = frmc.Consultartotal(nota);
            btnEliminar.Visible = false;
        }

        private void txtRazonmerma4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtmermas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtcantidad2_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }
    }
}
