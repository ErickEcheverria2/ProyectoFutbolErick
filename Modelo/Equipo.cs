using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    class Equipo
    {
        public int id_equipo { get; set; }

        public string nombre { get; set; }

        public int cantidadJugadores { get; set; }

        public string representante { get; set; }
    }
}
