using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    public class ControlArbitroDb
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public ControlArbitro GetArbitro(int? DPI_Arbitro, int idJuego)
        {
            ControlArbitro controlArbitro = new ControlArbitro();
            string query = "select * from ARBITRO_PARTIDO where DPI_Arbitro=@DPI_Arbitro AND Id_Juego = @Id_Juego";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI_Arbitro", DPI_Arbitro);
                sql.Parameters.AddWithValue("@Id_Juego", idJuego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    controlArbitro.DPI_Arbitro = reader.GetInt32(0);
                    controlArbitro.Id_Juego = reader.GetInt32(1);
                    controlArbitro.Pago = reader.GetString(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos" + ex.Message);
                }
            }
            return controlArbitro;
        }

        public List<ControlArbitro> GetArbitros(int idJuego)
        {
            List<ControlArbitro> controlArbitro = new List<ControlArbitro>();
            string query = $"select * from ARBITRO_PARTIDO where Id_Juego = {idJuego}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        ControlArbitro controlArbitroo = new ControlArbitro();
                        controlArbitroo.DPI_Arbitro = reader.GetInt32(0);
                        controlArbitroo.Id_Juego = reader.GetInt32(1);
                        controlArbitroo.Pago = reader.GetString(2);
                        controlArbitro.Add(controlArbitroo);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron obtener los datos" + ex.Message);
                }

            }
            return controlArbitro;
        }

        public void seleccionar(ComboBox combo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                combo.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("select * from ARBITRO", connection);
                SqlDataReader dataread = sql.ExecuteReader();
                while (dataread.Read())
                {
                    combo.Items.Add($"{dataread[0]}| {dataread[1]}");
                }
                connection.Close();
            }
        }


        public void AddControl(ControlArbitro controlArbitro)
        {
            string query = $"INSERT INTO ARBITRO_PARTIDO(DPI_Arbitro, Id_Juego, Pago) VALUES (@DPI_Arbitro, @Id_Juego, @Pago)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                try
                {
                    connection.Open();
                    SqlCommand sql = new SqlCommand(query, connection);

                    sql.Parameters.AddWithValue("@DPI_Arbitro", controlArbitro.DPI_Arbitro);
                    sql.Parameters.AddWithValue("@Id_Juego", controlArbitro.Id_Juego);
                    sql.Parameters.AddWithValue("@Pago", controlArbitro.Pago);


                    sql.ExecuteNonQuery();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el Arbitro" + ex.Message);
                }
            }
        }

        public void UpdateControl(long? DPI_Arbitro, int Id_Juego, string Pago)
        {
            string query = "UPDATE ARBITRO_PARTIDO set DPI_Arbitro=@DPI_Arbitro ,Id_Juego=@Id_Juego, Pago=@Pago WHERE DPI_Arbitro=@DPI_Arbitro and Id_Juego=@Id_Juego";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DPI_Arbitro", DPI_Arbitro);
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@Pago", Pago);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitro Actualizado");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el arbitro" + ex.Message);
                }
            }
        }


        public void DeleteControl(int? DPI_ARBITRO, int IdJuego)
        {
            string query = " delete from ARBITRO_PARTIDO where DPI_Arbitro=@DPI_Arbitro and Id_Juego=@Id_Juego";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DPI_Arbitro", DPI_ARBITRO);
                command.Parameters.AddWithValue("@Id_Juego", IdJuego);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitro Eliminado");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar " + ex.Message);
                }
            }

        }
    }
}
