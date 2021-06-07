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
    public partial class ServicioArbitraje : Form
    {
        public ServicioArbitrajeDB servicioDB = new ServicioArbitrajeDB();

        int Id_Alquiler;
        DateTime DiaAlquiler;
        TimeSpan HoraIncio;
        TimeSpan HoraFinal;

        public ServicioArbitraje(int Id_AlquilerP, DateTime DiaAlquilerP, TimeSpan HoraIncioP, TimeSpan HoraFinalP)
        {
            InitializeComponent();

            comboBox1.DataSource = servicioDB.CargarComboArbitros(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox1.DisplayMember = "NombreCompleto"; // Asignando el valor que se mostrara en el combobox
            comboBox1.ValueMember = "DPI"; // Valor que estara detras de Display

            Id_Alquiler = Id_AlquilerP;
            DiaAlquiler = DiaAlquilerP;
            HoraIncio = HoraIncioP;
            HoraFinal = HoraFinalP;

            listAlquileres.DataSource = servicioDB.GetArbitrosAlquiler(Id_AlquilerP);

        }

        private void ServicioArbitraje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal costoPorHoraArbitraje = servicioDB.obtenerPrecioPorHoraArbitraje();

            decimal totalDeHorasJugar = Convert.ToDecimal(HoraFinal.TotalHours - HoraIncio.TotalHours);

            totalDeHorasJugar = Decimal.Round(totalDeHorasJugar,2);


            decimal totalPagar = costoPorHoraArbitraje * totalDeHorasJugar;

            totalPagar = Decimal.Round(totalPagar,2);

            long cantidadPartidosJugar = servicioDB.obtenerCantidadPartidosJugarHoraFechaArbitro(Convert.ToInt64(comboBox1.SelectedValue), DiaAlquiler.Date, HoraIncio, HoraFinal);
            long cantidadPartidosJugarJornada = servicioDB.obtenerCantidadPartidosJugarHoraFechaJornadasArbitro(Convert.ToInt64(comboBox1.SelectedValue), DiaAlquiler.Date, HoraIncio, HoraFinal);

            if (cantidadPartidosJugar > 0 || cantidadPartidosJugarJornada > 0)
            {
                MessageBox.Show($"Arbitro NO Valido \nActualmente el arbitro se encuentra ocupado en el horario indicado\nCantidad de partidos Alquilados a arbitrar en la fecha indicada: {cantidadPartidosJugar}\nCantidad de partidos en Torneos a la fecha indicada: {cantidadPartidosJugarJornada}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (Convert.ToDecimal(textBox1.Text) == totalPagar)
                {
                    Modelo.ServicioArbitraje servicio = new Modelo.ServicioArbitraje();
                    servicio.Id_Alquiler = Id_Alquiler;
                    servicio.DPI_Arbitro = Convert.ToInt64(comboBox1.SelectedValue);
                    servicio.pagoArbitraje = Convert.ToDecimal(textBox1.Text);
                    servicio.DiaJuego = DiaAlquiler.Date;
                    servicio.HoraInicio = HoraIncio;
                    servicio.HoraFinal = HoraFinal;

                    servicioDB.AgregarArbitraje(servicio);

                    listAlquileres.DataSource = servicioDB.GetArbitrosAlquiler(Id_Alquiler);
                }
                else
                {
                    MessageBox.Show($"El monto de pago no corresponde a lo establecido\nHoras a De Arbitraje: {totalDeHorasJugar}\nCantidad a pagar por Hora: {costoPorHoraArbitraje}\nTotal a Pagar: {totalPagar}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private long buscar_DPIArbitro()
        {
            try
            {
                return long.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return 0;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo; //Mensaje de advetencia
            DialogResult dr = MessageBox.Show("¿Seguro desea eliminar la participación del Arbitro en el Alquiler? Esta opcion no se puede deshacer", "Advertencia", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                servicioDB.EliminarServicioArbitraje(Id_Alquiler,buscar_DPIArbitro());
            }

            listAlquileres.DataSource = servicioDB.GetArbitrosAlquiler(Id_Alquiler);
        }
    }
}
