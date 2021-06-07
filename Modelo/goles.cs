using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class goles
    {
        public int id_Gol { get; set; }
        public int id_juego { get; set; }
        public int Identifiacion { get; set; }
        public string Nombre_Jugador { get; set; }
        public string tipo { get; set; }
        public int tiempo { get; set; }
    }
}
