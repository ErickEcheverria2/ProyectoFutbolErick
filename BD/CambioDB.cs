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
   public class CambioDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        public void Buscar_Partido_combox(ComboBox cb)
        {
            string query = "exec getPartido";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[0].ToString());
                }


                connec.Close();
                cb.Items.Insert(0, "Selecciona una opcion");
                cb.SelectedIndex = 0;


            }
        }
        public string[] captarinfo(int id_juego)
        {
            string[] resultado = null;
            string query = "select*from PARTIDO where Id_Juego='" + id_juego + "'";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);


                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    string[] valores =
                    {

                        reader[1].ToString()
                       

                    };
                    resultado = valores;
                }


                connec.Close();
            }

            return resultado;
        }



        public string[] infoJugadores(int id_identificacion)
        {
            string[] resultado = null;
            string query = " nombre_jugador @identificacion= '" + id_identificacion+"'";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);


                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    string[] valores =
                    {

                        reader[1].ToString()
                        

                    };
                    resultado = valores;
                }


                connec.Close();
            }

            return resultado;
        }

        public void Buscar_Jugafor_combox(ComboBox cb,int id_equipo)
        {
            string query = "exec identificacionJugadores @id_juego= '" + id_equipo + "'";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[0].ToString());
                }


                connec.Close();
                cb.Items.Insert(0, "Selecciona una opcion");
                cb.SelectedIndex = 0;


            }
        }



        public List<cambio> manejoCambios(int? id)
        {
            List<cambio> cambiosJug = new List<cambio>();
            string query = "exec getCambio @id";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cambio cambios = new cambio();
                        cambios.id_cambio = reader.GetInt32(0);
                        cambios.id_juego = reader.GetInt32(1);
                        cambios.dpi_jugEntra = reader.GetInt32(2);
                        cambios.dpi_jugSale = reader.GetInt32(3);
                        cambios.Nombre_Entrada = reader.GetString(4);
                        cambios.Nombre_Salida = reader.GetString(5);
                        cambios.Tiempo_Entrada = reader.GetString(6);
                        cambios.Tiempo_Salida = reader.GetString(7);

                        cambiosJug.Add(cambios);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return cambiosJug;
        }

        // metodo ingreso de cambios
        public void Insertar_Cambios(cambio cambioo)
        {
            string query = "exec insertar_cambios @id_juego,@DPIEntrada, @DPISalida,@tiempoEntrada,@tiempoSalida";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id_juego", cambioo.id_juego);
                sql.Parameters.AddWithValue("@DPIEntrada", cambioo.dpi_jugEntra);
                sql.Parameters.AddWithValue("@DPISalida", cambioo.dpi_jugSale);
                sql.Parameters.AddWithValue("@tiempoEntrada", cambioo.Tiempo_Entrada);
                sql.Parameters.AddWithValue("@tiempoSalida", cambioo.Tiempo_Salida);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Cambio guardado correctamente");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }

        //metodo para llenar los combobox con nombres de equipos 
        public void buscar_equipos(ComboBox cc, int id_equipo, int id_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cc.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec nombres_equipos @id_juego='" + id_equipo + "'" + "," + "@id_torneo='" + id_torneo + "'", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cc.Items.Add(dr[0].ToString());
                    cc.Items.Add(dr[1].ToString());

                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                cc.Items.Insert(0, "-Seleccione el equipo-");
                cc.SelectedIndex = 0;
            }
        }


        //metodo para llenar los combobox con los jugadores que existen dentro de los equipos filtrados por torneo
        public void busqueda_tabla_jugadoress_por_equipo(ComboBox cc, string nombre, int id_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cc.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec buscar_jugadores_equipo_torneo @nombre='" + nombre + "'" + "," + "@id_torneo='" + id_torneo + "'", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cc.Items.Add(dr[0].ToString());
                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                cc.Items.Insert(0, "Seleccione un Jugador");
                cc.SelectedIndex = 0;
            }
        }




        //metodo para poner en texbox el dpi del jugador y el  numero del equipo al que pertence segun su nombre
        public string[] buscar_identificacion_por_nombre(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec buscar_identificacion_por_nombre @nombre='" + nombre + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        dr[0].ToString()


                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }




        //Buscar informacion
        public cambio buscar(int? id)
        {
            cambio cambioo = new cambio();
            string query = "exec Seleccionar_cambio @id";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    cambioo.id_cambio = reader.GetInt32(0);
                    cambioo.id_juego = reader.GetInt32(1);
                    cambioo.dpi_jugEntra = reader.GetInt32(2);
                    cambioo.dpi_jugSale = reader.GetInt32(3);
                    cambioo.Nombre_Entrada = reader.GetString(4);
                    cambioo.Nombre_Salida = reader.GetString(5);
                    cambioo.equipo = reader.GetString(6);
                    cambioo.Tiempo_Entrada = reader.GetString(7);
                    cambioo.Tiempo_Salida = reader.GetString(8);
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return cambioo;
            }
        }

        public void actualizar_cambio(int? id_cambio,int id_Juego,int dpi_entra,int dpi_sale,String entra, String sale)
        {
            //update TIPO_PRODUCTO  set nombre =@nombre where TIPO_PRODUCTO=@id

            string query = "exec actualizar_cambios @id_cambio,@id_juego, @dpi_entra,@dpi_sale,@tiempo_entrada,@tiempo_salida";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id_cambio", id_cambio);
                command.Parameters.AddWithValue("@id_juego", id_Juego);
                command.Parameters.AddWithValue("@dpi_entra", dpi_entra );
                command.Parameters.AddWithValue("@dpi_sale", dpi_sale);
                command.Parameters.AddWithValue("@tiempo_entrada", entra);
                command.Parameters.AddWithValue("@tiempo_salida", sale);


                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Actualizacion Realizada ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en actualizacion" + ex.Message);
                }

            }
        }

        public void eliminar_cambio(int? id)
        {
          
            string query = "exec eliminar_cambio @id_cambio";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id_cambio", id);
                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se a eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en eliminar " + ex.Message);
                }

            }
        }






    }
}
