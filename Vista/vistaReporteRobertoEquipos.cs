using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class vistaReporteRobertoEquipos : Form
    {
        public string query = "select * from equipo";
        public vistaReporteRobertoEquipos()
        {
            InitializeComponent();
            GetEquipos(query);
        }

        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        private void GetEquipos(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter sql = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    sql.Fill(data);
                    Equiposlist.DataSource = data;
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudieron cargar los equipos");
                }

            }
        }

    }
}
