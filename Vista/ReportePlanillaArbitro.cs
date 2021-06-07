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
    public partial class ReportePlanillaArbitro : Form
    {
        private string connectionString = ("Server=DESKTOP-U4PFR0A;Database=Proyecto_AdministracionTorneosFutbol;User Id=Rogelio;Password=12345;");

        public ReportePlanillaArbitro()
        {
            InitializeComponent();
        }

        private void loadTableData(string query)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Adaptador para almacenar consulta

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    //Cargar tabla con la informacion de la consulta
                    sqll.Fill(data);
                    //Cargar datos en lista
                    listPlanillaArbitro.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string inicio = dtpInicio.Value.Year + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Day;
            string fin = dtpFinal.Value.Year + "-" + dtpFinal.Value.Month + "-" + dtpFinal.Value.Day;

            string query = $"EXEC SP_REPORTE_PLANILLA_ARBITROS '{inicio}', '{fin}'";
            loadTableData(query);
        }

        private void ReportePlanillaArbitro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }
}
