using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.BD
{
    public class arbitroDB
    {
        private string connectionstring = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");
        SqlConnection conexion;

        //verifcar conexion
        public void openConexion()
        {
            try
            {
                conexion = new SqlConnection(connectionstring);
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito");
            }
            catch
            {
                MessageBox.Show("NO SEA REALIZADO LA CONEXION");
            }
        }


        public List<Arbitro> manejoArbitros()
        {
            List<Arbitro> arbitros = new List<Arbitro>();
            string query = "exec getArbitros ";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Arbitro arbitroo = new Arbitro();
                        arbitroo.Dpi = reader.GetInt64(0);
                        arbitroo.Nombre = reader.GetString(1);
                        arbitroo.Apellidos = reader.GetString(2);
                        arbitroo.Direccion = reader.GetString(3);
                        arbitroo.Telefono = reader.GetString(4);
                        arbitroo.Nacionalidad = reader.GetString(5);
                        arbitroo.FechaNac = reader.GetDateTime(6);
                        arbitroo.Correo = reader.GetString(7);
                        arbitroo.Rol = reader.GetString(8);

                        arbitros.Add(arbitroo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
            return arbitros;
        }

        // metodo ingreso de arbitros
        public void Insertar_arbitro(Arbitro arbitro)
        {

            string query = "exec insertar_arbitros @DPI, @nombre,@apellido,@direccion,@telefono,@nacionalidad,@fechaNac,@correo,@rol ";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@DPI", arbitro.Dpi);
                sql.Parameters.AddWithValue("@nombre", arbitro.Nombre);
                sql.Parameters.AddWithValue("@apellido", arbitro.Apellidos);
                sql.Parameters.AddWithValue("@direccion", arbitro.Direccion);
                sql.Parameters.AddWithValue("@telefono", arbitro.Telefono);
                sql.Parameters.AddWithValue("@nacionalidad", arbitro.Nacionalidad);
                sql.Parameters.AddWithValue("@fechaNac", arbitro.FechaNac);
                sql.Parameters.AddWithValue("@correo", arbitro.Correo);
                sql.Parameters.AddWithValue("@rol", arbitro.Rol);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Arbitro ingresado " + " " + arbitro.Nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error la identificacion ya existe...  " + ex.Message);
                }

            }

        }
        //Buacar información
        public Arbitro buscar(long? id)
        {
            Arbitro arbitroo = new Arbitro();
            string query = "select*from ARBITRO where DPI=@id";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    arbitroo.Dpi = reader.GetInt64(0);
                    arbitroo.Nombre = reader.GetString(1);
                    arbitroo.Apellidos = reader.GetString(2);
                    arbitroo.Direccion = reader.GetString(3);
                    arbitroo.Telefono = reader.GetString(4);
                    arbitroo.Nacionalidad = reader.GetString(5);
                    arbitroo.FechaNac = reader.GetDateTime(6);
                    arbitroo.Correo = reader.GetString(7);
                    arbitroo.Rol = reader.GetString(8);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return arbitroo;
            }
        }


        public void actualizar_arbitro(long? DPI, string Nombre, string Apellidos, string Direccion,string telefono,string Nacionalidad,DateTime FechaNac,string Correo,string Rol)
        {
            

            string query = "exec actualizar_arbitros @DPI, @nombre,@apellido,@direccion,@telefono,@nacionalidad,@fechaNac,@correo,@rol";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
             

                command.Parameters.AddWithValue("@DPI", DPI);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellidos);
                command.Parameters.AddWithValue("@direccion", Direccion);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@nacionalidad", Nacionalidad);
                command.Parameters.AddWithValue("@fechaNac", FechaNac);
                command.Parameters.AddWithValue("@correo", Correo);
                command.Parameters.AddWithValue("@rol", Rol);

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


        public void eliminar_arbitro(long? id)
        {
            // delete from cliente where TIPO_PRODUCTO=@id
            string query = "exec eliminar_arbitro @id";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", id);
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
