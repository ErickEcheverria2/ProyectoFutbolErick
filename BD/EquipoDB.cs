using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    class EquipoDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public List<Equipo> loadTableData()
        {
            //Inicializar lista de tipo EquipoDB
            List<Equipo> listEquipos = new List<Equipo>();

            //Procedimiento almacenado a ejecutar
            string query = "EXEC SP_VIEW_EQUIPOS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //Lectura de los registros obtenidos en la consulta
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //Almacenamiento de datos y agregar a lista de productos
                        Equipo equipo = new Equipo();
                        equipo.id_equipo = reader.GetInt32(0);
                        equipo.nombre = reader.GetString(1);
                        equipo.cantidadJugadores = reader.GetInt32(2);
                        equipo.representante = reader.GetString(3);
                        
                        listEquipos.Add(equipo);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede acceder a los registros");
                }
            }
            return listEquipos;
        }

        public void addEquipo(Equipo equipo)
        {
            //Query para insertar equipo
            string query = "EXEC SP_INSERT_EQUIPO @Nombre, @CantidadJugadores, @Representante";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                    SqlCommand sql = new SqlCommand(query, connection);

                    //Parametros para realizar la consulta
                    sql.Parameters.AddWithValue("@Nombre", equipo.nombre);
                    sql.Parameters.AddWithValue("@CantidadJugadores", equipo.cantidadJugadores);
                    sql.Parameters.AddWithValue("@Representante", equipo.representante);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El equipo ha sido agregado correctamente", "Equipo Agregado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar el equipo");
                }
            }
        }

        public void updateEquipo(Equipo equipo)
        {
            //Query de actualizacion
            string query = "EXEC SP_UPDATE_EQUIPO @Id_Equipo, @Nombre, @CantidadJugadores, @Representante";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand(query, connection);
                    
                    //Parametros para update de equipo
                    sql.Parameters.AddWithValue("@Id_Equipo", equipo.id_equipo);
                    sql.Parameters.AddWithValue("@Nombre", equipo.nombre);
                    sql.Parameters.AddWithValue("@CantidadJugadores", equipo.cantidadJugadores);
                    sql.Parameters.AddWithValue("@Representante", equipo.representante);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El equipo ha sido actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al actualizar el equipo");
                }
            }
        }

        public void deleteEquipo(int id)
        {
            //Query a ejecutar
            string query = "EXEC SP_DELETE_EQUIPO @Id_Equipo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    //Parametros necesarios por el query de delete
                    sql.Parameters.AddWithValue("@Id_Equipo", id);

                    //Ejecucion del query
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El equipo ha sido eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar el equipo");
                }
            }
        }

        public Equipo getEquipoById(int id)
        {
            //Crear instancia de equipo
            Equipo equipo = new Equipo();

            //Query a ejecutar en la base de datos
            string query = "SELECT * FROM EQUIPO WHERE Id_Equipo = @Id_Equipo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Instancia de la isntruccion SQL
                SqlCommand sql = new SqlCommand(query, connection);

                //Enviar parametro para la ejecucion del query
                sql.Parameters.AddWithValue("@Id_Equipo", id);
                try
                {
                    //Abrir conexion a la base de datos y realizar lectura de los resultados del query
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    equipo.id_equipo = reader.GetInt32(0);
                    equipo.nombre = reader.GetString(1);
                    equipo.cantidadJugadores = reader.GetInt32(2);
                    equipo.representante = reader.GetString(3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron obtener los datos del equipo");
                }
                return equipo;
            }
        }
    }
}
