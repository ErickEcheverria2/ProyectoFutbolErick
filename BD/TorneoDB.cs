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
   public  class TorneoDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public Torneo Gettorneo(int? id) //obtener el cliente por id 
        {
            Torneo tr = new Torneo();
            string query = " exec getidtorneo  @id";
            using (SqlConnection connection = new SqlConnection(connectionString)) //conectamos a la base 
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();


                    tr.ID_Torneo = reader.GetInt32(0); // obtenemos cada valor asignandolo a el modelo 
                 tr.nombre = reader.GetString(1);
                    tr.Inicio= reader.GetDateTime(2);
                    tr.Final= reader.GetDateTime(3);
                    tr.Tipo= reader.GetString(4);
                    tr.edad_minima= reader.GetInt32(5);
                    tr.edad_Maxima= reader.GetInt32(6);
                    tr.puntos_partido_ganado= reader.GetInt32(7);
                    tr.puntos_partido_perdido= reader.GetInt32(8);
                    tr.puntos_partido_empatado = reader.GetInt32(9);
                    tr.Tipo_de_Campo = reader.GetInt32(11);
                    tr.precio= reader.GetDouble(10);



                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex) // si sucede algo que se considere como error lo mostraremos aca 
                {

                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return tr;
        }
        public List<Torneo> GetTorneos()
        {
            List<Torneo> tlist = new List<Torneo>();
            string query = "exec vertorneos";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Torneo tr = new Torneo();
                        tr.ID_Torneo = reader.GetInt32(0); // obtenemos cada valor asignandolo a el modelo 
                        tr.nombre = reader.GetString(1);
                        tr.Inicio = reader.GetDateTime(2);
                        tr.Final = reader.GetDateTime(3);
                        tr.Tipo = reader.GetString(4);
                        tr.edad_minima = reader.GetInt32(5);
                        tr.edad_Maxima = reader.GetInt32(6);
                        tr.puntos_partido_ganado = reader.GetInt32(7);
                        tr.puntos_partido_perdido = reader.GetInt32(8);
                        tr.puntos_partido_empatado = reader.GetInt32(9);
                        tr.Tipo_de_Campo = reader.GetInt32(11);
                        tr.precio = reader.GetDouble(10);
                        tlist.Add(tr);
                    }
                    reader.Close();//cerramos el lector
                    connection.Close(); //cerramos la conexion 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Advertencia. " + ex.Message);
                }

            }
            return tlist;
        }
        public void Addctr(Torneo tr) //agregamos un torneo 
        {
            string query = $"exec instorneo @name,@inicio,@final,@tp,@edmn,@edmx,@pga,@ppe,@pemp,@campo,@precio";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
              
                sql.Parameters.AddWithValue("@name", tr.nombre); //asigamos los valores que se insertaran al script 
                sql.Parameters.AddWithValue("@inicio", tr.Inicio);
                sql.Parameters.AddWithValue("@final", tr.Final);
                sql.Parameters.AddWithValue("@tp", tr.Tipo);
                sql.Parameters.AddWithValue("@edmn", tr.edad_minima);
                sql.Parameters.AddWithValue("@edmx", tr.edad_Maxima);
                sql.Parameters.AddWithValue("@pga", tr.puntos_partido_ganado);
                sql.Parameters.AddWithValue("@ppe", tr.puntos_partido_perdido);
                sql.Parameters.AddWithValue("@pemp", tr.puntos_partido_empatado);
                sql.Parameters.AddWithValue("@campo", tr.Tipo_de_Campo);
                sql.Parameters.AddWithValue("@precio", tr.precio);

                try
                {
                    connection.Open(); //abrimos conexion
                    sql.ExecuteNonQuery(); //ejecutamos query 
                    connection.Close(); //cerramosla conexion
                    MessageBox.Show("Torneo    agregado correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el Torneo a la base de datos" + ex.Message);
                }
            }
        }
        public void UPDTR(int id , string name, DateTime inicio , DateTime final , string tp , int edmn , int edmx , int pga , int ppe , int pemp,int campo) //agregamos un cliente nuevo
        {
            string query = $"exec updtorneo @id, @name,@inicio,@final,@tp,@edmn,@edmx,@pga,@ppe,@pemp,@campo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection); //asigamos los valores que se insertaran al script 
                sql.Parameters.AddWithValue("@id", id);
                sql.Parameters.AddWithValue("@name",name);
                sql.Parameters.AddWithValue("@inicio", inicio);
                sql.Parameters.AddWithValue("@final", final);
                sql.Parameters.AddWithValue("@tp", tp);
                sql.Parameters.AddWithValue("@edmn", edmn);
                sql.Parameters.AddWithValue("@edmx", edmx);
                sql.Parameters.AddWithValue("@pga", pga);
                sql.Parameters.AddWithValue("@ppe", ppe);
                sql.Parameters.AddWithValue("@pemp", pemp);
                sql.Parameters.AddWithValue("@campo", campo);

                try
                {
                    connection.Open(); //abrimos conexion
                    sql.ExecuteNonQuery(); //ejecutamos query 
                    connection.Close(); //cerramosla conexion
                    MessageBox.Show("Torneo    Modificado  correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el Torneo a la base de datos" + ex.Message);
                }
            }
        }

        public void DeleteTR (int? id )
        {
            {
                string query = "exec dtltorneo @id";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open(); //abrimos conexion
                        command.ExecuteNonQuery(); //ejecutamos query 
                        connection.Close(); //cerramosla conexion
                        MessageBox.Show("Registro eliminado correctamente");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el Torneeo en la base de datos" + ex.Message);
                    }
                }
            }
        }
        public int maxid() //buscamos el siguiente id a usar 
        {

            int codigo = 0;
            string query = "exec newidt";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {


                        codigo = reader.GetInt32(0);





                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el tipo de producto. " + ex.Message);
                }

            }

            return (codigo + 1);

        }

        //        
    }
}
