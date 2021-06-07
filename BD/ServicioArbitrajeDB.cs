using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class ServicioArbitrajeDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        SqlConnection conexion;

        //verifcar conexion
        public void openConexion()
        {
            try
            {
                conexion = new SqlConnection(connectionString);
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito");
            }
            catch
            {
                MessageBox.Show("NO SEA REALIZADO LA CONEXION");
            }
        }
        public DataTable CargarComboArbitros()
        {
            SqlDataAdapter da = new SqlDataAdapter("obtener_DPI_YnombresDeArbitros", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        decimal costo;

        public decimal obtenerPrecioPorHoraArbitraje()
        {
            string query = "exec obtenerPrecioPorHoraArbitraje ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        costo = reader.GetDecimal(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio por hora del arbitraje en la base de datos " + ex.Message);
                }
            }
            return costo;
        }

        int CantidadPartidos;

        public int obtenerCantidadPartidosJugarHoraFechaArbitro(long DPI, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            string query = "exec obtenerCantidadPartidosJugarHoraFechaArbitro @DPI, @Fecha, @HoraInicio,@HoraFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
                sql.Parameters.AddWithValue("@Fecha", Fecha);
                sql.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                sql.Parameters.AddWithValue("@HoraFinal", HoraFinal);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        CantidadPartidos = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los partido a jugar con los Arbitros en la base de datos " + ex.Message);
                }
            }
            return CantidadPartidos;
        }

        public int obtenerCantidadPartidosJugarHoraFechaJornadasArbitro(long DPI, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            string query = "exec obtenerCantidadPartidosJugarHoraFechaJornadasArbitro @DPI, @Fecha, @HoraInicio,@HoraFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
                sql.Parameters.AddWithValue("@Fecha", Fecha);
                sql.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                sql.Parameters.AddWithValue("@HoraFinal", HoraFinal);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        CantidadPartidos = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los partido a jugar con los Arbitros en la base de datos " + ex.Message);
                }
            }
            return CantidadPartidos;
        }

        public void AgregarArbitraje(ServicioArbitraje servicio)
        {
            string query = "exec p_addArbitraje @Id_Alquiler,@DPI_Arbitro,@pagoArbitraje,@DiaJuego,@HoraInicio,@HoraFinal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@Id_Alquiler", servicio.Id_Alquiler);
                command.Parameters.AddWithValue("@DPI_Arbitro", servicio.DPI_Arbitro);
                command.Parameters.AddWithValue("@pagoArbitraje", servicio.pagoArbitraje);
                command.Parameters.AddWithValue("@DiaJuego", servicio.DiaJuego);
                command.Parameters.AddWithValue("@HoraInicio", servicio.HoraInicio);
                command.Parameters.AddWithValue("@HoraFinal", servicio.HoraFinal);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitraje Agregado Correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("El arbitro ya está programado para el partido");
                }
            }
        }

        public List<Arbitro> GetArbitrosAlquiler(int Id_Alquiler)
        {
            List<Arbitro> arbitros = new List<Arbitro>();
            string query = $"exec p_obtenerArbitrosDeAlquiler {Id_Alquiler}";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Arbitro arbitroo = new Arbitro();
                        arbitroo.Dpi = reader.GetInt64(0);
                        arbitroo.Nombre = reader.GetString(1);
                        arbitroo.Apellidos = reader.GetString(2);
                        arbitroo.Direccion = reader.GetString(3);
                        arbitroo.Telefono = reader.GetString(4);
                        arbitroo.Nacionalidad = reader.GetString(5);
                        arbitroo.FechaNac = reader.GetDateTime(6);
                        arbitroo.Correo = reader.GetString(7);
                        arbitroo.Rol = reader.GetString(8);

                        arbitros.Add(arbitroo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return arbitros;
        }

        public void EliminarServicioArbitraje(int Id_Alquiler, long DPI_Arbitro)
        {
            string query = "DELETE FROM ServicioArbitraje WHERE Id_Alquiler=@Id_Alquiler and DPI_Arbitro=@DPI_Arbitro"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Alquiler", Id_Alquiler);
                command.Parameters.AddWithValue("@DPI_Arbitro", DPI_Arbitro);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Servicio de Arbitraje eliminado correctamente.");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al eliminar el Alquiler en la base de datos" + ex.Message);
                }
            }
        }


    }
}