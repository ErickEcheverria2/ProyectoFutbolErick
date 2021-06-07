using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class AlquilarCanchaDB
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

        public DataTable CargarComboCanchas()
        {
            SqlDataAdapter da = new SqlDataAdapter("obtener_numeroYnombresDeCanchaTipos", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<AlquilarCancha> GetAlquileres()
        {
            List<AlquilarCancha> alquilarCanchas = new List<AlquilarCancha>();
            string query = "exec p_GetAlquileres";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        AlquilarCancha alquiler = new AlquilarCancha();
                        alquiler.Id_Alquiler = reader.GetInt32(0);
                        alquiler.DPI_Persona = reader.GetInt64(1);
                        alquiler.Nombres = reader.GetString(2);
                        alquiler.Apellidos = reader.GetString(3);
                        alquiler.Telefono = reader.GetString(4);
                        alquiler.Correo = reader.GetString(5);
                        alquiler.NoCancha = reader.GetInt32(6);
                        alquiler.DiaAlquiler = reader.GetDateTime(7);
                        alquiler.HoraInicio = reader.GetTimeSpan(8);
                        alquiler.HoraFinal = reader.GetTimeSpan(9);
                        alquiler.costoAlquiler = reader.GetDecimal(10);

                        alquilarCanchas.Add(alquiler);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return alquilarCanchas;
        }

        public void AgregarAlquiler(AlquilarCancha alquilar)
        {
            string query = "exec p_addAlquiler @DPI_Persona,@Nombres,@Apellidos,@Telefono,@Correo,@NoCancha,@DiaAlquiler,@HoraInicio,@HoraFinal,@costoAlquiler";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@DPI_Persona", alquilar.DPI_Persona);
                command.Parameters.AddWithValue("@Nombres", alquilar.Nombres);
                command.Parameters.AddWithValue("@Apellidos", alquilar.Apellidos);
                command.Parameters.AddWithValue("@Telefono", alquilar.Telefono);
                command.Parameters.AddWithValue("@Correo", alquilar.Correo);
                command.Parameters.AddWithValue("@NoCancha", alquilar.NoCancha);
                command.Parameters.AddWithValue("@DiaAlquiler", alquilar.DiaAlquiler);
                command.Parameters.AddWithValue("@HoraInicio", alquilar.HoraInicio);
                command.Parameters.AddWithValue("@HoraFinal", alquilar.HoraFinal);
                command.Parameters.AddWithValue("@costoAlquiler", alquilar.costoAlquiler);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Alquiler Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al Guardar Tarjeta" + error.Message, "ERROR");
                }
            }
        }

        decimal cantidad;

        public decimal obtenerPrecioPorHora(int NoCancha)
        {
            string query = "exec obtenerPrecioPorHora @NoCancha ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NoCancha", NoCancha);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetDecimal(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio por hora de la cancha en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        int CantidadPartidos;

        public int obtenerCantidadPartidosJugarHoraFecha(int NoCancha, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            string query = "exec obtenerCantidadPartidosJugarHoraFecha @NoCancha, @Fecha, @HoraInicio,@HoraFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NoCancha", NoCancha);
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
                    MessageBox.Show("Error al obtener los partido a jugar en la cancha en la base de datos " + ex.Message);
                }
            }
            return CantidadPartidos;
        }

        public int obtenerCantidadPartidosJugarHoraFechaJornadas(int NoCancha, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            string query = "exec obtenerCantidadPartidosJugarHoraFechaJornadas @NoCancha, @Fecha, @HoraInicio,@HoraFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NoCancha", NoCancha);
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
                    MessageBox.Show("Error al obtener los partido a jugar en la cancha en la base de datos " + ex.Message);
                }
            }
            return CantidadPartidos;
        }

        public AlquilarCancha buscarAlquiler(int Id_Alquiler)
        {
            AlquilarCancha alquiler = new AlquilarCancha();
            string query = "select*from PersonaAlquiler where Id_Alquiler=@Id_Alquiler";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_Alquiler", Id_Alquiler);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    alquiler.Id_Alquiler = reader.GetInt32(0);
                    alquiler.DPI_Persona = reader.GetInt64(1);
                    alquiler.Nombres = reader.GetString(2);
                    alquiler.Apellidos = reader.GetString(3);
                    alquiler.Telefono = reader.GetString(4);
                    alquiler.Correo = reader.GetString(5);
                    alquiler.NoCancha = reader.GetInt32(6);
                    alquiler.DiaAlquiler = reader.GetDateTime(7);
                    alquiler.HoraInicio = reader.GetTimeSpan(8);
                    alquiler.HoraFinal = reader.GetTimeSpan(9);
                    alquiler.costoAlquiler = reader.GetDecimal(10);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return alquiler;
            }
        }

        public void actualizar_Alquiler(AlquilarCancha alquilar)
        {
            string query = "UPDATE PersonaAlquiler SET DPI_Persona = @DPI_Persona, Nombres = @Nombres, Apellidos=@Apellidos, Telefono=@Telefono, Correo=@Correo, NoCancha=@NoCancha, DiaAlquiler=@DiaAlquiler, HoraInicio=@HoraInicio, HoraFinal=@HoraFinal,costoAlquiler=@costoAlquiler    WHERE Id_Alquiler = @Id_Alquiler";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Id_Alquiler", alquilar.Id_Alquiler);
                command.Parameters.AddWithValue("@DPI_Persona", alquilar.DPI_Persona);
                command.Parameters.AddWithValue("@Nombres", alquilar.Nombres);
                command.Parameters.AddWithValue("@Apellidos", alquilar.Apellidos);
                command.Parameters.AddWithValue("@Telefono", alquilar.Telefono);
                command.Parameters.AddWithValue("@Correo", alquilar.Correo);
                command.Parameters.AddWithValue("@NoCancha", alquilar.NoCancha);
                command.Parameters.AddWithValue("@DiaAlquiler", alquilar.DiaAlquiler);
                command.Parameters.AddWithValue("@HoraInicio", alquilar.HoraInicio);
                command.Parameters.AddWithValue("@HoraFinal", alquilar.HoraFinal);
                command.Parameters.AddWithValue("@costoAlquiler", alquilar.costoAlquiler);
                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Actualizacion Realizada ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en actualizacion" + ex.Message);
                }

            }
        }

        public int obtenerCantidadPartidosJugarHoraFechaeExecptoElMismo(int Id_Alquiler, int NoCancha, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            string query = "exec obtenerCantidadPartidosJugarHoraFechaeExecptoElMismo @Id_Alquiler, @NoCancha, @Fecha, @HoraInicio,@HoraFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NoCancha", NoCancha);
                sql.Parameters.AddWithValue("@Fecha", Fecha);
                sql.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                sql.Parameters.AddWithValue("@HoraFinal", HoraFinal);
                sql.Parameters.AddWithValue("@Id_Alquiler", Id_Alquiler);
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
                    MessageBox.Show("Error al obtener los partido a jugar en la cancha en la base de datos " + ex.Message);
                }
            }
            return CantidadPartidos;
        }

        public void EliminarAlquiler(int Id_Alquiler)
        {
            string query = "DELETE FROM PersonaAlquiler WHERE Id_Alquiler=@Id_Alquiler"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Alquiler", Id_Alquiler);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Alquiler eliminado correctamente.");
                }
                catch (Exception) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Para eliminar correctamente el Alquiler\nPrimero borré los servicios de arbitraje contratados");
                }
            }
        }
        decimal entero;

        public decimal obtenerTotalPagarServicioArbitraje(int Id_Alquiler)
        {
            string query = $"exec obtenerTotalPagarServicioArbitraje {Id_Alquiler} ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        entero = reader.GetDecimal(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener la base de datos " + ex.Message);
                }
            }
            return entero;
        }

        public InformacionEmpresa obtenerHorarios()
        {
            InformacionEmpresa empresa = new InformacionEmpresa();
            string query = "select HorarioEntradaLunes, HorarioSalidaLunes," +
                "HorarioEntradaMartes, HorarioSalidaMartes," +
                "HorarioEntradaMiercoles, HorarioSalidaMiercoles," +
                "HorarioEntradaJueves, HorarioSalidaJueves," +
                "HorarioEntradaViernes, HorarioSalidaViernes," +
                "HorarioEntradaSabado, HorarioSalidaSabado," +
                "HorarioEntradaDomingo, HorarioSalidaDomingo from InformacionEmpresa";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    empresa.HoraEntradaLunes = reader.GetTimeSpan(0);
                    empresa.HoraSalidaLunes = reader.GetTimeSpan(1);
                    empresa.HoraEntradaMartes = reader.GetTimeSpan(2);
                    empresa.HoraSalidaMartes = reader.GetTimeSpan(3);
                    empresa.HoraEntradaMiercoles = reader.GetTimeSpan(4);
                    empresa.HoraSalidaMiercoles = reader.GetTimeSpan(5);
                    empresa.HoraEntradaJueves = reader.GetTimeSpan(6);
                    empresa.HoraSalidaJueves = reader.GetTimeSpan(7);
                    empresa.HoraEntradaViernes = reader.GetTimeSpan(8);
                    empresa.HoraSalidaViernes = reader.GetTimeSpan(9);
                    empresa.HoraEntradaSabado = reader.GetTimeSpan(10);
                    empresa.HoraSalidaSabado = reader.GetTimeSpan(11);
                    empresa.HoraEntradaDomingo = reader.GetTimeSpan(12);
                    empresa.HoraSalidaDomingo = reader.GetTimeSpan(13);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return empresa;
            }
        }




    }
}