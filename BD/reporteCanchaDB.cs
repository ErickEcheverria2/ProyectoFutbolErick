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
   public class reporteCanchaDB
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

       public void Buscar_cancha_combox(ComboBox cb)
        {
            string query = "exec getCancha";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();
                cb.Items.Insert(0, "Selecciona una opcion");
                cb.SelectedIndex = 0;


            }
        }


        public void Buscar_torneo_combox(ComboBox cb)
        {
            string query = "exec getToneo_reporte";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();
                cb.Items.Insert(0, "Selecciona una opcion");
                cb.SelectedIndex = 0;


            }
        }
    }
}
