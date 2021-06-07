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
    public partial class ViewEntrenador : Form
    {
        EntrenadorDB entrenadorController = new EntrenadorDB();
        int opcion = 0;

        public ViewEntrenador()
        {
            InitializeComponent();
            cbxBuscar.Items.Add("Equipo");
            cbxBuscar.Items.Add("Nombre");
            cbxBuscar.Items.Add("Apellidos");
            cbxBuscar.Items.Add("DPI");
            listEntrenadores.DataSource = entrenadorController.getEntrenadores();
            entrenadorController.optionsEquipo(cbxEquipo);
            updateTable();
        }

        private void ViewEntrenador_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewEquipo viewEquipo = new ViewEquipo();
            viewEquipo.Show();
        }

        //Método para obtener el codigo del cliente
        public int getDPI()
        {
            try
            {
                return int.Parse(listEntrenadores.Rows[listEntrenadores.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public void updateTable()
        {
            listEntrenadores.DataSource = entrenadorController.getEntrenadores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrEmpty(cbxBuscar.Text)))
            {
                int opcionBusqueda = cbxBuscar.SelectedIndex;
                string busqueda = txtBuscar.Text;
                listEntrenadores.DataSource = entrenadorController.searchEntrenador(opcionBusqueda, busqueda);
            }
            else
            {
                MessageBox.Show("Llene los datos para la búsqueda","Error en búsqueda");
            }
        }

        private void btnBorrarBusqueda_Click(object sender, EventArgs e)
        {
            listEntrenadores.DataSource = entrenadorController.getEntrenadores();
            txtBuscar.Clear();
            cbxBuscar.SelectedIndex = -1;
        }

        private void cbxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxEquipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(cbxEquipo.Text) || 
                string.IsNullOrEmpty(txtDPI.Text) || 
                string.IsNullOrEmpty(txtNombre.Text) || 
                string.IsNullOrEmpty(txtApellidos.Text) || 
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtTiempo.Text) ||
                string.IsNullOrEmpty(txtSalario.Text))
            ){
                Entrenador entrenador = new Entrenador();

                string equipo = Convert.ToString(cbxEquipo.SelectedItem);
                string[] equipoArray = equipo.Split('|');
                //Codigo del equipo almacenado en la posicion 0
                int idEquipo = Convert.ToInt32(equipoArray[0]);

                entrenador.id_equipo = idEquipo;
                entrenador.dpi = Convert.ToInt32(txtDPI.Text);
                entrenador.nombre = txtNombre.Text;
                entrenador.apellidos = txtApellidos.Text;
                entrenador.telefono = txtTelefono.Text;
                entrenador.fechanac = Convert.ToDateTime(dtFechaNac.Value.ToString("yyyy-MM-dd"));
                entrenador.correo = txtCorreo.Text;
                entrenador.tiempo = txtTiempo.Text;
                entrenador.salario = txtSalario.Text;
                switch (opcion)
                {
                    case 0:
                        entrenadorController.addEntrenador(entrenador);

                        break;
                    case 1:
                        entrenadorController.updateEntrenador(entrenador);
                        listEntrenadores.Enabled = true;
                        break;
                }
                cbxEquipo.SelectedIndex = -1;
                txtDPI.Clear();
                txtNombre.Clear();
                txtApellidos.Clear();
                txtTelefono.Clear();
                dtFechaNac.Value = DateTime.Now;
                txtCorreo.Clear();
                txtTiempo.Clear();
                txtSalario.Clear();
                updateTable();
            }
            else
            {
                MessageBox.Show("Ingresa todos los datos", "Error al realizar la operación");
            }

            opcion = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            listEntrenadores.Enabled = false;

            Entrenador entrenadorToUpdate = entrenadorController.getEntrenadorById(getDPI());
            txtDPI.Text = Convert.ToString(entrenadorToUpdate.dpi);
            txtNombre.Text = entrenadorToUpdate.nombre;
            txtApellidos.Text = entrenadorToUpdate.apellidos;
            txtTelefono.Text = entrenadorToUpdate.telefono;
            dtFechaNac.Value = entrenadorToUpdate.fechanac;
            txtCorreo.Text = entrenadorToUpdate.correo;
            txtTiempo.Text = entrenadorToUpdate.tiempo;
            txtSalario.Text = entrenadorToUpdate.salario;

            foreach(var i in cbxEquipo.Items)
            {
                string[] data = i.ToString().Split('|');
                int id = Convert.ToInt32(data[0]);
                if (id ==entrenadorToUpdate.id_equipo)
                {
                    cbxEquipo.SelectedItem = i.ToString();
                }

            }

          
            opcion = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            entrenadorController.deleteEntrenador(getDPI());
            updateTable();
        }

        private void cbxEquipo_MouseClick(object sender, MouseEventArgs e)
        {
            cbxEquipo.DroppedDown = true;
        }

        private void cbxBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            cbxBuscar.DroppedDown = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
