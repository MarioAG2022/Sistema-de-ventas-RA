using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using SistemaRA._2.frm;

namespace SistemaRA._2.Datos
{
    class conexion
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
                if (con.State == ConnectionState.Open) {
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
    }
}
