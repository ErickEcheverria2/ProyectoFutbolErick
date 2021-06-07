using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using Administracion_Torneos.BD;


namespace Administracion_Torneos.Modelo
{
    public class Arbitro
    {
        public long Dpi
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Apellidos
        {
            get;
            set;
        }

        public string Direccion
        {
            get;
            set;
        }

        public string Telefono
        {
            get;
            set;
        }

        public string Nacionalidad
        {
            get;
            set;
        }

        public DateTime FechaNac
        {
            get;
            set;
        }

        public string Correo
        {
            get;
            set;
        }

        public string Rol
        {
            get;
            set;
        }
    }
}
