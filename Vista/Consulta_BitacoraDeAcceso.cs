using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.Vista
{
    public partial class Consulta_BitacoraDeAcceso : Form
    {
        public ConsultasDB consultaDB = new ConsultasDB();

        public Consulta_BitacoraDeAcceso()
        {
            InitializeComponent();
            fecha_inicial.Visible = false;
            fecha_final.Visible = false;
            label3.Visible = false;
            label2.Visible = false;

            nombreUsuario.Visible = false;
            label6.Visible = false;
        }

        private void Consulta_BitacoraDeAcceso_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;

            if (rd.Checked)
            {
                //si el radio button esta seleccionado se muestran los textbox y labels correspondientes   
                fecha_inicial.Visible = true;
                fecha_final.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
            }
            else
            {
                //si no se ocultan 
                fecha_inicial.Visible = false;
                fecha_final.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;

            if (rd.Checked)
            {
                //si el radio button esta seleccionado se muestran los textbox y labels correspondientes   
                nombreUsuario.Visible = true;
                label6.Visible = true;

                nombreUsuario.DataSource = consultaDB.CargarComboUsuarios(); // Solicitando la informacion de la base de datos para cargarla en el combobox
                nombreUsuario.DisplayMember = "Nombre_Usuario"; // Asignando el valor que se mostrara en el combobox
                nombreUsuario.ValueMember = "Nombre_Usuario"; // Valor que estara detras de Display

            }
            else
            {
                //si no se ocultan 
                nombreUsuario.Visible = false;
                label6.Visible = false;
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)//Busqueda por Fecha
            {
                DateTime fechaInicio = fecha_inicial.Value;
                DateTime fechaFinal = fecha_final.Value;

                if (fechaFinal < fechaInicio && fechaFinal.Date != fechaInicio.Date)
                {
                    MessageBox.Show($"La Fecha Final de busqueda NO puede ser mayor a la Fecha Inicial\n" +
                        $"Intentelo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    listConsulta.DataSource = consultaDB.consulta_BitacoraDeAccesoFechas(fechaInicio, fechaFinal);
                }
            }
            else if (radioButton2.Checked == true)
            {
                listConsulta.DataSource = consultaDB.consulta_BitacoraDeAccesoNombreUsuario(Convert.ToString(nombreUsuario.SelectedValue)) ;
            }
        }
    }
}
