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
    class ControlAmonestacionDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public void optionsTarjetas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT * FROM AMONESTACION", connection);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}");
                }
                connection.Close();
            }
        }

        public void addControlAmonestacion(ControlAmonestacion controlAmonestacion)
        {
            string query = "EXEC SP_INSERT_CONTROL_AMONESTACION @Id_Juego, @Id_Jugador, @Color_Tarjeta, @Tiempo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para realizar la consulta
                    sql.Parameters.AddWithValue("@Id_Juego", controlAmonestacion.Id_Juego);
                    sql.Parameters.AddWithValue("@Id_Jugador", controlAmonestacion.Id_Jugador);
                    sql.Parameters.AddWithValue("@Color_Tarjeta", controlAmonestacion.Color_Tarjeta);
                    sql.Parameters.AddWithValue("@Tiempo", controlAmonestacion.Tiempo);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();

                    MessageBox.Show("La amonestación al jugador ha sido agregado correctamente");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al insertar la amonestación al jugador");
                }
            }
        }

        public List<ControlAmonestacion> getAmonestaciones(int idJuego)
        {
            List<ControlAmonestacion> listAmonestaciones = new List<ControlAmonestacion>();

            //Query a ejecutar en la base de datos
            string query = $"EXEC SP_VIEW_CONTROL_AMONESTACION {idJuego}";

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
                        controlAmonestacion.Nombres = reader.GetString(5);

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

        public ControlAmonestacion getAmonestacionById(int idJuego, int idJugador)
        {
            //Query a ejecutar en la base de datos
            string query = $"SELECT * FROM REGISTRO_AMONESTACION WHERE Id_Juego = {idJuego} AND Id_Jugador = {idJugador}";
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

                    controlAmonestacion.Id_Juego = reader.GetInt32(0);
                    controlAmonestacion.Id_Jugador = reader.GetInt32(1);
                    controlAmonestacion.Color_Tarjeta = reader.GetString(2);
                    controlAmonestacion.Tiempo = reader.GetString(3);
                    controlAmonestacion.Pagado = reader.GetBoolean(4);
                    controlAmonestacion.Nombres = reader.GetString(5);

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
            string query = $"EXEC SP_UPDATE_CONTROL_AMONESTACION {controlAmonestacion.Id_Juego}, {controlAmonestacion.Id_Jugador}, {controlAmonestacion.Color_Tarjeta}, {controlAmonestacion.Tiempo}";
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


        public void deleteAmonestacion(ControlAmonestacion controlAmonestacion)
        {
            //Query a ejecutar
            string query = $"EXEC SP_DELETE_CONTROL_AMONESTACION {controlAmonestacion.Id_Juego}, {controlAmonestacion.Id_Jugador}, {controlAmonestacion.Color_Tarjeta}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("La tatrjeta ha sido eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar la tarjeta");
                }
            }
        }
    }
}
