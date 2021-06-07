using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Consulta_IngresoDeAlquilerCancha
    {
        public DateTime Fecha { get; set; }
        public int NumeroDeCancha { get; set; }
        public string NombreCancha { get; set; }
        public int CantidadAlquileres { get; set; }
        public decimal MontoRecaudado { get; set; }
    }
}
