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
    class ReporteMermas
    {//conexion conectandose = new conexion();
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
        public DataTable Consultar1(int id)
        {
           // string query = " select mermas.idmermas,usuarios.nombre,mermas.usuarios_idusuario,mermas.razon,mermas.fecha,mermas.hora,mermas.preciototal  from \"mermas\",\"usuarios\" where mermas.idmermas = " + id +" and mermas.usuarios_idusuario = usuarios.idusuario ";
            string query = " select mermas.idmermas,usuarios.nombre,mermas.razon,mermas.fecha,mermas.hora,mermas.preciototal  from \"mermas\",\"usuarios\" where  mermas.usuarios_idusuario = usuarios.idusuario ";

            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public DataTable Consultar()
        {
            string query = "select * from \"mermas\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public void ConsultarIdMerma(ComboBox cb)
        {
            cb.Items.Clear();
            conectado();
            string query = "select mermas from \"idmermas\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, con);
            NpgsqlDataReader registro = conector.ExecuteReader();
            while (registro.Read())
            {
                cb.Items.Add(registro["merma"].ToString());
            }
            desconectado();
            cb.Items.Insert(0, "---Seleccione Merma----");
            cb.SelectedIndex = 0;

        }
        public DataTable Llenartabla(String fecha)
        {
            string query = "select  productos.idproducto,productos.nombre,productos.descripcion,usuarios.nombre,detallemerma.cantidad,mermas.hora,productos.precio,productos.precio*detallemerma.cantidad from \"mermas\",\"detallemerma\",\"productos\",\"usuarios\" where mermas.fecha ='" + fecha + "' AND mermas.usuarios_idusuario = usuarios.idusuario AND detallemerma.mermas_idmermas = mermas.idmermas AND detallemerma.productos_idproducto = productos.idproducto";

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
