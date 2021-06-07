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
    public partial class Consulta_DisponibilidadCancha : Form
    {
        public ConsultasDB consultasDB = new ConsultasDB();

        public Consulta_DisponibilidadCancha()
        {
            InitializeComponent();
            nombreCancha.DataSource = consultasDB.CargarComboCanchas(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            nombreCancha.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            nombreCancha.ValueMember = "NoCancha"; // Valor que estara detras de Display
        }

        private void buscar_Click(object sender, EventArgs e)
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
                listConsulta.DataSource = consultasDB.consultaDisponibilidadDeCancha(fechaInicio, fechaFinal,Convert.ToInt32(nombreCancha.SelectedValue));
            }
        }

        private void Consulta_DisponibilidadCancha_Load(object sender, EventArgs e)
        {

        }
    }
}
