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
    class fmermas
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
        public DataTable Consultar(int id)
        {
            string query = "select iddetallemerma,nombre,detallemerma.cantidad,precio,precio*detallemerma.cantidad from \"detallemerma\",\"productos\" where mermas_idmermas='" + id + "' AND productos.idproducto=detallemerma.productos_idproducto";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public void actualizarRegistroMer(int codigo, int cantidad)
        {
            conectado();
            string query = "UPDATE productos SET cantidad=(cantidad - '" + cantidad + "') WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Merma Realizada");
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
        public void InsertarMerma(String fecha, String hora, String razon,int usuario)
        {
            int total = 0;
                     
            int compra;
            //int usuario = Convert.ToInt32(ConsultarUsuario());

            compra = Convert.ToInt32(Consultarid());
            //compra = compra + 1;
           
            conectado();
            string query = "INSERT INTO mermas (idmermas,usuarios_idusuario,fecha,hora,razon,preciototal) VALUES " +
                "('" + compra + "','" + usuario + "','" + fecha + "','" + hora + "','" + razon + "','" + total + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            String pt;
            pt = Convert.ToString(compra);
            //MessageBox.Show("El id de la compra es ", pt);
            //MessageBox.Show("Registre datos de la nueva compra");
            //return compra;
           

        }
        public int Consultarid()
        {
            conectado();
            string query = "SELECT MAX(idmermas) FROM  mermas ";
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
                //String[] resultado = null;
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
        public void insertarDMerma(int codigo, int producto, int cantidad)
        {
            int A = 1;
            //String B = Convert.ToString(producto);
            //MessageBox.Show(B);
            conectado();
            string query = "INSERT INTO detallemerma (mermas_idmermas,productos_idproducto,cantidad) VALUES " +
             "('" + producto + "','" + codigo + "','" + cantidad + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            
        }
        public void insertartotal(int codigo, double cantidad)
        {
            conectado();
            //String prueba = Convert.ToString("Codigo del producto"+codigo);
            //MessageBox.Show(prueba);
            //cantidad = 100;
            string query = "UPDATE mermas SET preciototal=(preciototal + '" + cantidad + "') WHERE idmermas=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Prueba");
        }
        public String Consultartotal(int codigo)
        {
            conectado();
            string query = "SELECT preciototal FROM \"mermas\" WHERE idmermas=" + codigo + " ";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String consulta = null;
            String tabla;
            while (registro.Read())
            {

                tabla = registro["preciototal"].ToString();
                consulta = tabla;
                //
            }
            //int conversion = Convert.ToInt32(consulta);
            //conversion = conversion + 1;

            //MessageBox.Show(consulta);
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
        public void debaja(int codigo)
        {
            conectado();
            String estatus = "Sin Existencia";
            string query = "UPDATE productos SET estatus='" + estatus + "' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
        public void eliminarRegistro(int id)
        {
            conectado();
            string query = "DELETE FROM detallemerma WHERE iddetallemerma=" + id + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            MessageBox.Show("Producto Eliminado");
        }
        public void actualizartotal(int codigo,double n)
        {
            conectado();
            //String estatus = "Sin Existencia";
            string query = "UPDATE mermas SET preciototal=preciototal-'" + n + "' WHERE idmermas=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
    }
}
    
