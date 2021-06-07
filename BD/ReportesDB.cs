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
    public class ReportesDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public List<Posiciones> tablageneral(int? id )
        {
            List<Posiciones> tablageneral = new List<Posiciones>();

            //Procedimiento almacenado a ejecutar
            string query = "EXEC  tablageneral @id  ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id",id);
                try
                {
                    connection.Open();
                    //Lectura de los registros obtenidos en la consulta
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //Almacenamiento de datos y agregar a lista de productos
                        Posiciones pos = new Posiciones();
                        pos.Equipo = reader.GetString(0);
                        pos.PJ = reader.GetInt32(1);
                        pos.PG = reader.GetInt32(2);
                        pos.PP = reader.GetInt32(3);
                        pos.PE = reader.GetInt32(4);
                        pos.GF = reader.GetInt32(5);
                        pos.GC = reader.GetInt32(6);
                        pos.DF = reader.GetInt32(7);
                        pos.pts = reader.GetInt32(8);

                        tablageneral.Add(pos);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede acceder a los registros");
                }
            }
            return tablageneral;
        
    }

        public List<Posiciones> TablaVisita(int? id)
        {
            List<Posiciones> visita = new List<Posiciones>();

            //Procedimiento almacenado a ejecutar
            string query = "EXEC  tablavisitante @id  ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    //Lectura de los registros obtenidos en la consulta
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //Almacenamiento de datos y agregar a lista de productos
                        Posiciones pos = new Posiciones();
                        pos.Equipo = reader.GetString(0);
                        pos.PJ = reader.GetInt32(1);
                        pos.PG = reader.GetInt32(2);
                        pos.PP = reader.GetInt32(3);
                        pos.PE = reader.GetInt32(4);
                        pos.GF = reader.GetInt32(5);
                        pos.GC = reader.GetInt32(6);
                        pos.DF = reader.GetInt32(7);
                        pos.pts = reader.GetInt32(8);

                        visita.Add(pos);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede acceder a los registros");
                }
            }
            return visita;

        }

        public List<Posiciones> TablaLocal(int? id)
        {
            List<Posiciones> local = new List<Posiciones>();

            //Procedimiento almacenado a ejecutar
            string query = "EXEC  tablalocal @id  ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    //Lectura de los registros obtenidos en la consulta
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //Almacenamiento de datos y agregar a lista de productos
                        Posiciones pos = new Posiciones();
                        pos.Equipo = reader.GetString(0);
                        pos.PJ = reader.GetInt32(1);
                        pos.PG = reader.GetInt32(2);
                        pos.PP = reader.GetInt32(3);
                        pos.PE = reader.GetInt32(4);
                        pos.GF = reader.GetInt32(5);
                        pos.GC = reader.GetInt32(6);
                        pos.DF = reader.GetInt32(7);
                        pos.pts = reader.GetInt32(8);

                        local.Add(pos);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede acceder a los registros");
                }
            }
            return local;

        }

    }
}
