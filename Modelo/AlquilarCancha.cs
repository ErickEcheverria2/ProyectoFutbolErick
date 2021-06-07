using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Modelo
{
    public class AlquilarCancha
    {
        public int Id_Alquiler { get; set; }
        public long DPI_Persona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int NoCancha { get; set; }
        public DateTime DiaAlquiler { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public decimal costoAlquiler { get; set; }
    }
}