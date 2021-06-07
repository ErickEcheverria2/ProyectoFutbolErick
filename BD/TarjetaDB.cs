using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
   public  class TarjetaDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public void agregarTarjeta(Tarjeta tr)
        {
            string query = $" exec Tarjetas @tar,@multa,@com"; //insersion de una tarjeta 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                sql.Parameters.AddWithValue("@tar",  tr.Color_Tarjeta);
                sql.Parameters.AddWithValue("@multa",   tr.Multa);
                sql.Parameters.AddWithValue("@com",   tr.Comentario);
                try
                {
                    connection.Open(); //conexion y query 
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Exito al agregar Tarjeta");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar la Tarjeta" + ex.Message);
                }
            }
        }


        public void updtTarjeta(Tarjeta tr)
        {
            string query = $" exec editarjeta @tar,@multa,@com";  // modificar una tarjeta existente 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                sql.Parameters.AddWithValue("@tar", tr.Color_Tarjeta);
                sql.Parameters.AddWithValue("@multa", tr.Multa);
                sql.Parameters.AddWithValue("@com", tr.Comentario);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Exito al Modificar Tarjeta");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al Modificar la Tarjeta" + ex.Message);
                }
            }
        }
        public void Delete(string id)
        {
            string query = " exec dtltarjeta @tar";  //eliminar una tarjeta 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tar", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Tarjeta Eliminada");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar " + ex.Message);
                }
            }

        }




        public List<Tarjeta> ltr ()
        {
            List<Tarjeta> lista = new List<Tarjeta>();

            string query = " exec vertarjetas ";  // listar todas las tarjetas 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Tarjeta tr = new Tarjeta();
                        tr.Color_Tarjeta = reader.GetString(0);
                        tr.Multa = reader.GetString(1);
                        tr.Comentario = reader.GetString(2);
                        lista.Add(tr);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron obtener los datos" + ex.Message);
                }

            }

            return lista;
        }

        public Tarjeta tarjeta (string id ) //obtener una tarjeta especifica por su color 
        {
            Tarjeta tr = new Tarjeta();
            string query = " exec vertarjeta @tar ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@tar", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {

                        tr.Color_Tarjeta = reader.GetString(0);
                        tr.Multa = reader.GetString(1);
                        tr.Comentario = reader.GetString(2);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron obtener los datos" + ex.Message);
                }
                

            }
            return tr;
        }

    }
}
