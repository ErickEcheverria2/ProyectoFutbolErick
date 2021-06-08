using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Administracion_Torneos.BD
{
   public class listaJugadoresDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public List<listaJugadores> Getjugadores()
        {
            List<listaJugadores> listj = new List<listaJugadores>();
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
                        listaJugadores jr = new listaJugadores();
                        jr.Identificacion = reader.GetInt64(0);
                        jr.nombres = reader.GetString(1);
                        jr.apellidos = reader.GetString(2);
                        jr.fecha_naciemiento = reader.GetDateTime(3);
                        jr.direccion = reader.GetString(4);
                        jr.Nacionalidad = reader.GetString(5);
                        jr.correo = reader.GetString(6);
                        jr.Telefono = reader.GetString(7);
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

    }
}
