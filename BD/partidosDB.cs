using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
namespace Administracion_Torneos.BD
{
    public class partidosDB
    {
        private string connectionstring = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");




        public List<Equipo_Torneo> manejoPartidos(int? id)
        {
            List<Equipo_Torneo> partidos = new List<Equipo_Torneo>();
            string query = "exec getEquipos @id ";
              using (SqlConnection conexion = new SqlConnection(connectionstring))
              {

                  SqlCommand sql = new SqlCommand(query, conexion);
                  sql.Parameters.AddWithValue("@id", id);
                try
                  {
                      conexion.Open(); //apertura de la conexion 
                      SqlDataReader reader = sql.ExecuteReader();
                      while (reader.Read())
                      {
                        Equipo_Torneo partidoss = new Equipo_Torneo();  //resgistro de datos en el modelo para agregarlo a un lista 
                        partidoss.id_torneo= reader.GetInt32(0);
                        partidoss.id_equipo = reader.GetInt32(1);
                        partidoss.costoinscripcion = reader.GetString(2);


                        partidos.Add(partidoss);
                      }
                      reader.Close();
                      conexion.Close();

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("Error" + ex.Message);
                  }
              }
              return partidos;
          }
           
        public  int  Guardar_lista(partidos listaPartidos)
        {
            string query = "exec ingresoJornada @idT,@EL,@Ev";  //ejecutar el script de insert 
            int validar = 0;
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@idT", listaPartidos.id_torneo);
                sql.Parameters.AddWithValue("@EL", listaPartidos.id_Equipo_local);
                sql.Parameters.AddWithValue("@Ev", listaPartidos.id_Equipo_visita);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();

                    validar = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }
            return validar;

        }

        public List<partidos> listadoJornadas(int? id)
        {
            List<partidos> partidos = new List<partidos>();  //listar los partidos por torneo 
            string query = "exec getListaPartidos @id ";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        partidos partidoss = new partidos();  //obtencion de los datos 
                        partidoss.id_juego = reader.GetInt32(0);
                        partidoss.id_torneo = reader.GetInt32(1);
                        partidoss.id_Equipo_local = reader.GetInt32(2);
                        partidoss.EquipoLocal = reader.GetString(4);
                        partidoss.EquipoVisita = reader.GetString(5);
                        partidoss.id_Equipo_visita = reader.GetInt32(3);
                        partidoss.fecha = reader.GetDateTime(6);
                        partidoss.hora_inicio = reader.GetTimeSpan(7);
                        partidoss.hora_fin = reader.GetTimeSpan(8);
                        partidoss.marcador_local = reader.GetInt32(9);
                        partidoss.marcador_visita = reader.GetInt32(10);
                        partidoss.jugado = reader.GetBoolean(11);

                        partidos.Add(partidoss);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
            return partidos;
        }


        public  void updjornada(int? id, DateTime fc , DateTime inn, DateTime fn , int gl , int gv )
        {
            List<partidos> partidos = new List<partidos>();
            string query = "exec editjornada  @id , @fc  , @in , @fn  , @gl , @gv  ";  // editar las jornadas ya existentes 
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                sql.Parameters.AddWithValue("@fc", fc);//dar valores a lo asignado 
                sql.Parameters.AddWithValue("@in", inn);
                sql.Parameters.AddWithValue("@fn", fn);
                sql.Parameters.AddWithValue("@gl", gl);
                sql.Parameters.AddWithValue("@gv", gv);
                try
                {
                    
                    
                        conexion.Open();
                        sql.ExecuteNonQuery();
                        conexion.Close();
                    MessageBox.Show("Marcador actualizado");

                  
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
             
        }

        public partidos Jornadas(int? id)
        {
            partidos partidoss = new partidos();
            string query = "exec getdata @id "; //obtiene los datos de una jornada especifica
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
               

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        partidoss.id_juego = reader.GetInt32(0);
                        partidoss.id_torneo = reader.GetInt32(1);
                        partidoss.id_Equipo_local = reader.GetInt32(2);
                        partidoss.id_Equipo_visita = reader.GetInt32(3); //obtencion de los datos 
                        partidoss.fecha = reader.GetDateTime(4);
                        partidoss.hora_inicio = reader.GetTimeSpan(5);
                        partidoss.hora_fin = reader.GetTimeSpan(6);
                        partidoss.marcador_local = reader.GetInt32(7);
                        partidoss.marcador_visita = reader.GetInt32(8);
                        partidoss.jugado = reader.GetBoolean(9);

                   
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
            return partidoss;
        }

        public void addControlCancha(ControlCancha controlCancha)
        {
            //Query para insertar la cancha
            string query = "EXEC SP_INSERT_CONTROL_CANCHA @Status_, @NoCancha, @Id_Juego"; //iserta la cancha que se selecciona 

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para realizar la consulta
                    sql.Parameters.AddWithValue("@Status_", "Finalizado");
                    sql.Parameters.AddWithValue("@NoCancha", controlCancha.noCancha);
                    sql.Parameters.AddWithValue("@Id_Juego", controlCancha.id_juego);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al insertar la cancha");
                }
            }
        }
        public void getCanchas(ComboBox cb)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM CANCHA", connection);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add($"{dr[0]}| {dr[1]}");
                }
                connection.Close();
            }
        }

        public void dtl(int id )
        {
            //Query a ejecutar
            string query = "EXEC dtl @id"; // elimina los puntos dados a la jornada si se modifica el marcador 

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    //Parametros necesarios por el query de delete
                    sql.Parameters.AddWithValue("@id", id);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    
                }
                catch (Exception)
                {
                    
                }
            }
        }

        public void dtlg(int? id)
        {
            //Query a ejecutar
            string query = "EXEC dtlgoles @id"; // elimina los goles si se modifica el marcador 

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    //Parametros necesarios por el query de delete
                    sql.Parameters.AddWithValue("@id", id);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception)
                {

                }
            }
        }

    }
}
