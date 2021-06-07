using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
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
    public partial class ViewPagoAmonestacion : Form
    {
        PagoAmonestacionDB pagoAmonestacionDB = new PagoAmonestacionDB();
        int idPartido; int DPI;
        string colorTarjeta, tiempo;
        Boolean pagado;

        public ViewPagoAmonestacion()
        {
            InitializeComponent();
            btnAgregar.Enabled = false;
            cbTarjetaPagada.Enabled = false;
            updateTable();
        }

        public void updateTable()
        {
            listTarjetas.DataSource = pagoAmonestacionDB.getAmonestaciones();
        }

        public int getPartido()
        {
            try
            {
                return Convert.ToInt32(listTarjetas.Rows[listTarjetas.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public int getDPI()
        {
            try
            {
                return Convert.ToInt32(listTarjetas.Rows[listTarjetas.CurrentRow.Index].Cells[1].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public string getTarjeta()
        {
            try
            {
                return listTarjetas.Rows[listTarjetas.CurrentRow.Index].Cells[2].Value.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            cbTarjetaPagada.Enabled = true;
            this.idPartido = getPartido();
            this.DPI = getDPI();
            this.colorTarjeta = getTarjeta();
            ControlAmonestacion controlAmonestacion = pagoAmonestacionDB.getAmonestacionById(idPartido, DPI, colorTarjeta);
            this.tiempo = controlAmonestacion.Tiempo;
            this.pagado = controlAmonestacion.Pagado;
            listTarjetas.Enabled = false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ControlAmonestacion controlAmonestacion = new ControlAmonestacion();
            controlAmonestacion.Id_Juego = idPartido;
            controlAmonestacion.Id_Jugador = DPI;
            controlAmonestacion.Tiempo = tiempo;
            controlAmonestacion.Color_Tarjeta = colorTarjeta;
            controlAmonestacion.Pagado = cbTarjetaPagada.Checked;
            pagoAmonestacionDB.updateControlAmonestacion(controlAmonestacion);
            btnAgregar.Enabled = false;
            cbTarjetaPagada.Enabled = false;
            cbTarjetaPagada.Checked = false;
            updateTable();
            listTarjetas.Enabled = true;
        }

        private void ViewPagoAmonestacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
