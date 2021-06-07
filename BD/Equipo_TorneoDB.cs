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
    class Equipo_TorneoDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public void getequipo(ComboBox cb)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM EQUIPO", connection);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add($"{dr[0]}| {dr[1]}");
                }
                connection.Close();
            }
        }

        public void addTorneo_Equipo(Equipo_Torneo equipo_Torneo, int Id_Torneo)
        {
            string query = "EXEC INSERT_TORNEO_EQUIPO @Id_Torneo, @Id_Equipo, @CostoInscripcion ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand sql = new SqlCommand(query, connection);

                    sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                    sql.Parameters.AddWithValue("@Id_Equipo", equipo_Torneo.id_equipo);
                    sql.Parameters.AddWithValue("@CostoInscripcion", equipo_Torneo.costoinscripcion);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Equipo Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar equipo a un torneo " + error.Message, "ERROR");
                }
            }
        }
        public List<Equipo_Torneo> Gettorneoequipo(int Id_Torneo)
        {
            List<Equipo_Torneo> list_equipo_Torneos = new List<Equipo_Torneo>();
            string query = "EXEC VIEWTORNEO_EQUIPO @Id_Torneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Equipo_Torneo equipo_Torneos = new Equipo_Torneo();
                        equipo_Torneos.id_torneo = reader.GetInt32(0);
                        equipo_Torneos.id_equipo = reader.GetInt32(1);
                        equipo_Torneos.Equipo = reader.GetString(3);
                        equipo_Torneos.costoinscripcion = reader.GetString(2);
                        list_equipo_Torneos.Add(equipo_Torneos);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return list_equipo_Torneos;
        }
        public Equipo_Torneo Get_equipo_torneo(int Id_equipo, int Id_Torneo)
        {
            Equipo_Torneo equipo_torneo = new Equipo_Torneo();
            string query = "SELECT * FROM TORNEO_EQUIPO WHERE Id_Equipo = @Id_Equipo and Id_Torneo = @Id_Torneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_equipo);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    equipo_torneo.costoinscripcion = reader.GetString(2);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return equipo_torneo;
            }
        }
        public void UpdateTorneo(Equipo_Torneo equipo_Torneo)
        {
            string query = "EXEC  UPDATE_TORNEO_EQUIPO @Id_Torneo, @Id_Equipo, @CostoInscripcion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Torneo", equipo_Torneo.id_torneo);
                command.Parameters.AddWithValue("@Id_Equipo", equipo_Torneo.id_equipo);
                command.Parameters.AddWithValue("@CostoInscripcion", equipo_Torneo.costoinscripcion);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Dato actualizado correctmanete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar", ex.Message);
                }
            }
        }
        public void Deleteequipo(int Id_Equipo, int Id_Torneo)
        {
            string query = "EXEC DELETE_TORNEO_EQUIPO @Id_Equipo, @Id_Torneo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                command.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar", ex.Message);
                }
            }
        }

        int cantidad;

        public int verificarJugadoresTorneoExistente(int Id_Torneo, int? Id_Equipo)
        {
            string query = "exec verificarJugadoresTorneoExistente @Id_Torneo, @Id_Equipo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
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
    }

}