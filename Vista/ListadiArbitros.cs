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
    public partial class ListadiArbitros : Form
    {
        public arbitroDB arbitroDB = new arbitroDB();

        public ListadiArbitros()
        {
            InitializeComponent();
            listAlquileres.DataSource = arbitroDB.manejoArbitros();
        }
    }
}
