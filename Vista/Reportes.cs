using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            this.Hide();
            tablapos ts = new tablapos();
            ts.Show();
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarjetas tt = new Tarjetas();
            tt.Show();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteCanchas reporteCanchas = new ReporteCanchas();
            reporteCanchas.Show();
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportePlanillaArbitro reportePlanillaArbitro = new ReportePlanillaArbitro();
            reportePlanillaArbitro.Show();
        }

        private void Reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteEstadisticasEquipo reporteEstadisticasEquipo = new ReporteEstadisticasEquipo();
            reporteEstadisticasEquipo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta_IngresoDeAlquilerCancha consulta = new Consulta_IngresoDeAlquilerCancha();
            consulta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta_IngresoServicioDeArbitraje consulta = new Consulta_IngresoServicioDeArbitraje();
            consulta.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Consulta_BitacoraDeAcceso consulta = new Consulta_BitacoraDeAcceso();
            consulta.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consulta_DisponibilidadCancha consulta = new Consulta_DisponibilidadCancha();
            consulta.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListadiArbitros consulta = new ListadiArbitros();
            consulta.ShowDialog();
        }
    }
}
