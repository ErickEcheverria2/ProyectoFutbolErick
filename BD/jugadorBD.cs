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
    public class jugadorBD
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public List<jugador> Getjugadores()
        {
            List<jugador> listj = new List<jugador>();
            string query = "SELECT * FROM JUGADOR ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open(); //apertura de  la conexion y muestreo de datos en el modelo
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        jugador jr = new jugador();
                        jr.Identificacion = reader.GetInt64(0);
                        jr.nombres = reader.GetString(1);
                        jr.apellidos = reader.GetString(2);
                        jr.fecha_naciemiento = reader.GetDateTime(3);
                        jr.direccion = reader.GetString(4);
                        jr.Nacionalidad = reader.GetString(5);
                        jr.correo = reader.GetString  (6);
                        jr.Telefono = reader.GetString  (7);                            
                        jr.Menor_de_edad = reader.GetBoolean(8);

                        listj.Add(jr);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return listj;


        }

            public void addjugador(jugador jr)
        {
            string query = $"	 exec insjs @id  , @nb , @ap ,@fn,@drc  , @nac , @cr , @tf,@medad ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                sql.Parameters.AddWithValue("@id", jr.Identificacion); //asigamos los valores que se insertaran al script 
                sql.Parameters.AddWithValue("@nb", jr.nombres);
                sql.Parameters.AddWithValue("@ap", jr.apellidos);
                sql.Parameters.AddWithValue("@fn", jr.fecha_naciemiento);
                sql.Parameters.AddWithValue("@drc", jr.direccion);
                sql.Parameters.AddWithValue("@nac", jr.Nacionalidad);
                sql.Parameters.AddWithValue("@cr", jr.correo);
                sql.Parameters.AddWithValue("@tf", jr.Telefono);
                sql.Parameters.AddWithValue("@medad", jr.Menor_de_edad);
                try
                {
                    connection.Open(); //abrimos conexion
                    sql.ExecuteNonQuery(); //ejecutamos query 
                    connection.Close(); //cerramosla conexion
                    MessageBox.Show("Jugador    agregado correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el jugador a la base de datos" + ex.Message);
                }
            }
        }

        public jugador jugadorid(long? id)
        {
            //Crear instancia de equipo
            jugador jr = new jugador();

            //Query a ejecutar en la base de datos
            string query = " exec verjugadoresporid @id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);

                //Enviar parametro para la ejecucion del query
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    jr.Identificacion = reader.GetInt64(0);
                    jr.nombres = reader.GetString(1);
                    jr.apellidos = reader.GetString(2);
                    jr.fecha_naciemiento = reader.GetDateTime(3);
                    jr.direccion = reader.GetString(4);

                    jr.Nacionalidad = reader.GetString(5);
                    jr.correo = reader.GetString(6);
                    jr.Telefono = reader.GetString(7);
                    jr.Menor_de_edad = reader.GetBoolean(8);
                    connection.Close(); //cerramosla conexion
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del jugador");
                }
                return jr;
            }
        }

        public void deletejs(long? id)
        {
            //Query a ejecutar
            string query = "EXEC dtljs @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    MessageBox.Show("El jugador ha sido eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar el jugador" +
                        "");
                }
            }
        }


        public void updtjugador(jugador jr)
        {
            //Query de actualizacion
            string query = " exec updjs  @id  , @nb , @ap ,@fn,@drc  , @nac , @cr , @tf,@medad";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para update de equipo
                    sql.Parameters.AddWithValue("@id", jr.Identificacion); //asigamos los valores que se insertaran al script 
                    sql.Parameters.AddWithValue("@nb", jr.nombres);
                    sql.Parameters.AddWithValue("@ap", jr.apellidos);
                    sql.Parameters.AddWithValue("@fn", jr.fecha_naciemiento);
                    sql.Parameters.AddWithValue("@drc", jr.direccion);
                    sql.Parameters.AddWithValue("@nac", jr.Nacionalidad);
                    sql.Parameters.AddWithValue("@cr", jr.correo);
                    sql.Parameters.AddWithValue("@tf", jr.Telefono);
                    sql.Parameters.AddWithValue("@medad", jr.Menor_de_edad);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El jugador  ha sido actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al actualizar el jugador");
                }
            }
        }


    }
}
