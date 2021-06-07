using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Modelo
{
    public class Cancha
    {
        public int NoCancha { get; set; }
        public string Nombre { get; set; }
        public string Capacidad { get; set; }
        public string estatus { get; set; }
        public decimal precioDeAlquiler { get; set; }
    }
}
