using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class InformacionEmpresa
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal CostoDeArbitraje { get; set; }
        public TimeSpan HoraEntradaLunes { get; set; }
        public TimeSpan HoraSalidaLunes { get; set; }
        public TimeSpan HoraEntradaMartes { get; set; }
        public TimeSpan HoraSalidaMartes { get; set; }
        public TimeSpan HoraEntradaMiercoles { get; set; }
        public TimeSpan HoraSalidaMiercoles { get; set; }
        public TimeSpan HoraEntradaJueves { get; set; }
        public TimeSpan HoraSalidaJueves { get; set; }
        public TimeSpan HoraEntradaViernes { get; set; }
        public TimeSpan HoraSalidaViernes { get; set; }
        public TimeSpan HoraEntradaSabado { get; set; }
        public TimeSpan HoraSalidaSabado { get; set; }
        public TimeSpan HoraEntradaDomingo { get; set; }
        public TimeSpan HoraSalidaDomingo { get; set; }

    }
}
