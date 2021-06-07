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
    public partial class ViewEquipo : Form
    {
        //Instancia del controladro de Cliente
        EquipoDB equipoController = new EquipoDB();
        int opcion = 0;

        public ViewEquipo()
        {
            InitializeComponent();
            updateTable();
        }

        private void updateTable()
        {
            listEquipo.DataSource = equipoController.loadTableData();
        }

        //Método para obtener el codigo del equipo
        public int getId()
        {
            try
            {
                return Convert.ToInt32(int.Parse(listEquipo.Rows[listEquipo.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch
            {
                return 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            if(txtNombre.Text == string.Empty || txtJugadores.Text == string.Empty || txtRepresentante.Text == string.Empty)
            {
                MessageBox.Show("Ingresa todos los datos", "Error al realizar la operación");
            }
            else
            {
                switch (opcion)
                {
                    case 0:
                        equipo.nombre = txtNombre.Text;
                        equipo.cantidadJugadores = Convert.ToInt32(txtJugadores.Text);
                        equipo.representante = txtRepresentante.Text;

                        equipoController.addEquipo(equipo);
                        updateTable();

                        txtNombre.Text = string.Empty;
                        txtJugadores.Text = string.Empty;
                        txtRepresentante.Text = string.Empty;
                        break;

                    case 1:
                        equipo.id_equipo = getId();
                        equipo.nombre = txtNombre.Text;
                        equipo.cantidadJugadores = Convert.ToInt32(txtJugadores.Text);
                        equipo.representante = txtRepresentante.Text;

                        equipoController.updateEquipo(equipo);
                        updateTable();

                        listEquipo.Enabled = true;

                        txtNombre.Text = string.Empty;
                        txtJugadores.Text = string.Empty;
                        txtRepresentante.Text = string.Empty;
                        opcion = 0;
                        break;


                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            listEquipo.Enabled = false;

            Equipo equipo = equipoController.getEquipoById(getId());

            txtNombre.Text = equipo.nombre;
            txtJugadores.Text = Convert.ToString(equipo.cantidadJugadores);
            txtRepresentante.Text = equipo.representante;
            opcion = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            equipoController.deleteEquipo(getId());
            updateTable();
        }
    }
}
