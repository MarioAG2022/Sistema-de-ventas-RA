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
using SistemaRA._2.Datos;
using NpgsqlTypes;


namespace SistemaRA._2.frm
{
    public partial class Separados : Form
    {
        fRegSep frmc = new fRegSep();
        RegistrarSeparado sep = new RegistrarSeparado();
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");
        public Separados()
        {
            InitializeComponent();

            dataGridView1.DataSource = frmc.ConsultarSeparados();
        }
        public Separados(String nombre)
        {
            InitializeComponent();
            lbnombre.Text = nombre;

            dataGridView1.DataSource = frmc.ConsultarSeparados();
            dataGridView1.Columns[0].HeaderText = "Numero de Separado";
            dataGridView1.Columns[1].HeaderText = "Nommbre Cliente";
            dataGridView1.Columns[2].HeaderText = "Telefono";
            dataGridView1.Columns[3].HeaderText = "Fecha de Registro";
            dataGridView1.Columns[4].HeaderText = "Fecha de Vencimiento";
            dataGridView1.Columns[5].HeaderText = "Estatus";
        }

        private void Separados_Load(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid
            int num;
            num = Convert.ToInt32(fila.Cells[0].Value);
            sep.nota.Text = Convert.ToString(fila.Cells[0].Value);
            sep.textcliente.Text = Convert.ToString(fila.Cells[1].Value);
            sep.txttelefono.Text = Convert.ToString(fila.Cells[2].Value);
            sep.lbfecha.Text = Convert.ToString(fila.Cells[3].Value);
            sep.txtfechaL.Text = Convert.ToString(fila.Cells[4].Value);
            sep.comboBox1.Text = Convert.ToString(fila.Cells[5].Value);
            sep.dataGridView1.DataSource = frmc.Consultar(num);
            double a =Convert.ToDouble(frmc.consultarAnticipo(num));
            double b = Convert.ToDouble(frmc.Consultartotal(num));
            double c = b - a;
            String d = Convert.ToString(c);
            sep.txtRPagar.Text = d;
            sep.txtanticipo.Text = frmc.consultarAnticipo(num);
            dataGridView1.DataSource = frmc.ConsultarSeparados();
            sep.txtpreto.Text = frmc.Consultartotal(num);
            sep.txtobs.Text = frmc.consultarObservacion(num);
            sep.txtayuda.Text = "";
            sep.button6.Visible = true;
            sep.btnCancelar.Visible = true;
            sep.Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            sep.lbnombre.Text=lbnombre.Text;
            sep.nota.Text = Convert.ToString(frmc.ConsultaridSeparados());
            //sep.iconcerrar.Visible = false;
            sep.Show();
            //this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";

            conexion.Open();

            if (cbSeleccionar.Text == "Por Cliente")
            {

                string query = "select idseparados, nombrec, separados.telefono, fechainicial, fechalimite, estatus, nombre from \"separados\",\"usuarios\" where separados.usuarios_idusuario = usuarios.idusuario  and nombrec like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }

            if (cbSeleccionar.Text == "Por Fecha Limite")
            {
                string query = "select idseparados, nombrec, separados.telefono, fechainicial, fechalimite, estatus, nombre from \"separados\",\"usuarios\" where separados.usuarios_idusuario = usuarios.idusuario  and fechalimite like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }
            if (cbSeleccionar.Text == "Por Fecha de Registro")
            {
                string query = "select idseparados, nombrec, separados.telefono, fechainicial, fechalimite, estatus, nombre from \"separados\",\"usuarios\" where separados.usuarios_idusuario = usuarios.idusuario  and fechainicial like '" + txtBuscar.Text + "%'";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }

        }
    }
}
