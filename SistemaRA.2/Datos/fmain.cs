using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NpgsqlTypes;
using System.Threading.Tasks;

namespace SistemaRA._2.Datos
{
    class fmain
    {
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
        public String ConsultarInfo(String nombre)
        {

            conectado();
            string query = "select idusuario from \"usuarios\" where nombre='" + nombre + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String resultado = "Pues aver";
            while (registro.Read())
            {
                string valores = registro["idusuario"].ToString();
              
                resultado = valores;
            }
            desconectado();
            return resultado;

            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;

        }
    }
}
