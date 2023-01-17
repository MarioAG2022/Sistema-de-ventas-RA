using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;

namespace SistemaRA._2.Datos
{
    class fventas
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
            string query = "select idproducto,nombre,precio,detalleventa.cantidad,precio*detalleventa.cantidad,iddetalleventa from \"detalleventa\",\"productos\" where ventas_idventas='" + id + "' AND productos.idproducto=detalleventa.productos_idproducto";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public int Consultarid()
        {
            conectado();
            string query = "SELECT MAX(idventas) FROM \"ventas\"";
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

            conectado();
            string query = "select nombre,descripcion,precio from \"productos\" where idproducto='" + id + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            String[] resultado = null;
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
            return resultado;

            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;
        
        }
        public void disminuirStock(int codigo, int cantidad)
        {
            conectado();
            string query = "UPDATE productos SET cantidad=(cantidad - '" + cantidad + "') WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Compra Realizada");
        }
        public void insertartotal(int codigo, double cantidad)
        {
            conectado();
            //String prueba = Convert.ToString("Codigo del producto"+codigo);
            //MessageBox.Show(prueba);
            //cantidad = 100;
            string query = "UPDATE ventas SET preciototal=(preciototal + '" + cantidad + "') WHERE idventas=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Prueba");
        }
        public String Consultartotal(int codigo)
        {
            conectado();
            string query = "SELECT preciototal FROM \"ventas\" WHERE idventas=" + codigo + " ";
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
        public void InsertarVenta(String fecha, int usuario,String hora)
        {
            int compra;
            int total = 0;
            compra = Convert.ToInt32(Consultarid());
            //compra = compra + 1;
            conectado();
            string query = "INSERT INTO ventas (idventas,usuarios_idusuario,fecha,hora,preciototal) VALUES " +
                "('" + compra + "','" + usuario + "','" + fecha + "','" + hora + "','" + total + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            String pt;
            pt = Convert.ToString(compra);
            //MessageBox.Show("El id de la compra es ",pt);
            //MessageBox.Show("Registre datos de la nueva compra");
            //return compra;

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
        public void insertarDVenta(int codigo, int venta, int cantidad)
        {

            // = Convert.ToInt32(Consultarid());
            //compra = compra - 1;
            conectado();
            string query = "INSERT INTO detalleventa (productos_idproducto,ventas_idventas,cantidad) VALUES " +
             "('" + codigo + "','" + venta + "','" + cantidad + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
        public void tipodepago(int codigo, String tipo)
        {
            conectado();
            //String prueba = Convert.ToString("Codigo del producto"+codigo);
            //MessageBox.Show(prueba);
            //cantidad = 100;
            string query = "UPDATE ventas SET tipodepago='" + tipo + "' WHERE idventas=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Prueba");
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
            String estatus = "En Existencia";
            string query = "UPDATE productos SET estatus='" + estatus + "' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
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
            string query = "DELETE FROM detalleventa WHERE iddetalleventa=" + id + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            MessageBox.Show("Producto Eliminado");
        }
        public void actualizartotal(int codigo, double n)
        {
            conectado();
            //String estatus = "Sin Existencia";
            string query = "UPDATE ventas SET preciototal=preciototal-'" + n + "' WHERE idventas=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
    }
}
