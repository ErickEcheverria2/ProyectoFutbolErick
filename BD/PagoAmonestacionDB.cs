using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    class PagoAmonestacionDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public List<ControlAmonestacion> getAmonestaciones()
        {
            List<ControlAmonestacion> listAmonestaciones = new List<ControlAmonestacion>();

            //Query a ejecutar en la base de datos
            string query = $"EXEC SP_VIEW_PAGO_AMONESTACION";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        ControlAmonestacion controlAmonestacion = new ControlAmonestacion();

                        controlAmonestacion.Id_Juego = reader.GetInt32(0);
                        controlAmonestacion.Id_Jugador = reader.GetInt32(1);
                        controlAmonestacion.Color_Tarjeta = reader.GetString(2);
                        controlAmonestacion.Tiempo = reader.GetString(3);
                        controlAmonestacion.Pagado = reader.GetBoolean(4);

                        listAmonestaciones.Add(controlAmonestacion);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos de las amonestaciones");
                }
                return listAmonestaciones;
            }
        }

        public ControlAmonestacion getAmonestacionById(int idJuego, int idJugador, string colorTarjeta)
        {
            //Query a ejecutar en la base de datos
            string query = $"SELECT * FROM REGISTRO_AMONESTACION WHERE Id_Juego = {idJuego} AND Id_Jugador = {idJugador} AND Color_Tarjeta = '{colorTarjeta}'";
            ControlAmonestacion controlAmonestacion = new ControlAmonestacion();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    controlAmonestacion.Id_Juego = reader.GetInt32(0);
                    controlAmonestacion.Id_Jugador = reader.GetInt32(1);
                    controlAmonestacion.Color_Tarjeta = reader.GetString(2);
                    controlAmonestacion.Tiempo = reader.GetString(3);
                    controlAmonestacion.Pagado = reader.GetBoolean(4);

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos de las amonestaciones");
                }
                return controlAmonestacion;
            }
        }

        public void updateControlAmonestacion(ControlAmonestacion controlAmonestacion)
        {
            //Query de actualizacion
            string query = $"EXEC SP_UPDATE_PAGO_AMONESTACION {controlAmonestacion.Id_Juego}, {controlAmonestacion.Id_Jugador}, {controlAmonestacion.Color_Tarjeta}, {controlAmonestacion.Tiempo}, {controlAmonestacion.Pagado}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();

                    MessageBox.Show("La amonestación ha sido actualizado correctamente");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al actualizar La amonestación");
                }
            }
        }
    }
}
