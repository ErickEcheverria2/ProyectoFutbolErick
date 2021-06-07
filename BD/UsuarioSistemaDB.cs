using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class UsuarioSistemaDB
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

        public List<UsuarioSistema> GetUsuarios()
        {
            List<UsuarioSistema> usuarios = new List<UsuarioSistema>();
            string query = "exec p_GetUsuariosDelSistema";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        UsuarioSistema usuario = new UsuarioSistema();
                        usuario.Id_Usuario = reader.GetInt32(0);
                        usuario.DPI_Usuario = reader.GetInt64(1);
                        usuario.Nombre_Usuario = reader.GetString(2);
                        usuario.Nombres = reader.GetString(3);
                        usuario.Apellidos = reader.GetString(4);
                        usuario.Telefono = reader.GetString(5);
                        usuario.Direccion = reader.GetString(6);
                        usuario.Correo = reader.GetString(7);
                        usuario.Puesto = reader.GetString(8);
                        usuario.Estado = reader.GetString(9);
                        usuario.Tipo = reader.GetString(10);
                        usuario.Contraseña = reader.GetString(11);

                        usuarios.Add(usuario);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return usuarios;
        }

        public void AgregarUsuario(UsuarioSistema usuario)
        {
            string query = "exec p_addUsuarioSistema @DPI_Usuario,@Nombre_Usuario,@Nombres,@Apellidos,@Telefono,@Direccion,@Correo,@Puesto,@estado,@Tipo,@Contrasena";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@DPI_Usuario", usuario.DPI_Usuario);
                command.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombre_Usuario);
                command.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                command.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@Correo", usuario.Correo);
                command.Parameters.AddWithValue("@Puesto", usuario.Puesto);
                command.Parameters.AddWithValue("@estado", usuario.Estado);
                command.Parameters.AddWithValue("@Tipo", usuario.Tipo);
                command.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Usuario Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al Guardar Usuario" + error.Message, "ERROR");
                }
            }
        }

        int cantidad;

        public int p_BuscarUsuariosMismoCorreo(string Correo)
        {
            string query = "exec p_BuscarUsuariosMismoCorreo @Correo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Correo", Correo);
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
                    MessageBox.Show("Error al obtener los partido a jugar en la cancha en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int p_BuscarUsuariosMismoDPI(long DPI)
        {
            string query = "exec p_BuscarUsuariosMismoDPI @DPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
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
                    MessageBox.Show("Error al obtener los DPI de los Usuarios en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int p_BuscarUsuariosMismoNombreUsuario(string NombreUsuario)
        {
            string query = "exec p_BuscarUsuariosMismoNombreUsuario @NombreUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
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
                    MessageBox.Show("Error al obtener los Nombres de Usuario de los Usuarios en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public UsuarioSistema buscarUsuario(int Id_Usuario)
        {
            UsuarioSistema usuario = new UsuarioSistema();
            string query = "select*from UsuarioSistema where Id_Usuario=@Id_Usuario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    usuario.Id_Usuario = reader.GetInt32(0);
                    usuario.DPI_Usuario = reader.GetInt64(1);
                    usuario.Nombre_Usuario = reader.GetString(2);
                    usuario.Nombres = reader.GetString(3);
                    usuario.Apellidos = reader.GetString(4);
                    usuario.Telefono = reader.GetString(5);
                    usuario.Direccion = reader.GetString(6);
                    usuario.Correo = reader.GetString(7);
                    usuario.Puesto = reader.GetString(8);
                    usuario.Estado = reader.GetString(9);
                    usuario.Tipo = reader.GetString(10);
                    usuario.Contraseña = reader.GetString(11);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return usuario;
            }
        }

        public void actualizarUsuario(UsuarioSistema usuario)
        {
            string query = "UPDATE UsuarioSistema SET DPI_Usuario = @DPI_Usuario, " +
                "Nombre_Usuario = @Nombre_Usuario, Nombres=@Nombres, " +
                "Apellidos=@Apellidos, Telefono=@Telefono, " +
                "Direccion=@Direccion, Correo=@Correo, Puesto=@Puesto, " +
                "estado=@estado,Tipo=@Tipo, Contrasena=@Contrasena    WHERE Id_Usuario = @Id_Usuario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);
                command.Parameters.AddWithValue("@DPI_Usuario", usuario.DPI_Usuario);
                command.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombre_Usuario);
                command.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                command.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@Correo", usuario.Correo);
                command.Parameters.AddWithValue("@Puesto", usuario.Puesto);
                command.Parameters.AddWithValue("@estado", usuario.Estado);
                command.Parameters.AddWithValue("@Tipo", usuario.Tipo);
                command.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
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

        public int p_BuscarUsuariosMismoCorreoExceptoElMismo(string Correo, int Id)
        {
            string query = "exec p_BuscarUsuariosMismoCorreoExceptoElMismo @Correo, @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Correo", Correo);
                sql.Parameters.AddWithValue("@Id", Id);
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
                    MessageBox.Show("Error al obtener los partido a jugar en la cancha en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int p_BuscarUsuariosMismoDPIExceptoElMismo(long DPI, int Id)
        {
            string query = "exec p_BuscarUsuariosMismoDPIExceptoElMismo @DPI, @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
                sql.Parameters.AddWithValue("@Id", Id);
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
                    MessageBox.Show("Error al obtener los DPI de los Usuarios en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int p_BuscarUsuariosMismoNombreUsuarioExceptoElMismo(string NombreUsuario, int Id)
        {
            string query = "exec p_BuscarUsuariosMismoNombreUsuarioExceptoElMismo @NombreUsuario, @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                sql.Parameters.AddWithValue("@Id", Id);
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
                    MessageBox.Show("Error al obtener los Nombres de Usuario de los Usuarios en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }


    }
}


