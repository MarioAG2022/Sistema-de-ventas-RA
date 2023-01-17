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
    class fcompras
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
            string query = "select idproducto,nombre,detallecompra.cantidad,precio,pcompra,detallecompra.pcompra*detallecompra.cantidad from \"detallecompra\",\"productos\" where compras_idcompras='" + id+ "' AND productos.idproducto=detallecompra.productos_idproducto";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
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
        public void InsertarCompra(String fecha,int usuario)
        {
            int compra;
            
            compra = Convert.ToInt32(Consultarid());
            //compra = compra + 1;
            conectado();
            string query = "INSERT INTO compras (idcompras,usuarios_idusuario,fecha) VALUES " +
                "('" + compra + "','" + usuario + "','" + fecha + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            String pt;
            pt = Convert.ToString(compra);
            //MessageBox.Show("El id de la compra es ",pt);
            //MessageBox.Show("Registre datos de la nueva compra");
            //return compra;

        }
        public int Consultarid()
        {
            conectado();
            string query = "SELECT MAX(idcompras) FROM \"compras\"";
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
            catch(Exception error)
            {
                Console.WriteLine("El producto que busca no esta registrado: " + error.Message);
            }
            
            return resultado;

            //cb.Items.Insert(0, "---Seleccione Marca----");
            //cb.SelectedIndex = 0;

        }
        public int ConsultarExistencia(int id)
        {
            conectado();
            string query = "SELECT cantidad FROM \"productos\" where idproducto='"+ id + "'";
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
            string query = "UPDATE productos SET estatus='"+ estatus +"' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
        public void aumentarStock(int codigo, int cantidad)
        {
            conectado();
            string query = "UPDATE productos SET cantidad=(cantidad + '" + cantidad + "') WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Compra Realizada");
        }
        public void insertarDCompra(int codigo, int compra, int cantidad,double pcompra)
        {
            
            // = Convert.ToInt32(Consultarid());
            //compra = compra - 1;
            conectado();
            string query = "INSERT INTO detallecompra (productos_idproducto,compras_idcompras,cantidad,pcompra) VALUES " +
             "('" + codigo + "','" + compra + "','" + cantidad + "','" + pcompra + "')";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            //MessageBox.Show("Compra Realizada");
        }
        public void insertarPCompra(int codigo, double cantidad)
        {
            conectado();
            string query = "UPDATE productos SET pcompra='" + cantidad + "' WHERE idproducto=" + codigo + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();
            MessageBox.Show("Compra Realizada");
        }
        public void eliminarRegistro(int id)
        {
            conectado();
            string query = "DELETE FROM detallecompra WHERE productos_idproducto=" + id + "";
            NpgsqlCommand ejecutor = new NpgsqlCommand(query, con);
            ejecutor.ExecuteNonQuery();
            desconectado();

            MessageBox.Show("Producto Eliminado");
        }
       
    }
}
