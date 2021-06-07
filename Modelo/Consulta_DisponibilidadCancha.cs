using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Modelo
{
    public class Consulta_DisponibilidadCancha
    {
        public DateTime FechaHora { get; set; }
        public string NombreTorneo { get; set; }
        public string NombreEquipoLocal { get; set; }
        public string NombreEquipoVisita { get; set; }
       
    }
}