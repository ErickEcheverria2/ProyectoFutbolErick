using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Consulta_IngresoServicioDeArbitraje
    {
        public DateTime Fecha { get; set; }
        public int CantidadPartidosParticipados { get; set; }
        public long DPI_Arbitro { get; set; }
        public string NombreCompletoArbitro { get; set; }
        public decimal MontoRecaudado { get; set; }
    }
}
