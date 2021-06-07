using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    class Entrenador
    {
        public int dpi { get; set; }

        public int id_equipo { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string telefono { get; set; }

        public DateTime fechanac{ get; set; }

        public string correo { get; set; }

        public string tiempo { get; set; }

        public string salario { get; set; }
    }
}
