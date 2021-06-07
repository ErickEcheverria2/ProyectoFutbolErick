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
    public partial class TorneoCRUD : Form
    {
        public Torneo  tr = new Torneo ();
        public TorneoDB trcontext = new TorneoDB();
        public partidosDB prcontext = new partidosDB();
        Equipo_TorneoDB etrcontext = new Equipo_TorneoDB();

        public VentanaLoginDB loginDB = new VentanaLoginDB();

        int Id_UsuarioIngresado;


        public TorneoCRUD(int Id_Usuario)
        {
            InitializeComponent(); //inicializamos los componentes 
            Gettp();
            txtcodigo.Text = Convert.ToString(trcontext.maxid());
            listtorneo.AllowUserToAddRows = false;
            listtorneo.AllowDrop = false;
            listtorneo.AllowUserToDeleteRows = false;
            listtorneo.MultiSelect = false;

            Id_UsuarioIngresado = Id_Usuario;


        }


        private int getEdadMinima()
        {
            try
            {
                return int.Parse(
                    listtorneo.Rows[listtorneo.CurrentRow.Index].Cells[5].Value.ToString()
                    );
            }
            catch
            {
                return 0;
            }
        }


        private int getEdadMaxima()
        {
            try
            {
                return int.Parse(
                    listtorneo.Rows[listtorneo.CurrentRow.Index].Cells[6].Value.ToString()
                    );
            }
            catch
            {
                return 0;
            }
        }







        private int? GetId() //obtenemos el id de cada fila
        {
            try
            {
                return int.Parse(
                    listtorneo.Rows[listtorneo.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        public enum acciones
        {
            editar = 0,
            guardar = 1
        }
        public int accion = 1;
        public void Gettp()
        {
            listtorneo.DataSource = trcontext.GetTorneos(); //llenamos la lista con los elementos en la base
            
            int x = listtorneo.Rows.Count;// contamos lass lineas de datos 

            if (x == 0) //
            {
                MessageBox.Show("Conexion exitosa , pero la tabla buscada no tiene datos");
                editar.Enabled = false;
                eliminar.Enabled = false;
            }
            else
            {
                editar.Enabled = true;
                eliminar.Enabled = true;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int validar = 0;
            if (accion == 1)
            {
                if (preciotorneo.Value > 0)
                {


                    if (cmbcategoria.SelectedIndex >= 0 && cmbjugadores.SelectedIndex >= 0)
                    {

                        Torneo tr = new Torneo(); //instanciamos el modelo de los datos 

                        tr.nombre = txtname.Text; // asigmanos los valores del modelo
                        tr.Inicio = fechainicio.Value;
                        tr.Final = fecha_final.Value;
                        tr.Tipo = cmbcategoria.SelectedItem.ToString();
                        tr.edad_minima = Convert.ToInt32(edmn.Value);
                        tr.edad_Maxima = Convert.ToInt32(edmx.Value);
                        tr.puntos_partido_ganado = Convert.ToInt32(pganado.Value);
                        tr.puntos_partido_perdido = Convert.ToInt32(pperdido.Value);
                        tr.puntos_partido_empatado = Convert.ToInt32(pempatado.Value);
                        tr.Tipo_de_Campo = Convert.ToInt32(cmbjugadores.SelectedItem.ToString());
                        tr.precio = Convert.ToDouble(preciotorneo.Value);
                        List<Torneo> trs = trcontext.GetTorneos();
                        foreach(var i in trs)
                        {
                            if ( tr.nombre==i.nombre)
                            {
                                validar = 1;
                            }
                        }
                        if (validar==1)
                        {
                            MessageBox.Show("Ese nombre de torneo ya fue registrado ");

                        }
                        else
                        {
                            trcontext.Addctr(tr); // mandamos a llamar una fucnion para agregar a la base de datoa el modelo

                        }
                        Gettp();

                    }
                    else
                    {
                        MessageBox.Show(" seleccione  el tipo de campo y el tipo de torneo  , para continuar");
                    }
                }
                else
                {
                    MessageBox.Show(" Ingrese un precio mayor a cero para el Torneo");
                    }
            }
            else if (accion == 0)
            {
                if (cmbcategoria.SelectedIndex >= 0 && cmbjugadores.SelectedIndex >= 0)
                {
                    List<Torneo> trs = trcontext.GetTorneos();
                    foreach (var i in trs)
                    {
                        if (txtname.Text == i.nombre)
                        {
                            validar = 1;
                        }
                    }
                    if (validar == 1)
                    {
                       
                        MessageBox.Show("Ese nombre de torneo ya fue registrado ");

                    }
                    else
                    {
                        trcontext.UPDTR(Convert.ToInt32(txtcodigo.Text), txtname.Text, fechainicio.Value, fecha_final.Value, cmbcategoria.SelectedItem.ToString(), Convert.ToInt32(edmn.Value), Convert.ToInt32(edmx.Value), Convert.ToInt32(cmbjugadores.SelectedItem.ToString()), Convert.ToInt32(pganado.Value), Convert.ToInt32(pempatado.Value), Convert.ToInt32(pperdido.Value));
                        // mandamos a llamar una fucnion para agregar a la base de datoa el modelo

                        listtorneo.Enabled = true;
                    }

                    Gettp();
                }
                else
                {
                    MessageBox.Show(" seleccione  el tipo de campo y el tipo de torneo  , para continuar");
                }
                  
            }

        }

        private void aggequipos_Click(object sender, EventArgs e)
        {
            this.Hide(); // de momento sirve de transcicion a equipos
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void editar_Click(object sender, EventArgs e)
        {
            listtorneo.Enabled = false;

            preciotorneo.Enabled = false;
            accion = 0; //volvemos la accion en cero  y cargamos los datos que se han seleccionado 
            int? id = GetId();
            Torneo tr=  trcontext.Gettorneo(id);
            txtcodigo.Text = Convert.ToString(tr.ID_Torneo);
            txtname.Text = tr.nombre;
            fechainicio.Value = tr.Inicio;
            fecha_final.Value = tr.Final;
            cmbcategoria.SelectedItem = tr.Tipo;
            edmn.Value = tr.edad_minima;
            edmx.Value = tr.edad_Maxima;
            cmbjugadores.SelectedItem = Convert.ToString(tr.Tipo_de_Campo);
            pganado.Value = tr.puntos_partido_ganado;
            pempatado.Value = tr.puntos_partido_empatado;
            pperdido.Value = tr.puntos_partido_perdido;
            preciotorneo.Value = Convert.ToDecimal(tr.precio);

        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId(); //obtnemos el id 
            trcontext.DeleteTR(id);//llamamos a la funcion de eliminar con el id seleccionado
            Gettp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int? id = GetId(); //obtnemos el id
            List<partidos> prlist = prcontext.listadoJornadas(id);

            if (prlist.Count == 0)
            {
                loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Agregar Equipos a Torneo");
                int? idtorneo = GetId();
                ListaEquipo vq = new ListaEquipo(Convert.ToInt32(idtorneo), getEdadMinima(), getEdadMaxima());
                vq.ShowDialog();
            }
            else
            {
                MessageBox.Show(" El Torneo ya comenzo no se pueden editar los participantes ");
            }
        

         }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId(); //obtnemos el id
            List<Equipo_Torneo> eqtr = etrcontext.Gettorneoequipo(Convert.ToInt32(id));
             List<partidos> prlist = prcontext.listadoJornadas(id);

            if ( eqtr.Count>1)
            {

                if (prlist.Count == 0)
                {
                    int val = 0;

                    List<Equipo_Torneo> listaEquipo = prcontext.manejoPartidos(id);
                    foreach (Equipo_Torneo et in listaEquipo)
                    {

                        foreach (Equipo_Torneo et2 in listaEquipo)
                        {
                            if (et == et2) { }
                            else if (et != et2)
                            {
                                partidos pr = new partidos();
                                pr.id_torneo = Convert.ToInt32(id);
                                pr.id_Equipo_local = et.id_equipo;
                                pr.id_Equipo_visita = et2.id_equipo;
                                val = prcontext.Guardar_lista(pr);
                            }
                        }
                    }
                    if (val == 1)
                    {
                        MessageBox.Show("Jornadas Creadas Exitosamente ");
                        loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Creó Jornadas");
                    }
                }
                else
                {
                    MessageBox.Show("Las Jornadas de este torneo ya fueron creadas");
                    loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Intento fallido para crear Jornadas");
                }
            }else
            {
                MessageBox.Show("No tenemos equipos suficientes agregados al torneo, ingrese equipos y luego podra crear  las jornadas");
            }
        }

        private void TorneoCRUD_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId(); //obtnemos el id
            List<partidos> prlist = prcontext.listadoJornadas(id);

            if (prlist.Count > 0)
            {
                loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Ver Jornadas");
                Partidos pr = new Partidos(id);

                pr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aun no se han creado jornadas para este torneo ");
            }
        }

        private void edmn_ValueChanged(object sender, EventArgs e)
        {
            edmx.Minimum = edmn.Value + 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void listtorneo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
