using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Consulta_BitacoraDeAcceso
    {
        public string Nombre_Usuario { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime FechaHoraAcceso { get; set; }
        public string SeccionEntrada { get; set; }
    }
}
