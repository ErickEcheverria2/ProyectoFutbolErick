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
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.Vista
{
    public partial class ReporteEstadisticasEquipo : Form
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public TorneoDB trconte = new TorneoDB();
        public TarjetaDB tarconte = new TarjetaDB();
          Equipo_TorneoDB equipo = new Equipo_TorneoDB();
        public ReporteEstadisticasEquipo()
        {
            InitializeComponent();
            listUtilidades.AllowUserToAddRows = false;
            listUtilidades.AllowDrop = false;
            listUtilidades.AllowUserToAddRows = false;
            listUtilidades.ReadOnly = true;
            listUtilidades.AllowUserToDeleteRows = false;
            listUtilidades.MultiSelect = false;
            List<Torneo> tr = trconte.GetTorneos();
          
            foreach (var i in tr)
            {
                cbxTorneo.Items.Add(i.nombre); //llenar el combobox con los ombres de los torneos 
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbxBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxEquipo.SelectedIndex <0 && cbxTorneo.SelectedIndex<0)

            {
                MessageBox.Show("Seleccione una opcion para poder realizar la busqueda");
            }else if(cbxEquipo.SelectedIndex>=0 && cbxTorneo.SelectedIndex>=0)
            {
                int x = TRAERID();
                
                string query= "exec estadisticasportorneoyqueipo "+ x + ",'"+ cbxEquipo.SelectedItem.ToString()+ "'";
                loadTableData(query);


            } else if (cbxEquipo.SelectedIndex >= 0)
            {
                string query = "exec estadisticaporquipo  " + cbxEquipo.SelectedItem.ToString();
                loadTableData(query);

            }
            else if     (cbxTorneo.SelectedIndex >= 0)
            {
                int x = TRAERID();
                string query = "exec estadisticasportorneo " + x;
                loadTableData(query);
            }
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
                    listUtilidades.DataSource = data;
                     
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        public int TRAERID()
        {
            List<Torneo> tr = trconte.GetTorneos();
            foreach (var i in tr)
            {
                if (i.nombre == cbxTorneo.SelectedItem.ToString()) //traer el id del torneo seleccioando 
                {
                    return i.ID_Torneo;
                }

            }
            return 0;

        }

        private void cbxEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
             

            if (cbxTorneo.SelectedIndex >= 0)
            {
                cbxEquipo.Items.Clear();
                cbxEquipo.Enabled = true;
                int x = TRAERID();
                List<Equipo_Torneo> tar = equipo.Gettorneoequipo(x);
                foreach (var i in tar)
                {
                    cbxEquipo.Items.Add(i.Equipo); //llenar el combobox con los ombres de los torneos 
                }
            }
        }

        private void ReporteEstadisticasEquipo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }
}
