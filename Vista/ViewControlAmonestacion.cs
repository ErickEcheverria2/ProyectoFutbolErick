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
    public partial class ViewControlAmonestacion : Form
    {
        int idPartido, minutos, idTorneo;
        int opcion = 0;
        ControlAmonestacionDB controlAmonestacionDB = new ControlAmonestacionDB();
        jugadorBD jugacon = new jugadorBD();
        partidosDB prrcontext = new partidosDB();
        Posicion_JugadorDB jcontext = new Posicion_JugadorDB();



        public ViewControlAmonestacion(int minutos, int idPartido, int idTorneo)
        {
            InitializeComponent();
            this.idPartido = idPartido;
            this.minutos = minutos;
            this.idTorneo = idTorneo;

            controlAmonestacionDB.optionsTarjetas(cbxTarjeta);
            for (int i = 1; i <= minutos; i++)
            {
                cbxTiempo.Items.Add(i);
            }
            cbxEquipo.Items.Add("Local");
            cbxEquipo.Items.Add("Visita");

            updateTable();
        }

        
        public void updateTable()
        {
            listTarjetas.DataSource = controlAmonestacionDB.getAmonestaciones(idPartido);
            listTarjetas.Columns[0].Visible = false;
            listTarjetas.Columns[1].Visible = false;
          
        }


        public int getDPI()
        {
            try
            {
                return int.Parse(listTarjetas.Rows[listTarjetas.CurrentRow.Index].Cells[1].Value.ToString());
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
                return "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ControlAmonestacion controlAmonestacion = new ControlAmonestacion();
            
            string jugador = Convert.ToString(cbxJugador.SelectedItem);
            string[] jugadorArray = jugador.Split('|');
            //Codigo del jugador almacenado en la posicion 0
            int idJugador = Convert.ToInt32(jugadorArray[0]);
            controlAmonestacion.Id_Juego = idPartido;
            controlAmonestacion.Id_Jugador = idJugador;
            controlAmonestacion.Color_Tarjeta = Convert.ToString(cbxTarjeta.SelectedItem);
            controlAmonestacion.Tiempo = Convert.ToString(cbxTiempo.SelectedItem);

            if (opcion == 0)
            {
                controlAmonestacionDB.addControlAmonestacion(controlAmonestacion);
            } 
            else if(opcion == 1)
            {
                controlAmonestacionDB.updateControlAmonestacion(controlAmonestacion);
                btnAgregar.Text = "Agregar";
                opcion = 0;
            }
            
            updateTable();
            limpiarControles();
        }

        private void listTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxJugador.Items.Clear();
            List<Posicion_Jugador> jlocla = jcontext.getPosiciones(prrcontext.Jornadas(idPartido).id_torneo, prrcontext.Jornadas(idPartido).id_Equipo_local); //jugadores locales
            List<Posicion_Jugador> jvis = jcontext.getPosiciones(prrcontext.Jornadas(idPartido).id_torneo, prrcontext.Jornadas(idPartido).id_Equipo_visita); //jugadores locales

            if (cbxEquipo.SelectedIndex == 0)
            {
                foreach (Posicion_Jugador p1 in jlocla)
                {
                    cbxJugador.Items.Add(p1.identificacion + "| " + jugacon.jugadorid(p1.identificacion).nombres + " " + jugacon.jugadorid(p1.identificacion).apellidos);
                }
            }
            else if (cbxEquipo.SelectedIndex == 1)
            {
                foreach (Posicion_Jugador p2 in jvis)
                {
                    cbxJugador.Items.Add(p2.identificacion + "| " + jugacon.jugadorid(p2.identificacion).nombres + " " + jugacon.jugadorid(p2.identificacion).apellidos);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnAgregar.Text = "Guardar Cambio";
            opcion = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ControlAmonestacion controlAmonestacion = new ControlAmonestacion();
            controlAmonestacion.Id_Jugador = getDPI();
            controlAmonestacion.Id_Juego = idPartido;
            controlAmonestacion.Color_Tarjeta = getTarjeta();
            controlAmonestacionDB.deleteAmonestacion(controlAmonestacion);
            updateTable();
        }

        private void ViewControlAmonestacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Partidos partidos = new Partidos(idTorneo);
            partidos.Show();
        }

        public void limpiarControles()
        {
            cbxJugador.SelectedIndex = -1;
            cbxTarjeta.SelectedIndex = -1;
            cbxTiempo.SelectedIndex = -1;
            cbxEquipo.SelectedIndex = -1;
        }

    }
}
