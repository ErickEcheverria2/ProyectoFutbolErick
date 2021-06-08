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
    public partial class listaJugadores : Form
    {
        public listaJugadoresDB jrcontext = new listaJugadoresDB();
        public listaJugadores()
        {
            InitializeComponent();

            listjugadores.AllowUserToAddRows = false;
            listjugadores.AllowDrop = false;
            listjugadores.AllowUserToDeleteRows = false;
            listjugadores.MultiSelect = false;
            listjugadores.ReadOnly = true;

            mostrar_jugadores_datagrid();
        }

        public void mostrar_jugadores_datagrid()
        {

            listjugadores.DataSource = jrcontext.Getjugadores();
        }

        private void listaJugadores_Load(object sender, EventArgs e)
        {
           

        }
    }
}
