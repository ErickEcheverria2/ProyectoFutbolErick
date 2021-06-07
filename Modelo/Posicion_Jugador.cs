using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    class Posicion_Jugador
    {
        public int id_torneo { get; set; }

        public int id_equipo { get; set; }

        public long identificacion { get; set; }
        public string Nombres {get; set;}
        public string posicion { get; set; }

        public int numeroCamisola { get; set; }
    }
}
