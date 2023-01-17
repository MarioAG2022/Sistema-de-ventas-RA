using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Data;

namespace SistemaRA._2.Datos
{
    class frepven
    {
        //string parametros = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";
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
                Console.WriteLine("ERROR: " + error.Message);
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
        public String Consultarid()
        {
            conectado();
            string query = "SELECT MAX(idusuario) FROM \"usuarios\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["MAX"].ToString();
                consulta = tabla;
                //
            }


            MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }
        public int Fecha(String id)
        {
            String[] resultado = null;
            //resultado[0] ="Aver aver que paso";
            int validacion = 0; 
            try
            {
                conectado();
                string query = "select idventa from \"ventas\" where fecha='" + id + "'";
                NpgsqlCommand conector = new NpgsqlCommand(query, con);
                NpgsqlDataReader registro = conector.ExecuteReader();

                while (registro.Read())
                {
                    string[] valores =
                     {
                    registro["idventa"].ToString(),

                    

                };
                    validacion = 1;
                    resultado = valores;
                }
                desconectado();
            }
            catch (Exception error)
            {
                Console.WriteLine("El producto que busca no esta registrado: " + error.Message);
            }

            return validacion;

            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;

        }
        public DataTable Llenartabla(String fecha)
        {
                string query = "select  productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detalleventa.cantidad,ventas.hora,ventas.tipodepago,productos.precio,productos.precio*detalleventa.cantidad from \"ventas\",\"detalleventa\",\"productos\",\"usuarios\" where ventas.fecha ='" + fecha + "' AND ventas.usuarios_idusuario = usuarios.idusuario AND detalleventa.ventas_idventas = ventas.idventas AND detalleventa.productos_idproducto = productos.idproducto";

                //"+
                //"AND ventas.usuarios_idusuario = usuarios.idusuario" +
                //"AND detalleventa.ventas_idventas = ventas.idventas" +
                //"AND detalleventa.productos_idproducto = productos.idproducto";
                NpgsqlCommand conector = new NpgsqlCommand(query, con);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            
            return tabla;
            
        }
        

    }
}
