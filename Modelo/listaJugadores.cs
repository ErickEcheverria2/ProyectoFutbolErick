using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
   public class listaJugadores
    {
        public long Identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_naciemiento { get; set; }
        public string direccion { get; set; }
        public string Nacionalidad { get; set; }

        public string correo { get; set; }
        public string Telefono { get; set; }

        public Boolean Menor_de_edad { get; set; }
    }
}
