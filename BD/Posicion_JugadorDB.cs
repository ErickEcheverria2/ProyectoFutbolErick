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
    class Posicion_JugadorDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public void optionsJugadores(ComboBox cbx, int edadMinima, int edadMaxima, int idTorneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int edad;
                DateTime fechaNacimiento;
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener jugadores
                SqlCommand sql = new SqlCommand($"SELECT J.Identificacion, J.Nombres, J.Fecha_nac FROM JUGADOR J WHERE J.Identificacion NOT IN (SELECT PJ.Identificacion FROM POSICION_JUGADOR PJ WHERE PJ.Id_Torneo = {idTorneo});", connection);
                //Lectura de datos y agregar al combo box obtenido como parametro del metodo
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    fechaNacimiento = Convert.ToDateTime(dr[2]);
                    edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
                    if (edad >= edadMinima && edad <= edadMaxima)
                    {
                        Console.WriteLine(edad);
                        cbx.Items.Add($"{dr[0]}| {dr[1]}");
                    }
                }
                connection.Close();
            }
        }

        public Posicion_Jugador getPosicionById(long identificacion, int idTorneo, int idEquipo)
        {

            Posicion_Jugador posicion_Jugador = new Posicion_Jugador();

            string query = $"SELECT * FROM POSICION_JUGADOR WHERE Identificacion = {identificacion} AND Id_Torneo = {idTorneo} AND Id_Equipo = {idEquipo}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    //Lectura de la consulta obtenida
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Almacenamiento de la consulta obtenida
                    posicion_Jugador.id_torneo = reader.GetInt32(0);
                    posicion_Jugador.id_equipo = reader.GetInt32(1);
                    posicion_Jugador.identificacion = reader.GetInt32(2);
                    posicion_Jugador.posicion = reader.GetString(3);
                    posicion_Jugador.numeroCamisola = reader.GetInt32(4);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al obtener el registro del jugador");
                }
                return posicion_Jugador;
            }
        }

        public List<Posicion_Jugador> getPosiciones(int idTorneo, int idEquipo)
        {
            List<Posicion_Jugador> listJugadores = new List<Posicion_Jugador>();

            //Query a ejecutar en la base de datos
            string query = $"SP_VIEW_POSICION_JUGADOR {idTorneo}, {idEquipo}";

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
                        Posicion_Jugador posicion_Jugador = new Posicion_Jugador();

                        posicion_Jugador.id_torneo = reader.GetInt32(0);
                        posicion_Jugador.id_equipo = reader.GetInt32(1);
                        posicion_Jugador.identificacion = reader.GetInt64(2);
                        posicion_Jugador.Nombres = reader.GetString(5);
                        posicion_Jugador.posicion = reader.GetString(3);
                        posicion_Jugador.numeroCamisola = reader.GetInt32(4);

                        listJugadores.Add(posicion_Jugador);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos de los jugadores");
                }
                return listJugadores;
            }
        }

        public void addPosicion(Posicion_Jugador posicion_Jugador)
        {
            //Query para insertarla posición del jugador
            string query = "EXEC SP_INSERT_POSICION_JUGADOR @Id_Torneo, @Id_Equipo, @Identificacion, @Posicion, @NumeroCamisola";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para realizar la consulta
                    sql.Parameters.AddWithValue("@Id_Torneo", posicion_Jugador.id_torneo);
                    sql.Parameters.AddWithValue("@Id_Equipo", posicion_Jugador.id_equipo);
                    sql.Parameters.AddWithValue("@Identificacion", posicion_Jugador.identificacion);
                    sql.Parameters.AddWithValue("@Posicion", posicion_Jugador.posicion);
                    sql.Parameters.AddWithValue("@NumeroCamisola", posicion_Jugador.numeroCamisola);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();

                    MessageBox.Show("La posición del jugador ha sido agregado correctamente");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al insertar la posición del jugador");
                }
            }
        }

        public void updatePosicion(Posicion_Jugador posicion_Jugador)
        {
            //Query de actualizacion
            string query = "EXEC SP_UPDATE_POSICION_JUGADOR @Id_Torneo, @Id_Equipo, @Identificacion, @Posicion, @NumeroCamisola";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para update de entrenador
                    sql.Parameters.AddWithValue("@Id_Torneo", posicion_Jugador.id_torneo);
                    sql.Parameters.AddWithValue("Id_Equipo", posicion_Jugador.id_equipo);
                    sql.Parameters.AddWithValue("@Identificacion", posicion_Jugador.identificacion);
                    sql.Parameters.AddWithValue("@Posicion", posicion_Jugador.posicion);
                    sql.Parameters.AddWithValue("@NumeroCamisola", posicion_Jugador.numeroCamisola);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();

                    MessageBox.Show("El jugador ha sido actualizado correctamente");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al actualizar jugador");
                }
            }
        }


        public void deletePosicion(Posicion_Jugador posicion_Jugador)
        {
            //Query a ejecutar
            string query = "EXEC SP_DELETE_POSICION_JUGADOR @Identificacion, @Id_Torneo, @Id_Equipo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //Parametros necesarios por el query de delete
                    sql.Parameters.AddWithValue("@Identificacion", posicion_Jugador.identificacion);
                    sql.Parameters.AddWithValue("@Id_Torneo", posicion_Jugador.id_torneo);
                    sql.Parameters.AddWithValue("@Id_Equipo", posicion_Jugador.id_equipo);
                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El jugador ha sido eliminado del equipo y del torneo correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar el jugador");
                }
            }
        }
    }
}
