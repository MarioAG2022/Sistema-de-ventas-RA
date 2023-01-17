using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRA._2.Datos;
using System.Runtime.InteropServices;

namespace SistemaRA._2.frm
{
    public partial class RegistrarSeparado : Form
    {

        String fecha;

        fRegSep frmc = new fRegSep();
        //Separados frms = new Separados();
        validar val = new validar();


        public RegistrarSeparado()
        {
            InitializeComponent();
            //nota.Text = Convert.ToString(frmc.ConsultaridSeparados());
            txtayuda.Text = Convert.ToString(frmc.ConsultaridSeparados());
        }
        public RegistrarSeparado(String nombre)
        {
            InitializeComponent();
            lbnombre.Text = nombre;
            //.Text = Convert.ToString(frmc.ConsultaridSeparados());
            //txtayuda.Text = Convert.ToString(frmc.ConsultaridSeparados());

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToShortDateString();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Lbhora_Click(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToShortTimeString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (txtayuda.Text != "")
            {
                if (textcliente.Text != "" && txtanticipo.Text != "" && txttelefono.Text != "" && txtfechaL.Text != "" && comboBox1.Text != "")
                {
                    String cliente = textcliente.Text;
                    double anticipo = Convert.ToDouble(txtanticipo.Text);
                    String telefono = txttelefono.Text;
                    string[] valores = frmc.ConsultarUsuario(lbnombre.Text);
                    int a = Convert.ToInt32(nota.Text);
                    int num = Convert.ToInt32(valores[0]);
                    String fechaI = lbfecha.Text;
                    String fechaL = txtfechaL.Text;
                    String obs = txtobs.Text;
                    String estatus = comboBox1.Text;
                    String hora = lbhora.Text;
                    frmc.InsertarSeparado(a, cliente, num, telefono, fechaI, fechaL, obs, estatus, hora, anticipo);

                }
                else
                {
                    MessageBox.Show("Faltan datos del separado");
                }
                

            }
            if (textcliente.Text != "" && txtanticipo.Text != "" && txttelefono.Text != "" && txtfechaL.Text != "" && comboBox1.Text != "")
            {
                if (txtidpro.Text != "")
                {
                    if (txtcant.Text != "")
                    {

                        //int id;

                        //id = Convert.ToInt32(txtCodigo.Text);
                        //int cantidad;
                        //int nota = Convert.ToInt32(lbcompra.Text);
                        //double precio = Convert.ToDouble(txtPCompra.Text);
                        //cantidad = Convert.ToInt32(txtCantidad.Text);
                        //frmc.aumentarStock(id, cantidad);
                        //frmc.insertarPCompra(id,precio);
                        //frmc.insertarDCompra(id, nota, cantidad, precio);
                        //dataGridView1.DataSource = frmc.Consultar(nota);
                        //txtayuda.Clear();
                        //txtCodigo.Clear();
                        //txtCantidad.Clear();
                        //lbdescripcion.Text = "";
                        //lbnombrep.Text = "";
                        //lbayuda.Clear();

                       

                        int id = Convert.ToInt32(txtidpro.Text);
                        //precio = frmc.ConsultarPrecio(id);
                        //txtpre.Text = precio;
                        string[] valores = frmc.ConsultarProducto(id);
                        if (valores != null)
                        {
                            int id_pro = Convert.ToInt32(txtidpro.Text);
                            int cantidad = Convert.ToInt32(txtcant.Text);
                            if (frmc.ConsultarExistencia(id_pro) >= cantidad)
                            {
                                double precio = Convert.ToDouble(txtpre.Text);
                                double cantidad2 = Convert.ToDouble(txtcant.Text);
                                txtPTotal.Text = Convert.ToString(precio * cantidad2);
                                double multiplicacion = Convert.ToDouble(txtPTotal.Text);
                                int num = Convert.ToInt32(nota.Text);
                                frmc.insertartotal(num, multiplicacion);

                                int ticket = Convert.ToInt32(nota.Text);
                                frmc.insertarDseparado(id_pro, cantidad, ticket);
                                frmc.disminuirStock(id_pro, cantidad);
                                dataGridView1.DataSource = frmc.Consultar(num);

                                double cant;
                                cant = Convert.ToDouble(txtcant.Text);
                                double total = Convert.ToDouble(txtpre.Text);
                                cant = cant * total;

                                txtidpro.Clear();
                                txtDescripcion.Clear();
                                txtnompro.Clear();
                                txtpre.Clear();
                                txtcant.Clear();
                                txtayuda.Clear();
                                txtpreto.Text = frmc.Consultartotal(num);

                                double a = Convert.ToDouble(txtPTotal.Text);
                                double b = Convert.ToDouble(txtanticipo.Text);
                                double suma = a - b;

                                btnGuardar.Visible = true;
                                txtRPagar.Text = Convert.ToString(suma);

                            }
                            else
                            {
                                MessageBox.Show("No queda suficiente producto ");
                            }


                            if (frmc.ConsultarExistencia(id_pro) >= 1)
                            {
                                frmc.cambiarestatus(id_pro);
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



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            nota.Text = Convert.ToString(frmc.ConsultaridSeparados());
            txtayuda.Text = Convert.ToString(frmc.ConsultaridSeparados());
            int b = Convert.ToInt32(nota.Text);
            dataGridView1.DataSource = frmc.Consultar(b);
            textcliente.Clear();
            txttelefono.Clear();
            txtobs.Clear();
            lbfecha.Text = DateTime.Now.ToShortDateString();
            txtfechaL.Clear();
            //this.Refresh();
            txtpreto.Clear();
            txtanticipo.Clear();
            txtRPagar.Clear();

            btnGuardar.Visible = false;


        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToShortDateString();
            lbhora.Text = DateTime.Now.ToShortTimeString();
        }

        private void Nota_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarSeparado_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(nota.Text);
            String cliente = textcliente.Text;
            int anticipo = Convert.ToInt32(txtanticipo.Text);
            String telefono =txttelefono.Text;
            String fechaL = txtfechaL.Text;
            String obs = txtobs.Text;
            String estatus = comboBox1.Text;
            frmc.actualizarSeparados(num ,cliente, anticipo, telefono,  fechaL, obs, estatus);
            nota.Text = Convert.ToString(frmc.ConsultaridSeparados());
            txtayuda.Text = Convert.ToString(frmc.ConsultaridSeparados());
            int b = Convert.ToInt32(nota.Text);
            dataGridView1.DataSource = frmc.Consultar(b);
            textcliente.Clear();
            txttelefono.Clear();
            txtobs.Clear();
            lbfecha.Text = DateTime.Now.ToShortDateString();
            txtfechaL.Clear();
            //this.Refresh();
            txtpreto.Clear();
            txtanticipo.Clear();
            txtRPagar.Clear();
            button6.Visible = false;
            btnCancelar.Visible = false;
            //frms.dataGridView1.DataSource = frmc.ConsultarSeparados();
        }

        private void Textcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (txtidpro.Text != "")
            {
                int id;
                String precio;
                String preciototal;
                id = Convert.ToInt32(txtidpro.Text);
                //precio = frmc.ConsultarPrecio(id);
                //txtpre.Text = precio;
                string[] valores = frmc.ConsultarProducto(id);
                if (valores != null)
                {
                    txtnompro.Text = valores[0];
                    txtDescripcion.Text = valores[1];
                    txtpre.Text = valores[2];
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

        private void txtidpro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Hide();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfechaL_TextChanged(object sender, EventArgs e)
        {
             validar val = new validar();
        }

        private void txtfechaL_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.fechas(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button6.Visible = false;
            btnCancelar.Visible = false;
            nota.Text = Convert.ToString(frmc.ConsultaridSeparados());
            txtayuda.Text = Convert.ToString(frmc.ConsultaridSeparados());
            int b = Convert.ToInt32(nota.Text);
            dataGridView1.DataSource = frmc.Consultar(b);
            textcliente.Clear();
            txttelefono.Clear();
            txtobs.Clear();
            lbfecha.Text = DateTime.Now.ToShortDateString();
            txtfechaL.Clear();
            //this.Refresh();
            txtpreto.Clear();
            txtanticipo.Clear();
            txtRPagar.Clear();
            this.Hide();
        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtidpro_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtcant_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtpre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }

        private void txtPTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpreto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.NumerosDecimales(e);
        }

        private void txtanticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.NumerosDecimales(e);
        }
    }
}
