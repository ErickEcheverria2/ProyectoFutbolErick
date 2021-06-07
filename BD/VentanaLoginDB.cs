using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class VentanaLoginDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        SqlConnection conexion;

        //verifcar conexion
        public void openConexion()
        {
            try
            {
                conexion = new SqlConnection(connectionString);
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito");
            }
            catch
            {
                MessageBox.Show("NO SEA REALIZADO LA CONEXION");
            }
        }

        int cantidad;

        public int verificarUsuarioExistente(string nombre_Usuario)
        {
            string query = "exec verificarUsuarioExistente @nombre_Usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
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
                    MessageBox.Show("Error al verificar el usuario en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        string texto;

        public string obtenerContrasenaDeUsuario(string nombre_Usuario)
        {
            string query = "exec obtenerContrasenaDeUsuario @nombre_Usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        texto = reader.GetString(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al verificar el usuario en la base de datos " + ex.Message);
                }
            }
            return texto;
        }

        public string obtenerTipoDeUsuario(string nombre_Usuario)
        {
            string query = "exec obtenerTipoDeUsuario @nombre_Usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        texto = reader.GetString(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al verificar el usuario en la base de datos " + ex.Message);
                }
            }
            return texto;
        }

        public string obtenerEstadoDeUsuario(string nombre_Usuario)
        {
            string query = "exec obtenerEstadoDeUsuario @nombre_Usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        texto = reader.GetString(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al verificar el usuario en la base de datos " + ex.Message);
                }
            }
            return texto;
        }

        public int obtenerIDDeUsuario(string nombre_Usuario)
        {
            string query = "exec obtenerIDDeUsuario @nombre_Usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
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
                    MessageBox.Show("Error al verificar el usuario en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }


        public void RegistrarEntrada(int Id_Usuario, string seccion)
        {
            string query = "exec p_addIngresoUsuario @Id_Usuario,@FechaHoraAcceso,@SeccionEntrada";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                command.Parameters.AddWithValue("@FechaHoraAcceso", DateTime.Now);
                command.Parameters.AddWithValue("@SeccionEntrada", seccion);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al Guardar Registro en la bitocara" + error, "ERROR");
                }
            }
        }


    }
}