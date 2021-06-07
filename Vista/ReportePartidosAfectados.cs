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
    public partial class ReportePartidosAfectados : Form
    {

        private string connectionString = ("Server=DESKTOP-IFKEU1D\\SQLEXPRESS  ;Database=Proyecto_AdministracionTorneosFutbol;User Id=sa;Password=albin123;");

        public ReportePartidosAfectados(string capacidad)
        {
            InitializeComponent();
            loadTableData(capacidad);
        }

        private void loadTableData(string capacidad)
        {
            string query = $"EXEC SP_VIEW_REPORTE_PARTIDOS_AFECTADOS {capacidad}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Adaptador para almacenar consulta
                    SqlDataAdapter sql = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    //Cargar tabla con la informacion de la consulta
                    sql.Fill(data);
                    //Cargar datos en lista
                    listPartidos.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        private void ReportePartidosAfectados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Canchas canchas = new Canchas();
            canchas.Show();
        }

        private void ReportePartidosAfectados_Load(object sender, EventArgs e)
        {

        }
    }
}
