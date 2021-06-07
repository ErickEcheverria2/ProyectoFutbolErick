using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
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
    public partial class Tarjetas : Form
    {
        private string connectionString = ("Server=LAPTOP-AA3NT37P;Database=Proyecto_AdministracionTorneosFutbol;User Id=Usuario1;Password=Usuario1;");

        public TorneoDB trconte = new TorneoDB();
        public TarjetaDB tarconte = new TarjetaDB();
        public Tarjetas()
        {
            InitializeComponent();
            listReportes.AllowUserToAddRows = false;
            listReportes.AllowDrop = false;
            listReportes.AllowUserToAddRows = false;
            listReportes.ReadOnly = true;
            listReportes.AllowUserToDeleteRows = false;
            listReportes.MultiSelect = false;
            List<Torneo> tr = trconte.GetTorneos();
            List<Tarjeta> tar = tarconte.ltr();
            foreach (var i in tr)
            {
                comboBox1.Items.Add(i.nombre); //llenar el combobox con los ombres de los torneos 
            }
            foreach (var i in tar)
            {
                comboBox2.Items.Add(i.Color_Tarjeta); //llenar el combobox con los ombres de los torneos 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            { //validando que se hayta seleccionado un torneo se muestran datos de no ser asi muestra el error 
                int? id = TRAERID();
                string color = comboBox2.SelectedItem.ToString();
                string query = "exec TarjetasporTorneo  "+ id + ",'" + color +"'";
                loadTableData(query);
            }
            else
            {
                MessageBox.Show("Seleccione un torneo y un color de tarjeta por favor  ");
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

                  

                    SqlDataAdapter sqll = new SqlDataAdapter(query,connection);
                    DataTable data = new DataTable();
                    
                    //Cargar tabla con la informacion de la consulta
                    sqll.Fill(data);
                    //Cargar datos en lista
                    listReportes.DataSource = data;
                    listReportes.Columns[1].HeaderText = comboBox2.SelectedItem.ToString();
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
                if (i.nombre == comboBox1.SelectedItem.ToString()) //traer el id del torneo seleccioando 
                {
                    return i.ID_Torneo;
                }

            }
            return 0;

        }
        private void Tarjetas_Load(object sender, EventArgs e)
        {

        }

        private void Tarjetas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }
}
