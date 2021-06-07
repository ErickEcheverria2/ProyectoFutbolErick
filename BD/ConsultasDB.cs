using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class ConsultasDB
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

        public List<Consulta_IngresoDeAlquilerCancha> consulta_montoGeneradoXCanchasDiaxDia(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Consulta_IngresoDeAlquilerCancha> alquilerCanchas = new List<Consulta_IngresoDeAlquilerCancha>();
            string query = "  exec consulta_montoGeneradoXCanchasDiaxDia @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio); //asigamos los valores que se insertaran al script
                sql.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta_IngresoDeAlquilerCancha alquilerCancha = new Consulta_IngresoDeAlquilerCancha();
                        alquilerCancha.Fecha = reader.GetDateTime(0);
                        alquilerCancha.NumeroDeCancha = reader.GetInt32(1);
                        alquilerCancha.NombreCancha = reader.GetString(2);
                        alquilerCancha.CantidadAlquileres = reader.GetInt32(3);
                        alquilerCancha.MontoRecaudado = reader.GetDecimal(4);

                        alquilerCanchas.Add(alquilerCancha);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return alquilerCanchas;


        }

        public List<Consulta_IngresoServicioDeArbitraje> consulta_montoGeneradoXServicioDeArbitrajeDiaxDia(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Consulta_IngresoServicioDeArbitraje> servicioDeArbitrajes = new List<Consulta_IngresoServicioDeArbitraje>();
            string query = "  exec consulta_montoGeneradoXServicioDeArbitrajeDiaxDia @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio); //asigamos los valores que se insertaran al script
                sql.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta_IngresoServicioDeArbitraje servicioDeArbitraje = new Consulta_IngresoServicioDeArbitraje();
                        servicioDeArbitraje.Fecha = reader.GetDateTime(0);
                        servicioDeArbitraje.CantidadPartidosParticipados = reader.GetInt32(1);
                        servicioDeArbitraje.DPI_Arbitro = reader.GetInt64(2);
                        servicioDeArbitraje.NombreCompletoArbitro = reader.GetString(3);
                        servicioDeArbitraje.MontoRecaudado = reader.GetDecimal(4);

                        servicioDeArbitrajes.Add(servicioDeArbitraje);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return servicioDeArbitrajes;


        }

        public DataTable CargarComboUsuarios()
        {
            SqlDataAdapter da = new SqlDataAdapter("obtener_Id_yNombresDeUsuarios", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Consulta_BitacoraDeAcceso> consulta_BitacoraDeAccesoFechas(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Consulta_BitacoraDeAcceso> consultas = new List<Consulta_BitacoraDeAcceso>();
            string query = "  exec consulta_BitacoraDeAccesoFechas @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio); //asigamos los valores que se insertaran al script
                sql.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta_BitacoraDeAcceso consulta = new Consulta_BitacoraDeAcceso();
                        consulta.Nombre_Usuario = reader.GetString(0);
                        consulta.Id_Usuario = reader.GetInt32(1);
                        consulta.FechaHoraAcceso = reader.GetDateTime(2);
                        consulta.SeccionEntrada = reader.GetString(3);

                        consultas.Add(consulta);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return consultas;


        }

        public List<Consulta_BitacoraDeAcceso> consulta_BitacoraDeAccesoNombreUsuario(string Usuario)
        {
            List<Consulta_BitacoraDeAcceso> consultas = new List<Consulta_BitacoraDeAcceso>();
            string query = "  exec consulta_BitacoraDeAccesoNombreUsuario @Usuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Usuario", Usuario); //asigamos los valores que se insertaran al script
                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta_BitacoraDeAcceso consulta = new Consulta_BitacoraDeAcceso();
                        consulta.Nombre_Usuario = reader.GetString(0);
                        consulta.Id_Usuario = reader.GetInt32(1);
                        consulta.FechaHoraAcceso = reader.GetDateTime(2);
                        consulta.SeccionEntrada = reader.GetString(3);

                        consultas.Add(consulta);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return consultas;


        }

        public List<Consulta_DisponibilidadCancha> consultaDisponibilidadDeCancha(DateTime fechaInicio, DateTime fechaFinal, int NoCancha)
        {
            List<Consulta_DisponibilidadCancha> disponibilidadCanchas = new List<Consulta_DisponibilidadCancha>();
            string query = "  select * from erick_consultaDisponibilidadDeCancha( @fechaInicio, @fechaFinal, @NoCancha)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio); //asigamos los valores que se insertaran al script
                sql.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                sql.Parameters.AddWithValue("@NoCancha", NoCancha);
                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta_DisponibilidadCancha disponibilidadCancha = new Consulta_DisponibilidadCancha();
                        disponibilidadCancha.FechaHora = reader.GetDateTime(0);
                        disponibilidadCancha.NombreTorneo = reader.GetString(1);
                        disponibilidadCancha.NombreEquipoLocal = reader.GetString(2);
                        disponibilidadCancha.NombreEquipoVisita = reader.GetString(3);

                        disponibilidadCanchas.Add(disponibilidadCancha);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return disponibilidadCanchas;


        }
        public DataTable CargarComboCanchas()
        {
            SqlDataAdapter da = new SqlDataAdapter("obtener_numeroYnombresDeCanchaTipos", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
