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
    public partial class Consulta_IngresoDeAlquilerCancha : Form
    {
        public ConsultasDB consultaDB = new ConsultasDB();


        public Consulta_IngresoDeAlquilerCancha()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = fecha_inicial.Value;
            DateTime fechaFinal = fecha_final.Value;

            if(fechaFinal < fechaInicio && fechaFinal.Date != fechaInicio.Date)
            {
                MessageBox.Show($"La Fecha Final de busqueda NO puede ser mayor a la Fecha Inicial\n" +
                    $"Intentelo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                listConsulta.DataSource = consultaDB.consulta_montoGeneradoXCanchasDiaxDia(fechaInicio, fechaFinal);
            }
        }
    }
}
