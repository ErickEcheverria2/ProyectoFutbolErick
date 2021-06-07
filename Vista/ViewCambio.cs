using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class ViewCambio : Form
    {
        public int? id, idTorneo;
        CambioDB combo = new CambioDB();
        CambioDB combo2 = new CambioDB();
        CambioDB combo3 = new CambioDB();
        public CambioDB cambioContext = new CambioDB();
        public cambio cambioSeleccionado = new cambio();
        public int  idjuego ;

        public ViewCambio(int tiempo, int idjuegos, int idTorneo)
        {

            InitializeComponent();

            //  combo.Buscar_Partido_combox(comboBox1);
            idjuego = idjuegos;
            txtJuego.Text = Convert.ToString(idjuego);

            listCambios.AllowUserToAddRows = false;
            listCambios.AllowDrop = false;
            listCambios.AllowUserToDeleteRows = false;
            listCambios.ReadOnly = true;
            this.idTorneo = idTorneo;
            mostrar();
            for (int i = 1; i <= tiempo; i++)
            {
                entrada.Items.Add(i);
                salida.Items.Add(i);
            }

            string[] datos = cambioContext.captarinfo(Convert.ToInt32(idjuego));
            txtTorneo.Text = datos[0];
            combo3.buscar_equipos(cbEquipos, Convert.ToInt32(idjuego), Convert.ToInt32(txtTorneo.Text));
            txtJuego.Enabled = false;
            txtTorneo.Enabled = false;
        }

        private void ViewCambio_Load(object sender, EventArgs e)
        {

        }
        public void mostrar()
        {
            listCambios.DataSource = cambioContext.manejoCambios(idjuego);
            listCambios.Columns[0].Visible = false;
           
            listCambios.Columns[3].Visible = false;
            listCambios.Columns[2].Visible = false;
            listCambios.Columns[1].Visible = false;

            int x = listCambios.Rows.Count;// contamos lass lineas de datos 

            if (x == 0) //
            {
                MessageBox.Show("Conexion exitosa , pero la tabla buscada no tiene datos");

            }
            else
            {

            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBox1.SelectedIndex > 0)
            {


                string[] datos = cambioContext.captarinfo(Convert.ToInt32(idjuego));
                txtTorneo.Text = datos[0];
                combo3.buscar_equipos(cbEquipos, Convert.ToInt32(idjuego), Convert.ToInt32(txtTorneo.Text));
            }*/
        }

        private void txtLocal_TextChanged(object sender, EventArgs e)
        {
            combo2.Buscar_Jugafor_combox(comboBox2, Convert.ToInt32(txtTorneo.Text));
        }

        private void txtVisita_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                string[] valores = cambioContext.buscar_identificacion_por_nombre(comboBox2.Text);
                lblEntra.Text = valores[0];
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > 0)
            {
                string[] valores = cambioContext.buscar_identificacion_por_nombre(comboBox3.Text);
                lblSale.Text = valores[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == comboBox3.Text)
            {
                MessageBox.Show("El jugador debe ser distinto al de salida");
            }
            else
            {
             
                    cambio ingreso_cambio = new cambio();
                    ingreso_cambio.id_juego = idjuego;
                        ingreso_cambio.dpi_jugEntra = Convert.ToInt32(lblEntra.Text);
                    ingreso_cambio.dpi_jugSale = Convert.ToInt32(lblSale.Text);
                    ingreso_cambio.Tiempo_Entrada = Convert.ToString(entrada.SelectedItem);
                    ingreso_cambio.Tiempo_Salida = Convert.ToString(salida.SelectedItem);
                    cambioContext.Insertar_Cambios(ingreso_cambio);
                    mostrar();
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    entrada.SelectedIndex = -1;
                    salida.SelectedIndex = -1;
                cbEquipos.SelectedIndex = -1;
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enlistar los jugadores en comboBox2 y combobox al celeccionar un equipo en el combobox cbEquipos
            combo2.busqueda_tabla_jugadoress_por_equipo(comboBox2, Convert.ToString(cbEquipos.Text), Convert.ToInt32(txtTorneo.Text));
            combo2.busqueda_tabla_jugadoress_por_equipo(comboBox3, Convert.ToString(cbEquipos.Text), Convert.ToInt32(txtTorneo.Text));
        }


        private int? buscar_id()
        {
            try
            {
                return int.Parse(listCambios.Rows[listCambios.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            int? id_cambio = buscar_id();
            cambioContext.eliminar_cambio(id_cambio);
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id_cambio = buscar_id();
            cambio cambio_actualizar = cambioContext.buscar(id_cambio);
            txtJuego.Text = Convert.ToString(cambio_actualizar.id_juego);
            lblEntra.Text = Convert.ToString(cambio_actualizar.dpi_jugEntra);
            lblSale.Text = Convert.ToString(cambio_actualizar.dpi_jugSale);
            comboBox2.Text= cambio_actualizar.Nombre_Entrada;
            comboBox3.Text=cambio_actualizar.Nombre_Salida;
            cbEquipos.Text = cambio_actualizar.equipo;
            entrada.Text = cambio_actualizar.Tiempo_Entrada;
            salida.Text = cambio_actualizar.Tiempo_Salida;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           int? id_cambio = buscar_id();

            int id_Juego = Convert.ToInt32(txtJuego.Text);
            int dpi_entra = Convert.ToInt32(lblEntra.Text);
            int dpi_sale = Convert.ToInt32(lblSale.Text);
            string entra = entrada.Text;
            string sale = salida.Text;

            cambioContext.actualizar_cambio(id_cambio,id_Juego,dpi_entra,dpi_sale,entra,sale);
            mostrar();
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            entrada.SelectedIndex = -1;
            salida.SelectedIndex = -1;
            cbEquipos.SelectedIndex = -1;
        }

        private void ViewCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Partidos partidos = new Partidos(idTorneo);
            partidos.Show();
        }
    }
}
