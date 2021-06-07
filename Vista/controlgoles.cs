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
    
    public partial class controlgoles : Form
       
    {

        public int time, ids;
        GolesDB gconte = new GolesDB();
        public partidosDB prrcontext = new partidosDB();
          Posicion_JugadorDB jcontext = new Posicion_JugadorDB();
        EquipoDB qcontext = new EquipoDB();
        jugadorBD jugacon = new jugadorBD();
        int conteolocal = 0;
        int conteovisita=0;
         


        public controlgoles(int tiempo , int id)
        {
            ids = id;
            InitializeComponent();
            listagoles.AllowUserToAddRows = false;
            listagoles.AllowDrop = false;
            listagoles.AllowUserToAddRows = false;
            listagoles.ReadOnly = true;
            listagoles.AllowUserToDeleteRows = false;
            listagoles.MultiSelect = false;
           
           groupBox2.Text= qcontext.getEquipoById(prrcontext.Jornadas(id).id_Equipo_local).nombre; // asignamos el nombre de los equipos a los textos 
          groupBox3.Text=  qcontext.getEquipoById(prrcontext.Jornadas(id).id_Equipo_visita).nombre;
            Gettp();

            for (int i =1; i<=tiempo; i++) // agregamos los minutos  a los combo de tiempo 
            {
                tiempoV.Items.Add(i);
                tlocal.Items.Add(i);
            }

            ;
          List<Posicion_Jugador> jlocla = jcontext.getPosiciones(prrcontext.Jornadas(id).id_torneo, prrcontext.Jornadas(id).id_Equipo_local); //jugadores locales
            List<Posicion_Jugador> jvis = jcontext.getPosiciones(prrcontext.Jornadas(id).id_torneo, prrcontext.Jornadas(id).id_Equipo_visita); //jugadores locales

            foreach(Posicion_Jugador p1 in jlocla ) // agregamos tanto jugadores locales como visitantes 
            {
                jlocal.Items.Add(p1.identificacion+"|"+jugacon.jugadorid(p1.identificacion).nombres +" "+jugacon.jugadorid(p1.identificacion).apellidos);
            }

            foreach (Posicion_Jugador p2 in jvis)
            {
                jvisita.Items.Add(p2.identificacion + "|" + jugacon.jugadorid(p2.identificacion).nombres + " "  + jugacon.jugadorid(p2.identificacion).apellidos);
            }
        }
        private int? GetId() //obtenemos el id de cada fila
        {
            try
            {
                return int.Parse(
                    listagoles.Rows[listagoles.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }
        public void Gettp()
        {
            listagoles.DataSource = gconte.getgoles(ids); //llenamos la lista con los elementos en la base
            listagoles.Columns[0].Visible = false;  //ocultamos las columnas que no queremos mostrar 
            listagoles.Columns[1].Visible = false;
            int goles = prrcontext.Jornadas(ids).marcador_visita + prrcontext.Jornadas(ids).marcador_local;
            if (goles==listagoles.Rows.Count)
            {
                groupBox3.Enabled = false;
                jvisita.Enabled = false;
                tiempoV.Enabled = false;
                TipoV.Enabled = false;
                button2.Enabled = false;
                groupBox2.Enabled = false;
                jlocal.Enabled = false;
                tlocal.Enabled = false;
                TipoL.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
            }


            int x = listagoles.Rows.Count;// contamos lass lineas de datos 

            if (x == 0) //
            {
                MessageBox.Show("Conexion exitosa , pero la tabla buscada no tiene datos"); 

            }
            else
            {

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void controlgoles_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            int local = prrcontext.Jornadas(ids).marcador_local;
        
           



            if (tlocal.SelectedIndex < 0 && jlocal.SelectedIndex < 0 && TipoL.SelectedIndex < 0) //guardar los datos de los goleadores
                {
                    MessageBox.Show("Un CAmpo no ha sido seleccionado, ingrese todos los datos pra continuar");
                }
                else
                {
                    goles gg = new goles();
                    string[] name = jlocal.SelectedItem.ToString().Split('|'); 
                    gg.Identifiacion = Convert.ToInt32(name[0]);
                    gg.id_juego = ids;
                    gg.tiempo = Convert.ToInt32(tlocal.SelectedItem);
                    gg.tipo = TipoL.SelectedItem.ToString();
                    gconte.add(gg);
                    conteolocal = conteolocal + 1;
                }
            if (conteolocal == local)
            {
                groupBox2.Enabled = false;
                jlocal.Enabled = false;
                tlocal.Enabled = false;
                TipoL.Enabled = false;
                button1.Enabled = false;
            }

            if (groupBox3.Enabled == false && groupBox2.Enabled == false)
            {
                button3.Enabled = true;
            }
            Gettp();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                if (tiempoV.SelectedIndex < 0 && jvisita.SelectedIndex < 0 && TipoV.SelectedIndex < 0)
                {
                    MessageBox.Show("Un Campo no ha sido seleccionado, ingrese todos los datos pra continuar");
                }
                else
                {
                    goles gg = new goles(); //guardar los datos de los goleadores 
                    string[] name = jvisita.SelectedItem.ToString().Split('|');
                    gg.Identifiacion = Convert.ToInt32(name[0]);
                    gg.id_juego = ids;
                    gg.tiempo = Convert.ToInt32(tiempoV.SelectedItem);
                    gg.tipo = TipoV.SelectedItem.ToString();
                    gconte.add(gg);
                    conteovisita = conteovisita + 1;
                }
            if (conteovisita == prrcontext.Jornadas(ids).marcador_visita)
            {
                groupBox3.Enabled = false;
                jvisita.Enabled = false;
                tiempoV.Enabled = false;
                TipoV.Enabled = false;
                button2.Enabled = false;
            }
            

            if (groupBox3.Enabled == false && groupBox2.Enabled == false)
            {
                button3.Enabled = true;
            }
            Gettp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Partidos pr = new Partidos(prrcontext.Jornadas(ids).id_torneo); // regresamos  la vista de partidos 
            pr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //bloqueamos todo de nuevo 
            groupBox3.Enabled = false;
            jvisita.Enabled = false;
            tiempoV.Enabled = false;
            TipoV.Enabled = false;
            button2.Enabled = false;
            groupBox2.Enabled = false;
            jlocal.Enabled = false;
            tlocal.Enabled = false;
            TipoL.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;


            int local = 0;
            int visita = 0;
            int golid = Convert.ToInt32(GetId());
            goles gg = gconte.getgol(golid);
            foreach (var i in jlocal.Items)
            {
                string[] name = i.ToString().Split('|');

                
                
                
                // revisamos si es local y cargamos datos 
                if (gg.Identifiacion == Convert.ToInt32(name[0]))
                {

                    button5.Enabled = true;

                    groupBox2.Enabled = true;
                    jlocal.Enabled = true;
                    tlocal.Enabled = true;
                    TipoL.Enabled = true;
                    jlocal.SelectedIndex = local;
                    tlocal.SelectedItem = gg.tiempo;
                    TipoL.SelectedItem = gg.tipo;
                }
                local = local + 1;


            }
            foreach(var i in jvisita.Items)
            {
                string[] name = i.ToString().Split('|');
                //validamos que sea del equipo visita y cargamos datos 
                if (gg.Identifiacion == Convert.ToInt32(name[0]))
                {
                   
                    groupBox3.Enabled = true;
                    jvisita.Enabled = true;
                    tiempoV.Enabled = true;
                    TipoV.Enabled = true;
                    button6.Enabled = true;
                    jvisita.SelectedIndex = visita;
                    tiempoV.SelectedItem = gg.tiempo;
                    TipoV.SelectedItem = gg.tipo;
                }

                visita = visita + 1;
            }
           
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tiempoV.SelectedIndex < 0 && jvisita.SelectedIndex < 0 && TipoV.SelectedIndex < 0)
            {
                MessageBox.Show("Un Campo no ha sido seleccionado, ingrese todos los datos pra continuar");
            }
            else
            {  //modificar un goleador 
                goles gg = new goles();
                string[] name = jlocal.SelectedItem.ToString().Split('|');
                gg.Identifiacion = Convert.ToInt32(name[0]);
                gg.id_Gol = Convert.ToInt32(GetId());
                gg.id_juego = ids;
                gg.tiempo = Convert.ToInt32(tlocal.SelectedItem);
                gg.tipo = TipoL.SelectedItem.ToString();
                gconte.update(gg);
               
            }
            Gettp();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tiempoV.SelectedIndex < 0 && jvisita.SelectedIndex < 0 && TipoV.SelectedIndex < 0)
            {
                MessageBox.Show("Un Campo no ha sido seleccionado, ingrese todos los datos pra continuar");
            }
            else
            { //modificar un goleador 
                goles gg = new goles();
                string[] name = jvisita.SelectedItem.ToString().Split('|');
                gg.Identifiacion = Convert.ToInt32(name[0]);
                gg.id_Gol = Convert.ToInt32(GetId());
                gg.id_juego = ids;
                gg.tiempo = Convert.ToInt32(tiempoV.SelectedItem);
                gg.tipo = TipoV.SelectedItem.ToString();
                gconte.update(gg);
                
            }
            Gettp();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
