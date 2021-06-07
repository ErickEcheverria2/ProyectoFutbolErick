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
    public partial class Partidos : Form
    {
        public int? id;
        public int idl, idv;

        public partidosDB prrContext = new partidosDB();
        public TorneoDB trcontext = new TorneoDB();
        public partidos partidosSel = new partidos();
        public PunteoDB pbcontext = new PunteoDB();
        public Puntos pts = new Puntos();
        GolesDB gconte = new GolesDB();
        public Partidos(int? idtorneo)
        {

            id = idtorneo;
            InitializeComponent();
            Gettp();
            listjornadas.AllowUserToAddRows = false;
            listjornadas.AllowDrop = false;
            listjornadas.AllowUserToAddRows = false;
            listjornadas.ReadOnly = true;
            listjornadas.AllowUserToDeleteRows = false;
            listjornadas.MultiSelect = false;
            prrContext.getCanchas(comboBox1);

            textBox1.Text =trcontext.Gettorneo(id).nombre;

        }

        private int? GetId() //obtenemos el id de cada fila
        {
            try
            {
                return int.Parse(
                    listjornadas.Rows[listjornadas.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }
        public void Gettp()
        {
            listjornadas.DataSource = prrContext.listadoJornadas(id); //llenamos la lista con los elementos en la base
          listjornadas.Columns[0].Visible = false;
            listjornadas.Columns[3].Visible = false;
            listjornadas.Columns[2].Visible = false;
            listjornadas.Columns[1].Visible = false;
            int x = listjornadas.Rows.Count;// contamos lass lineas de datos 

            if (x == 0) //
            {
                MessageBox.Show("Conexion exitosa , pero la tabla buscada no tiene datos");

            }
            else
            {

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int ganador = ganador = trcontext.Gettorneo(id).puntos_partido_ganado;
            int perdedor = trcontext.Gettorneo(id).puntos_partido_perdido;
            int empate = trcontext.Gettorneo(id).puntos_partido_empatado;
            int? ids = GetId();
            if (prrContext.Jornadas(ids).jugado == false)
            {
                string cancha = Convert.ToString(comboBox1.SelectedItem);
                string[] arrayCancha = cancha.Split('|');
                int idCancha = Convert.ToInt32(arrayCancha[0]);

                ControlCancha controlCancha = new ControlCancha();
                controlCancha.id_juego = Convert.ToInt32(GetId());
                controlCancha.noCancha = idCancha;
                prrContext.addControlCancha(controlCancha);
            }
            prrContext.dtl(Convert.ToInt32(ids));
            
            if (prrContext.Jornadas(ids).marcador_local == local.Value && visita.Value == prrContext.Jornadas(ids).marcador_visita
)
            {
                prrContext.updjornada(ids, fecha.Value, horainicio.Value, horafin.Value, Convert.ToInt32(local.Value), Convert.ToInt32(visita.Value)); //actualizamos jornadas

            }
            else
            {
                
                prrContext.updjornada(ids, fecha.Value, horainicio.Value, horafin.Value, Convert.ToInt32(local.Value), Convert.ToInt32(visita.Value)); //actualizamos jornadas
                prrContext.dtlg(ids);
            }

            Gettp();

            pts.id_juego = Convert.ToInt32(ids);
            pts.id_equipo_local = idl;
            pts.id_equipo_visita = idv;
            pts.marcador_local = Convert.ToInt32(local.Value);
            pts.marcador_visita = Convert.ToInt32(visita.Value);
            if (Convert.ToInt32(local.Value) > Convert.ToInt32(visita.Value))
            {

                pts.punteo_equipo_local = ganador;
                pts.punteo_equipo_visita = perdedor;


            }
            else if ((Convert.ToInt32(local.Value) < Convert.ToInt32(visita.Value)))
            {
                pts.punteo_equipo_local = perdedor;
                pts.punteo_equipo_visita = ganador;

            }
            else if ((Convert.ToInt32(local.Value) == Convert.ToInt32(visita.Value)))
            {
                pts.punteo_equipo_local = empate;
                pts.punteo_equipo_visita = empate;
            }

            int punteoExiste = pbcontext.verificarSiPunteoExiste(idl,idv);

            if(punteoExiste == 0)
            {
                pbcontext.addpunteo(pts);
                button1.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listjornadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Partidos_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           

            fecha.Value = Convert.ToDateTime(fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year + " 23:59:59");
            

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void accionespopartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? ids = GetId();
            int goles = prrContext.Jornadas(ids).marcador_local + prrContext.Jornadas(ids).marcador_visita;
            if (prrContext.Jornadas(ids).jugado == false)
            {
                MessageBox.Show("El partido no se ha jugado , solo se pueden registrar eventos de partisdos ya jugados ");
            }
            else
            {
               

                TimeSpan tiempo = horafin.Value.TimeOfDay - horainicio.Value.TimeOfDay;
                double minutos = tiempo.TotalMinutes;

                switch ( accionespopartido.SelectedIndex)
                {
                    case 0:
                         
                            this.Hide();
                            controlgoles ctrg = new controlgoles(Convert.ToInt32(minutos), Convert.ToInt32(ids));
                            ctrg.Show();
                         
                         
                        break;
                    case 1:
                        this.Hide();
                        ViewControlAmonestacion viewControlAmonestacion = new ViewControlAmonestacion(Convert.ToInt32(minutos), Convert.ToInt32(ids), Convert.ToInt32(id));
                        viewControlAmonestacion.Show();
                        
                        break;
                    case 2:
                        this.Hide();
                        ViewCambio vrc = new ViewCambio(Convert.ToInt32(minutos), Convert.ToInt32(ids), Convert.ToInt32(id));
                        vrc.Show();
                        break;

                    case 3:
                        this.Hide();
                        VistaControlArbitro vistaControlArbitro = new VistaControlArbitro(Convert.ToInt32(ids), Convert.ToInt32(id));
                        vistaControlArbitro.Show();
                        break;

                    default: break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            int? ids = GetId();
            if (prrContext.Jornadas(ids).jugado == true)
            {
 
                MessageBox.Show("El Partido ya se ha registrado antes desea continuar , si modifica el marcador el registro de goles sera eliminado para que ingrese nuevo marcador ");
                comboBox1.Enabled = false;
            }
            button1.Enabled = true;
            fecha.Value = prrContext.Jornadas(ids).fecha;

            local.Value = prrContext.Jornadas(ids).marcador_local;

            visita.Value = prrContext.Jornadas(ids).marcador_visita;
            idl = prrContext.Jornadas(ids).id_Equipo_local;
            idv = prrContext.Jornadas(ids).id_Equipo_visita;

        }
    }
}
