using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Torneo
    {
        public int ID_Torneo { get; set; }
        public string nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public string Tipo { get; set; }
        public int edad_minima { get; set; }
        public int edad_Maxima { get; set; }
        public int puntos_partido_ganado { get; set; }
        public int puntos_partido_perdido { get; set; }
        public int puntos_partido_empatado { get; set; }
        public int Tipo_de_Campo { get; set; }
        public double precio { get; set; }
    }
}
