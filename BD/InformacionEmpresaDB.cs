using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
    public class InformacionEmpresaDB
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
        public InformacionEmpresa buscarInformacion(int Id_Informacion)
        {
            InformacionEmpresa empresa = new InformacionEmpresa();
            string query = "select*from InformacionEmpresa where Id_InformacionEmpresa=@Id_Informacion";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_Informacion", Id_Informacion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    empresa.Nombre = reader.GetString(1);
                    empresa.Direccion = reader.GetString(2);
                    empresa.Telefono = reader.GetString(3);
                    empresa.CostoDeArbitraje = reader.GetDecimal(4);
                    empresa.HoraEntradaLunes = reader.GetTimeSpan(5);
                    empresa.HoraSalidaLunes = reader.GetTimeSpan(6);
                    empresa.HoraEntradaMartes = reader.GetTimeSpan(7);
                    empresa.HoraSalidaMartes = reader.GetTimeSpan(8);
                    empresa.HoraEntradaMiercoles = reader.GetTimeSpan(9);
                    empresa.HoraSalidaMiercoles = reader.GetTimeSpan(10);
                    empresa.HoraEntradaJueves = reader.GetTimeSpan(11);
                    empresa.HoraSalidaJueves = reader.GetTimeSpan(12);
                    empresa.HoraEntradaViernes = reader.GetTimeSpan(13);
                    empresa.HoraSalidaViernes = reader.GetTimeSpan(14);
                    empresa.HoraEntradaSabado = reader.GetTimeSpan(15);
                    empresa.HoraSalidaSabado = reader.GetTimeSpan(16);
                    empresa.HoraEntradaDomingo = reader.GetTimeSpan(17);
                    empresa.HoraSalidaDomingo = reader.GetTimeSpan(18);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return empresa;
            }
        }

        public void actualizar_Informacion(InformacionEmpresa informacion)
        {
            string query = "UPDATE InformacionEmpresa SET Nombre = @Nombre, Direccion = @Direccion, Telefono=@Telefono, CostoArbitraje=@CostoArbitraje, " +
                "HorarioEntradaLunes=@HorarioEntradaLunes, HorarioSalidaLunes=@HorarioSalidaLunes, " +
                "HorarioEntradaMartes=@HorarioEntradaMartes, HorarioSalidaMartes=@HorarioSalidaMartes, " +
                "HorarioEntradaMiercoles=@HorarioEntradaMiercoles,HorarioSalidaMiercoles=@HorarioSalidaMiercoles, " +
                "HorarioEntradaJueves=@HorarioEntradaJueves, HorarioSalidaJueves=@HorarioSalidaJueves, " +
                "HorarioEntradaViernes=@HorarioEntradaViernes, HorarioSalidaViernes=@HorarioSalidaViernes, " +
                "HorarioEntradaSabado=@HorarioEntradaSabado, HorarioSalidaSabado=@HorarioSalidaSabado, " +
                 "HorarioEntradaDomingo=@HorarioEntradaDomingo, HorarioSalidaDomingo=@HorarioSalidaDomingo " +
                " WHERE Id_InformacionEmpresa = 1";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Nombre", informacion.Nombre);
                command.Parameters.AddWithValue("@Direccion", informacion.Direccion);
                command.Parameters.AddWithValue("@Telefono", informacion.Telefono);
                command.Parameters.AddWithValue("@CostoArbitraje", informacion.CostoDeArbitraje);
                command.Parameters.AddWithValue("@HorarioEntradaLunes", informacion.HoraEntradaLunes);
                command.Parameters.AddWithValue("@HorarioSalidaLunes", informacion.HoraSalidaLunes);
                command.Parameters.AddWithValue("@HorarioEntradaMartes", informacion.HoraEntradaMartes);
                command.Parameters.AddWithValue("@HorarioSalidaMartes", informacion.HoraSalidaMartes);
                command.Parameters.AddWithValue("@HorarioEntradaMiercoles", informacion.HoraEntradaMiercoles);
                command.Parameters.AddWithValue("@HorarioSalidaMiercoles", informacion.HoraSalidaMiercoles);
                command.Parameters.AddWithValue("@HorarioEntradaJueves", informacion.HoraEntradaJueves);
                command.Parameters.AddWithValue("@HorarioSalidaJueves", informacion.HoraSalidaJueves);
                command.Parameters.AddWithValue("@HorarioEntradaViernes", informacion.HoraEntradaViernes);
                command.Parameters.AddWithValue("@HorarioSalidaViernes", informacion.HoraSalidaViernes);
                command.Parameters.AddWithValue("@HorarioEntradaSabado", informacion.HoraEntradaSabado);
                command.Parameters.AddWithValue("@HorarioSalidaSabado", informacion.HoraSalidaSabado);
                command.Parameters.AddWithValue("@HorarioEntradaDomingo", informacion.HoraEntradaDomingo);
                command.Parameters.AddWithValue("@HorarioSalidaDomingo", informacion.HoraSalidaDomingo);
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





    }
}
