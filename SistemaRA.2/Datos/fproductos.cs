using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Data;

namespace SistemaRA._2.Datos
{
    class fproductos
    {
            //conexion conectandose = new conexion();
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");

            public void conectado()
            {

                //con.ConnectionString = parametros;
                try
                {
                    con.Open();
                    Console.WriteLine("Exito");
                }
                catch (Exception error)
                {
                    Console.WriteLine("ERROR contacte con el soporte: " + error.Message);
                }

            }
            public void desconectado()
            {

                //con.ConnectionString = parametros;
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    else
                    {
                        Console.WriteLine("ERROR no estas conecatado la BD");
                    }

                }
                catch (Exception error)
                {
                    Console.WriteLine("Contacte con el soporte ERROR: " + error.Message);
                }

            }

            public DataTable Consultar()
            {
                string query = "select idproducto,nmarca,nombre,precio,descripcion,cantidad,estatus,imagen,premayoreo from \"productos\",\"marca\" where productos.marca_idmarca=marca.idmarca";
                NpgsqlCommand conector = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }

            public void Insertar(int codigo,int marca,String nombre, double precio, String descripcion,double premayoreo)
            {
                conectado();
                int cantidad = 0;
                string estatus = "Sin Exitstencia";
                string query = "INSERT INTO productos (idproducto,marca_idmarca,nombre,precio,descripcion,cantidad,estatus,premayoreo) VALUES " +
                    "('" + codigo + "','"+ marca +"','" + nombre + "','" + precio + "','" + descripcion + "','" + cantidad + "','" + estatus + "','" + premayoreo + "')";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                ejecutor.ExecuteNonQuery();
                desconectado();

                MessageBox.Show("Producto Registrado");

            }
        public void eliminarRegistro(int id)
            {
                conectado();
                string query = "DELETE FROM usuarios WHERE idusuario=" + id + "";
                NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
                ejecutor.ExecuteNonQuery();
                desconectado();

                MessageBox.Show("Datos Eliminados");
            }
           
        public void ConsultarMarca(ComboBox cb)
        {
            cb.Items.Clear();
            conectado();
            string query = "select nmarca from \"marca\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            while (registro.Read())
            {
                cb.Items.Add(registro["nmarca"].ToString());
            }
            desconectado();
            cb.Items.Insert(0, "---Seleccione Marca----");
            cb.SelectedIndex = 0;

        }
        public String[] ConsultarInfo(String nombre)
        {
            
            conectado();
            string query = "select idmarca from \"marca\" where nmarca='"+nombre+"'" ;
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String[] resultado = null;
            while (registro.Read())
            {
                string[] valores =
                 {
                    registro["idmarca"].ToString()

                    
                };
                resultado = valores;
            }
            desconectado();
            return resultado;
            
            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;

        }
        public void InsertarMarca(String nombre, String contacto)
        {
            conectado();

            string query = "INSERT INTO marca (nmarca,contacto) VALUES " +
                "('" + nombre + "','" + contacto + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            MessageBox.Show("Marca Registrada");

        }
        public void actualizarProducto(int codigo, int marca, string nombre, double precio, string descripcion, double preciom)
        {
            int id = 22;
            conectado();
            string query = "UPDATE productos SET marca_idmarca='" + marca + "',nombre='" + nombre + "',precio='" + precio + "', descripcion='" + descripcion + "',premayoreo='" + preciom + "' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Datos Actualizados");
        }
        //public DataTable consultaDinamica(string id,DataGridView dgv)
        //{
        //  try
        //{
        //  conectado();
        //string query = "Select * from productos where idproducto like '" + id + "%'";
        //NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
        //NpgsqlDataAdapter datos = new NpgsqlDataAdapter(ejecutor);
        //DataTable tabla = new DataTable();
        //datos.Fill(tabla);
        //dgv.DataSource = tabla;
        //desconectado();
        //return tabla;
        //MessageBox.Show("Datos Actualizados");
        //}
        //catch (Exception error)
        //{
        //Console.WriteLine("ERROR contacte con el soporte: " + error.Message);
        //}
        //}
        public String[] ConsultarProducto(int id)
        {
            String[] resultado = null;
            try
            {
                conectado();
                string query = "select nombre from \"productos\" where idproducto='" + id + "'";
                NpgsqlCommand conector = new NpgsqlCommand(query, con);
                NpgsqlDataReader registro = conector.ExecuteReader();

                while (registro.Read())
                {
                    string[] valores =
                     {
                    registro["nombre"].ToString()
                   


                };
                    resultado = valores;
                }
                desconectado();
            }
            catch (Exception error)
            {
                Console.WriteLine("El producto que busca no esta registrado: " + error.Message);
            }

            return resultado;

            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;

        }
    }
}
