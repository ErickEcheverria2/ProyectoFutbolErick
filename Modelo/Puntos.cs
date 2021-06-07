using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Puntos
    {
        public int id_punteo
        {
            get;
            set;
        }

        public int id_juego
        {
            get;
            set;
        }

        public int id_equipo_local
        {
            get;
            set;
        }

        public int id_equipo_visita
        {
            get;
            set;
        }

        public int punteo_equipo_local
        {
            get;
            set;
        }

        public int punteo_equipo_visita
        {
            get;
            set;
        }

        public int marcador_local
        {
            get;
            set;
        }

        public int marcador_visita
        {
            get;
            set;
        }

    }
}
