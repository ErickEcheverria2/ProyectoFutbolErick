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
    public partial class ReporteCanchas : Form
    {
        private string connectionString = ("Server=DESKTOP-U4PFR0A;Database=Proyecto_AdministracionTorneosFutbol;User Id=Rogelio;Password=12345;");

        public reporteCanchaDB buscarcontext = new reporteCanchaDB();
        reporteCanchaDB combo = new reporteCanchaDB();
        public ReporteCanchas()
        {
            InitializeComponent();
            combo.Buscar_cancha_combox(cbCancha);
            combo.Buscar_torneo_combox(cbTorneo);
            cbCancha.Visible = false;
            cbTorneo.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
        }
       
        private void ReporteCanchas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                string inicio = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
                            string fin = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
                            string query = "exec cancha_hora '" + inicio + "','" + fin + "'";
                            loadTableData(query);
               
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                  
                    string query = "exec cancha_nombre'" + Convert.ToString(cbCancha.SelectedItem)  + "'";
                    loadTableData(query);
                    cbCancha.Text = "Seleccione una opcion ";
                 
                }
                else
                {
                    if (comboBox1.SelectedIndex == 2)
                    {
                        string query = "exec cancha_Torneo'" + Convert.ToString(cbTorneo.SelectedItem) + "'";
                        loadTableData(query);
                       
                        cbTorneo.Text = "Seleccione una opcion ";
                       
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 3)
                        {
                            string inicio = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
                            string fin = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
                            string query = "exec cancha_nombre_fecha'" + Convert.ToString(cbCancha.SelectedItem) + "','" + inicio + "','" + fin + "'";
                            loadTableData(query);
                            cbCancha.Text = " Seleccione una opcion ";
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 4)
                            {
                                string inicio = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
                                string fin = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
                                string query = "exec cancha_Torneo_fecha'" + Convert.ToString(cbTorneo.SelectedItem) + "','" + inicio + "','" + fin + "'";
                                loadTableData(query);
                                
                                cbTorneo.Text ="Seleccione una opcion ";
                              
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 5)
                                {
                                    string inicio = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
                                    string fin = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
                                    string query = "exec cancha_completo '" + Convert.ToString(cbCancha.SelectedItem) + "','" + Convert.ToString(cbTorneo.SelectedItem) + "','" + inicio + "','" + fin + "'";
                                    loadTableData(query);
                                    cbCancha.Text = "Seleccione una Opcion ";
                                    cbTorneo.Text = "Seleccione una Opcion ";
                                }


                            }
                        }
                    }
                }
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
                    listCanchas.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label1.Visible =true;
                label2.Visible = true;
                button1.Visible = true;
                cbCancha.Visible = false;
                cbTorneo.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
               
            }
            else{
                if (comboBox1.SelectedIndex == 1)
                {
                    cbCancha.Visible = true;
                    label3.Visible = true;
                    button1.Visible = true;
                    cbTorneo.Visible = false;
                    label4.Visible = false;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                   
                }
                else
                {
                    if (comboBox1.SelectedIndex == 2)
                    {
                        cbTorneo.Visible = true;
                        label4.Visible = true;
                        button1.Visible = true;
                        cbCancha.Visible = false;
                        label3.Visible = false;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                       
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 3)
                        {
                            dateTimePicker1.Visible = true;
                            dateTimePicker2.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            button1.Visible = true;
                            cbCancha.Visible = true;
                            label3.Visible = true;
                            cbTorneo.Visible = false;
                            label4.Visible = false;
                           
                       
                        }
                        else{
                            if (comboBox1.SelectedIndex == 4)
                            {
                                dateTimePicker1.Visible = true;
                                dateTimePicker2.Visible = true;
                                label1.Visible = true;
                                label2.Visible = true;
                                cbTorneo.Visible = true;
                                label4.Visible = true;
                                button1.Visible = true;
                                cbCancha.Visible = false;
                                label3.Visible = false;
                               
                               
                            
                                
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 5)
                                {
                                    cbCancha.Visible = true;
                                    cbTorneo.Visible = true;
                                    label3.Visible = true;
                                    label4.Visible = true;
                                    dateTimePicker1.Visible = true;
                                    dateTimePicker2.Visible = true;
                                    label1.Visible = true;
                                    label2.Visible = true;
                                    button1.Visible = true;
                                }

                            }
                        
                        }
                    }
                }
             }
        }

        private void ReporteCanchas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }


}
