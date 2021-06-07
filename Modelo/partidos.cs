using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class partidos
    {
        public int id_juego
        {
            get;
            set;
        }

        public int id_torneo
        {
            get;
            set;
        }

        public int id_Equipo_local
        {
            get;
            set;
        }

        
        public int id_Equipo_visita
        {
            get;
            set;
        }
        public string EquipoLocal { get; set; }
        public string EquipoVisita { get; set; }
        public DateTime fecha
        {
            get;
            set;
        }

        public TimeSpan hora_inicio
        {
            get;
            set;
        }

        public TimeSpan hora_fin
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

        public bool jugado
        {
            get;
            set;
        }

    }
}
