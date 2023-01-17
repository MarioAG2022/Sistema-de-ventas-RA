using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace SistemaRA._2.Datos
{
    class fRegSep
    {
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
        public DataTable Consultar(int id)
        {
            string query = "select idproducto,nombre,descripcion,detalleseparado.cantidad,precio,precio*detalleseparado.cantidad from \"detalleseparado\",\"productos\" where separados_idseparados='" + id + "' AND productos.idproducto=detalleseparado.productos_idproducto";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarSeparados()
        {
            string query = "select idseparados, nombrec, separados.telefono, fechainicial, fechalimite, estatus, nombre from \"separados\",\"usuarios\" where separados.usuarios_idusuario = usuarios.idusuario" ;
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void InsertarSeparado(int nota,String cliente, int usuario,String telefono, String fechaI, String fechaL, String obs, String estatus , String hora,double ant )
        {
            //int num = Convert.ToInt32(ConsultaridSeparados());
            //num = num + 1;
            //int usuario = 1;
            //double ant = 0;
            double preciototal = 0;
            conectado();
            string query = "INSERT INTO separados (idseparados,usuarios_idusuario, telefono,nombrec, fechainicial, fechalimite, estatus, hora, observaciones,total,anticipo) VALUES " +
                "('" + nota + "','" + usuario + "','" + telefono + "','" + cliente + "','" + fechaI + "','" + fechaL + "','" + estatus + "','" + hora + "','" + obs + "','" + preciototal + "','" + ant + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            //MessageBox.Show("Registre datos de el separado");
            //return num;
        }

        public int ConsultaridSeparados()
        {
            conectado();
            string query = "SELECT MAX(idseparados) FROM \"separados\"";
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
            int conversion = Convert.ToInt32(consulta);
            conversion = conversion + 1;

            //MessageBox.Show(consulta);
            desconectado();
            return conversion;

        }

        public String[] ConsultarProducto(int id)
        {
            String[] resultado = null;
            try
            {
                conectado();
                string query = "select nombre,descripcion,precio from \"productos\" where idproducto='" + id + "'";
                NpgsqlCommand conector = new NpgsqlCommand(query, con);
                NpgsqlDataReader registro = conector.ExecuteReader();

                while (registro.Read())
                {
                    string[] valores =
                     {
                    registro["nombre"].ToString(),
                    registro["descripcion"].ToString(),
                    registro["precio"].ToString()


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

        public void insertarDseparado( int id_pro, int cantidad,int nota)
        {
        
            //int id_sep;

           

            //id_sep = Convert.ToInt32(ConsultaridSeparados());
            conectado();
            string query = "INSERT INTO detalleseparado (productos_idproducto,cantidad, separados_idseparados) VALUES " +
             "('" + id_pro + "','" + cantidad + "','" + nota + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }

        public String ConsultaridDseparados()
        {
            conectado();
            string query = "SELECT MAX(iddetalleseparado) FROM \"detalleseparado\"" ;
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


            //MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }

        

        public String consultarPrecioUni()
        {
            conectado();
            string query = "SELECT precio FROM \"productos\" where " ;
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


            //MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }

        public void disminuirStock(int codigo, int cantidad)
        {
            conectado();
            string query = "UPDATE productos SET cantidad=(cantidad - '" + cantidad + "') WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("separado registrado");
        }

        public String consultarAnticipo(int num)
        {
            conectado();
            string query = "SELECT anticipo FROM \"separados\" where idseparados = " + num + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["anticipo"].ToString();
                consulta = tabla;
                
            }


            //MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }
        public String consultarObservacion(int num)
        {
            conectado();
            string query = "SELECT observaciones FROM \"separados\" where idseparados = " + num + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["observaciones"].ToString();
                consulta = tabla;

            }


            //MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }


        public void actualizarSeparados(int num ,String cliente, int anticipo, String telefono, String fechaL, String observ, String estatus)
        {


            conectado();
            string query = "UPDATE separados SET nombrec='" + cliente + "',anticipo='" + anticipo + "',telefono='" + telefono + "',fechalimite='" + fechaL + "', observaciones='" + observ +  "',estatus='" + estatus + "' WHERE idseparados='" + num + "'";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Datos Actualizados");
        }

        public void insertartotal(int codigo, double cantidad)
        {
            conectado();
            String prueba = Convert.ToString("Codigo del producto"+codigo);
            //MessageBox.Show(prueba);
            //cantidad = 100;

            string query = "UPDATE separados SET total=(total + '" + cantidad + "') WHERE idseparados=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Prueba");
        }

        public String ConsultarPrecio(int codigo)
        {
            conectado();
            string query = "SELECT precio FROM \"productos\" WHERE idproducto=" + codigo + " ";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["precio"].ToString();
                consulta = tabla;
                //
            }
            //int conversion = Convert.ToInt32(consulta);
            //conversion = conversion + 1;

            //MessageBox.Show(consulta);
            desconectado();
            return consulta;

        }
        public String Consultartotal(int codigo)
        {
            //int a = 10;
            conectado();
            string query = "SELECT total FROM \"separados\" WHERE idseparados='" + codigo + "' ";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["total"].ToString();
                consulta = tabla;
                //
            }
            //int conversion = Convert.ToInt32(consulta);
            //conversion = conversion + 1;
            //MessageBox.Show("Que pedo");
            //MessageBox.Show("Esto deberia ser el total"+consulta);
            desconectado();
            return consulta;

        }
        public int ConsultarExistencia(int id)
        {
            conectado();
            string query = "SELECT cantidad FROM \"productos\" where idproducto='" + id + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["cantidad"].ToString();
                consulta = tabla;
                //
            }
            int conversion = Convert.ToInt32(consulta);
            //conversion = conversion + 1;

            //MessageBox.Show(consulta);
            desconectado();
            return conversion;

        }
        public void cambiarestatus(int codigo)
        {
            conectado();
            String estatus = "Sin Existencia";
            string query = "UPDATE productos SET estatus='" + estatus + "' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
        public String[] ConsultarUsuario(String nombre)
        {

            conectado();
            string query = "select idusuario  from \"usuarios\" where nombre='" + nombre + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String[] resultado = null;
            while (registro.Read())
            {
                string[] valores =
                 {
                    registro["idusuario"].ToString(),

                };
                resultado = valores;
            }
            desconectado();
            //MessageBox.Show(resultado[0]);
            return resultado;

        }
    }
}
