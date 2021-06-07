using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    class ControlAmonestacion
    {
        public int Id_Juego { get; set; }

        public int Id_Jugador { get; set; }

        public string Color_Tarjeta { get; set; }

        public string Tiempo { get; set; }

        public Boolean Pagado { get; set; }

        public string Nombres { get; set; }
    }
}
