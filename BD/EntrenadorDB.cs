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
    class EntrenadorDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public Entrenador getEntrenadorById(int dpi)
        {
            //Instancia de entrenador
            Entrenador entrenador = new Entrenador();
            //Consulta de entrenador
            string query = $"SELECT * FROM ENTRENADOR WHERE DPI = {dpi}";
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
                    entrenador.dpi = reader.GetInt32(0);
                    entrenador.id_equipo = reader.GetInt32(1);
                    entrenador.nombre = reader.GetString(2);
                    entrenador.apellidos = reader.GetString(3);
                    entrenador.telefono = reader.GetString(4);
                    entrenador.fechanac = reader.GetDateTime(5);
                    entrenador.correo = reader.GetString(6);
                    entrenador.tiempo = reader.GetString(7);
                    entrenador.salario = reader.GetString(8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al obtener el registro de entrenador");
                }
                return entrenador;
            }
        }

        public List<Entrenador> getEntrenadores()
        {
            List<Entrenador> listEntrenador = new List<Entrenador>();

            //Query a ejecutar en la base de datos
            string query = "EXEC SP_VIEW_ENTRENADORES";
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
                        Entrenador entrenador = new Entrenador();
                        entrenador.dpi = reader.GetInt32(0);
                        entrenador.id_equipo = reader.GetInt32(1);
                        entrenador.nombre = reader.GetString(2);
                        entrenador.apellidos = reader.GetString(3);
                        entrenador.telefono = reader.GetString(4);
                        entrenador.fechanac = reader.GetDateTime(5);
                        entrenador.correo = reader.GetString(6);
                        entrenador.tiempo = reader.GetString(7);
                        entrenador.salario = reader.GetString(8);
                        listEntrenador.Add(entrenador);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del entrenador");
                }
                return listEntrenador;
            }
        }

        public List<Entrenador> searchEntrenador(int opcion, string busqueda)
        {
            //Crear instancia de entrenador
            Entrenador entrenador = new Entrenador();
            List<Entrenador> listEntrenador = new List<Entrenador>();

            //Query a ejecutar en la base de datos
            string query = "EXEC SP_SEARCH_ENTRENADOR @opcion, @busqueda";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);

                //Enviar parametro para la ejecucion del query
                sql.Parameters.AddWithValue("@opcion", opcion);
                sql.Parameters.AddWithValue("@busqueda", busqueda);
                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        entrenador.dpi = reader.GetInt32(0);
                        entrenador.id_equipo = reader.GetInt32(1);
                        entrenador.nombre = reader.GetString(2);
                        entrenador.apellidos = reader.GetString(3);
                        entrenador.telefono = reader.GetString(4);
                        entrenador.fechanac = reader.GetDateTime(5);
                        entrenador.correo = reader.GetString(6);
                        entrenador.tiempo = reader.GetString(7);
                        entrenador.salario = reader.GetString(8);
                        listEntrenador.Add(entrenador);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del entrenador");
                }
                return listEntrenador;
            }
        }

        public void optionsEquipo(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT * FROM EQUIPO", connection);
                //Lectura de datos y agregar al combo box obtenido como parametro del metodo
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}| {dr[1]}");
                }
                connection.Close();
            }
        }
        
        public void addEntrenador(Entrenador entrenador)
        {
            //Query para insertar entrenador
            string query = "EXEC SP_INSERT_ENTRENADOR @DPI, @Id_Equipo, @Nombre, @Apellidos, @Telefono, @FechaNac, @Correo, @Tiempo, @Salario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Obtener conteo de entrenador en un equipo
                    SqlCommand validacion = new SqlCommand($"SELECT COUNT(Id_Equipo) FROM ENTRENADOR WHERE Id_Equipo = {entrenador.id_equipo} GROUP BY Id_Equipo;", connection);
                    SqlCommand sql = new SqlCommand(query, connection);
                    //Conversion del dato obtenido a int
                    int conteo = Convert.ToInt32(validacion.ExecuteScalar());

                    if(conteo == 0)
                    {
                        //Parametros para realizar la consulta
                        sql.Parameters.AddWithValue("@DPI", entrenador.dpi);
                        sql.Parameters.AddWithValue("@Id_Equipo", entrenador.id_equipo);
                        sql.Parameters.AddWithValue("@Nombre", entrenador.nombre);
                        sql.Parameters.AddWithValue("@Apellidos", entrenador.apellidos);
                        sql.Parameters.AddWithValue("@Telefono", entrenador.telefono);
                        sql.Parameters.AddWithValue("@FechaNac", entrenador.fechanac);
                        sql.Parameters.AddWithValue("@Correo", entrenador.correo);
                        sql.Parameters.AddWithValue("@Tiempo", entrenador.tiempo);
                        sql.Parameters.AddWithValue("@Salario", entrenador.salario);

                        //Ejecucion del query
                        sql.ExecuteNonQuery();

                        MessageBox.Show("El entrenador ha sido agregado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El equipo ya tiene asignado un entrenador");
                    }
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al insertar el entrenador");
                }
            }
        }

        public void updateEntrenador(Entrenador entrenador)
        {
            //Query de actualizacion
            string query = "EXEC SP_UPDATE_ENTRENADOR @DPI, @Id_Equipo, @Nombre, @Apellidos, @Telefono, @FechaNac, @Correo, @Tiempo, @Salario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Obtener conteo de entrenador en un equipo
                    SqlCommand validacion = new SqlCommand($"SELECT COUNT(Id_Equipo) FROM ENTRENADOR WHERE Id_Equipo = {entrenador.id_equipo} GROUP BY Id_Equipo;", connection);
                    SqlCommand sql = new SqlCommand(query, connection);
                    //Conversion del dato obtenido a int
                    int conteo = Convert.ToInt32(validacion.ExecuteScalar());

                    //Parametros para update de entrenador
                    sql.Parameters.AddWithValue("@DPI", entrenador.dpi);
                    sql.Parameters.AddWithValue("@Id_Equipo", entrenador.id_equipo);
                    sql.Parameters.AddWithValue("@Nombre", entrenador.nombre);
                    sql.Parameters.AddWithValue("@Apellidos", entrenador.apellidos);
                    sql.Parameters.AddWithValue("@Telefono", entrenador.telefono);
                    sql.Parameters.AddWithValue("@FechaNac", entrenador.fechanac);
                    sql.Parameters.AddWithValue("@Correo", entrenador.correo);
                    sql.Parameters.AddWithValue("@Tiempo", entrenador.tiempo);
                    sql.Parameters.AddWithValue("@Salario", entrenador.salario);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                        
                    MessageBox.Show("El entrenador ha sido actualizado correctamente");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al actualizar el entrenador");
                }
            }
        }

        public void deleteEntrenador(int dpi)
        {
            //Query a ejecutar
            string query = "EXEC SP_DELETE_ENTRENADOR @DPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //Parametros necesarios por el query de delete
                    sql.Parameters.AddWithValue("@DPI", dpi);
                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El entrenador ha sido eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar el entrenador");
                }
            }
        }
    }
}
