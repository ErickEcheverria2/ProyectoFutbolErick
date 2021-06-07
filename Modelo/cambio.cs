using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class cambio
    {
        public int id_cambio
        {
            get;
            set;
        }

        public int id_juego
        {
            get;
            set;
        }

        public string equipo
        {
            get;
            set;
        }
        public int dpi_jugEntra
        {
            get;
            set;
        }

        public int dpi_jugSale
        {
            get;
            set;
        }

        public String Nombre_Entrada
        {
            get;
            set;
        }

        public String Nombre_Salida
        {
            get;
            set;
        }

        public String Tiempo_Entrada
        {
            get;
            set;
        }

        public String Tiempo_Salida
        {
            get;
            set;
        }
    }
}
