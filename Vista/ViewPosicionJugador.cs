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
    public partial class ViewPosicionJugador : Form
    {
        int idTorneo, idEquipo, edadMinima, edadMaxima;
        int opcion = 0;
        Posicion_JugadorDB posicion_JugadorDB= new Posicion_JugadorDB();

        public ViewPosicionJugador(int idTorneo, int idEquipo, int edadMinima, int edadMaxima)
        {
            InitializeComponent();

            this.idTorneo = idTorneo;
            this.idEquipo = idEquipo;
            this.edadMinima = edadMinima;
            this.edadMaxima = edadMaxima;

            cbxPosicion.Items.Add("Portero");
            cbxPosicion.Items.Add("Defensa");
            cbxPosicion.Items.Add("Centrocampista");
            cbxPosicion.Items.Add("Delantero");

            updateTable();
        }

        public void updateTable ()
        {
            listJugadores.DataSource = posicion_JugadorDB.getPosiciones(idTorneo, idEquipo);
            listJugadores.Columns[0].Visible = false;
            listJugadores.Columns[1].Visible = false;
            listJugadores.Columns[2].Visible = false;
            cbxJugador.Items.Clear();
            posicion_JugadorDB.optionsJugadores(cbxJugador, edadMinima, edadMaxima, idTorneo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaEquipo eq = new ListaEquipo(idTorneo, edadMinima, edadMaxima);
            eq.Show();

        }

        public long getIdentificacion()
        {
            try
            {
                return long.Parse(listJugadores.Rows[listJugadores.CurrentRow.Index].Cells[2].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Posicion_Jugador posicion_Jugador = posicion_JugadorDB.getPosicionById(getIdentificacion(), idTorneo, idEquipo);
            txtNumero.Text = posicion_Jugador.numeroCamisola.ToString();
            cbxJugador.Text = Convert.ToString(getIdentificacion());
            cbxPosicion.SelectedItem = posicion_Jugador.posicion;
            cbxJugador.Enabled = false;
            cbxPosicion.Enabled = false;
            opcion = 1;
        }

        private void ViewPosicionJugador_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Posicion_Jugador posicion_Jugador = new Posicion_Jugador();
            posicion_Jugador.identificacion = getIdentificacion();
            posicion_Jugador.id_equipo = idEquipo;
            posicion_Jugador.id_torneo = idTorneo;
            posicion_JugadorDB.deletePosicion(posicion_Jugador);
            updateTable();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int validar = 0;
            Posicion_Jugador posicion_Jugador = new Posicion_Jugador();


           if (cbxJugador.Text != string.Empty && cbxPosicion.SelectedIndex>=0 && txtNumero.Text!=string.Empty)
            {
                posicion_Jugador.id_torneo = idTorneo;
                posicion_Jugador.id_equipo = idEquipo;

                posicion_Jugador.posicion = cbxPosicion.Text;
                posicion_Jugador.numeroCamisola = Convert.ToInt32(txtNumero.Text);


                if (opcion == 0)
                {
                    List<Posicion_Jugador> pos = posicion_JugadorDB.getPosiciones(idTorneo, idEquipo);
                    foreach (Posicion_Jugador i in pos)
                    {
                        if (i.numeroCamisola == posicion_Jugador.numeroCamisola)
                        {
                            validar = 1;
                        }

                    }
                    if (validar == 0)
                    {
                        string jugador = Convert.ToString(cbxJugador.SelectedItem);
                        string[] jugadorArray = jugador.Split('|');
                        //Codigo del equipo almacenado en la posicion 0
                        long idJugador = Convert.ToInt64(jugadorArray[0]);
                        posicion_Jugador.identificacion = idJugador;
                        posicion_JugadorDB.addPosicion(posicion_Jugador);
                    }
                    else if (validar == 1)
                    {
                        MessageBox.Show("Camisola ya exstente");
                    }
                }
                else if (opcion == 1)
                {
                    List<Posicion_Jugador> pos = posicion_JugadorDB.getPosiciones(idTorneo, idEquipo);
                    foreach (Posicion_Jugador i in pos)
                    {
                        if (i.numeroCamisola == posicion_Jugador.numeroCamisola)
                        {
                            validar = 1;
                        }

                    }
                    if (validar == 0)
                    {
                        posicion_Jugador.identificacion = Convert.ToInt32(cbxJugador.Text);
                        posicion_JugadorDB.updatePosicion(posicion_Jugador);
                        opcion = 0;
                        cbxJugador.Enabled = true;
                        cbxPosicion.Enabled = true;
                }
                else if (validar == 1)
                {
                    MessageBox.Show("Camisola ya exstente");
                }
            }
            }
           else
            {
                MessageBox.Show("Todos los datos son necesarios");
            }
            limpiarControles();
            updateTable();
        }

        private void limpiarControles()
        {
            cbxJugador.Text = "";
            cbxJugador.SelectedIndex = -1;
            cbxPosicion.SelectedIndex = -1;
            txtNumero.Clear();
        }
    }
}
