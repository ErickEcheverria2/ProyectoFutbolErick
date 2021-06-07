using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    public class CanchaDb
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public Cancha GetCancha(int Nocancha)
        {
            Cancha nCancha = new Cancha();
            string query = "select * from CANCHA where NoCancha=@NoCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NoCancha", Nocancha);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    nCancha.NoCancha = reader.GetInt32(0);
                    nCancha.Nombre = reader.GetString(1);
                    nCancha.Capacidad = reader.GetString(2);
                    nCancha.estatus = reader.GetString(3);
                    nCancha.precioDeAlquiler = reader.GetDecimal(4);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos" + ex.Message);
                }
            }
            return nCancha;
        }

        public List<Cancha> GetCanchas()
        {
            List<Cancha> nCanchas = new List<Cancha>();
            string query = "select * from CANCHA";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Cancha nCancha = new Cancha();
                        nCancha.NoCancha = reader.GetInt32(0);
                        nCancha.Nombre = reader.GetString(1);
                        nCancha.Capacidad = reader.GetString(3);
                        nCancha.estatus = reader.GetString(2);
                        nCancha.precioDeAlquiler = reader.GetDecimal(4);
                        nCanchas.Add(nCancha);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron obtener los datos" + ex.Message);
                }

            }
            return nCanchas;
        }

        public void AddCancha(Cancha nCancha)
        {
            string query = $"INSERT INTO CANCHA( Nombre, Capacidad, estatus,precioDeAlquiler) VALUES ( @Nombre, @Capacidad, @estatus ,@precioDeAlquiler)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                sql.Parameters.AddWithValue("@Nombre", nCancha.Nombre);
                sql.Parameters.AddWithValue("@Capacidad", nCancha.Capacidad);
                sql.Parameters.AddWithValue("@estatus", nCancha.estatus);
                sql.Parameters.AddWithValue("@precioDeAlquiler", nCancha.precioDeAlquiler);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar la Cancha" + ex.Message);
                }
            }
        }

        public void UpdateCancha(int NoCancha, string Nombre, string Capacidad, string estatus, decimal precioDeAlquiler)
        {
            string query = "UPDATE CANCHA set Nombre=@Nombre, Capacidad=@Capacidad, estatus=@estatus, precioDeAlquiler=@precioDeAlquiler WHERE NoCancha=@NoCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NoCancha", NoCancha);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Capacidad", Capacidad);
                command.Parameters.AddWithValue("@estatus", estatus);
                command.Parameters.AddWithValue("@precioDeAlquiler", precioDeAlquiler);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cancha Actualizada");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la cancha" + ex.Message);
                }
            }
        }

        public void DeleteCancha(int NoCancha)
        {
            string query = " delete from CANCHA where NoCancha=@NoCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NoCancha", NoCancha);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cancha Eliminada");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar " + ex.Message);
                }
            }

        }
        public int maxid() //buscamos el siguiente id a usar 
        {

            int codigo = 0;
            string query = "exec newich";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {


                        codigo = reader.GetInt32(0);





                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error  " + ex.Message);
                }

            }

            return (codigo + 1);

        }

    }
}