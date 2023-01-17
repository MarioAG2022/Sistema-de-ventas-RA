using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;

namespace SistemaRA._2.Datos
{
    class fusuarios
    {
        //conexion conectandose = new conexion();
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");

        public void conectado()
        {

            //con.ConnectionString = parametros;
            try
            {
                con.Open();
                //Console.WriteLine("Exito");
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
            string query = "select * from \"usuarios\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void Insertar(String nombre, String rol, String contraseña, String telefono)
        {
            conectado();

            string query = "INSERT INTO usuarios (nombre,rol,contraseña,telefono) VALUES " +
                "('" + nombre + "','" + rol + "','" + contraseña + "','" + telefono + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            MessageBox.Show("Empleado Registrado");

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
        public void actualizarRegistro(int codigo, String nombre, String rol, String contraseña, String telefono)
        {
            conectado();
            string query = "UPDATE usuarios SET nombre='" + nombre + "',rol='" + rol + "',contraseña='" + contraseña + "',telefono='" + telefono + "' WHERE idusuario=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Datos Actualizados");
        }
        public String[] ConsultarProducto(String id)
        {
            String[] resultado = null;
            try
            {
                conectado();
                string query = "select nombre from \"usuarios\" where nombre='" + id + "'";
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
