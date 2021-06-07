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
  public   class GolesDB
    {
        private string connectionstring = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public List<goles> getgoles(int id)
        {
            List<goles> goles = new List<goles>();

            //Query a ejecutar en la base de datos
            string query = "EXEC vergoles @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        goles gg = new goles();
                        gg.id_Gol = reader.GetInt32(0);
                        gg.id_juego = reader.GetInt32(1);
                        gg.Identifiacion = reader.GetInt32(2);
                        gg.Nombre_Jugador = reader.GetString(3); //agregamos el nuevo valor donde se requiere leer , en el rden que se llama en el select
                        gg.tipo = reader.GetString(4);
                        gg.tiempo = Convert.ToInt32(reader.GetString(5));
                        goles.Add(gg);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del goles");
                }
                return goles;
            }
        }


        public  goles getgol(int id)
        {
             
            goles gg = new goles();
            //Query a ejecutar en la base de datos
            string query = "EXEC getgolbyid @id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                       
                        gg.id_Gol = reader.GetInt32(0);
                        gg.id_juego = reader.GetInt32(1);
                        gg.Identifiacion = reader.GetInt32(2);
                        gg.tipo = reader.GetString(3);
                        gg.tiempo = Convert.ToInt32(reader.GetString(4));
                       
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del goles");
                }
                return gg;
            }
        }
        public void add(goles  gg)
        {
            //query
            string query = " exec goles @jg,@dpi,@tipo, @tiemp";

            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion); //conexion y datos a enviar a guardar
                sql.Parameters.AddWithValue("@jg", gg.id_juego);
                sql.Parameters.AddWithValue("@dpi", gg.Identifiacion);
                sql.Parameters.AddWithValue("@tipo", gg.tipo);
                sql.Parameters.AddWithValue("@tiemp", gg.tiempo);
               

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Gol Agregado correctamente ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }
        }

        public void update(goles gg)
        {
            //query
            string query = " exec golesupd @id,@dpi,@tipo, @tiemp";

            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion); //conexion y datos a enviar a guardar
                sql.Parameters.AddWithValue("@id", gg.id_Gol);
                sql.Parameters.AddWithValue("@dpi", gg.Identifiacion);
                sql.Parameters.AddWithValue("@tipo", gg.tipo);
                sql.Parameters.AddWithValue("@tiemp", gg.tiempo);


                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Gol Modificado correctamente ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el modificar " + ex.Message);
                }

            }
        }

    }
}
