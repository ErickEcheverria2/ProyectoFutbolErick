using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class ServicioArbitraje
    {
        public int Id_Alquiler { get; set; }
        public long DPI_Arbitro { get; set; }
        public decimal pagoArbitraje { get; set; }
        public DateTime DiaJuego { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }

    }
}
