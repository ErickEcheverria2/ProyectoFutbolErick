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
    public class PunteoDB
    {
        private string connectionstring = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public void addpunteo(Puntos pts)
        {

            string query = "exec insertpuntos @id  , @el  , @ev  , @pl  , @pv   ,   @gv,@gl";//insercicon de los puntos por partido 
            
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", pts.id_juego);
                sql.Parameters.AddWithValue("@el", pts.id_equipo_local );
                sql.Parameters.AddWithValue("@ev", pts.id_equipo_visita );
                sql.Parameters.AddWithValue("@pl", pts.punteo_equipo_local);
                sql.Parameters.AddWithValue("@pv", pts.punteo_equipo_visita );
                sql.Parameters.AddWithValue("@gl", pts.marcador_local );
                sql.Parameters.AddWithValue("@gv", pts.marcador_visita );

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Puntos Agregados correctamente ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }
        }

        int cantidad;

        public int verificarSiPunteoExiste(int Id_Local, int Id_Visita)
        {
            string query = "exec verificarSiPunteoExiste @Id_Local, @Id_Visita ";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Local", Id_Local);
                sql.Parameters.AddWithValue("@Id_Visita", Id_Visita);
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
                    MessageBox.Show("Error al verificar la existencia del Punteo " + ex.Message);
                }
            }
            return cantidad;
        }
    }
        
   }


