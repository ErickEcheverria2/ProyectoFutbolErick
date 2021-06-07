using System;

namespace Administracion_Torneos.Modelo
{
    public class UsuarioSistema
    {
        public int Id_Usuario { get; set; }
        public long DPI_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Puesto { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Contraseña { get; set; }

    }
}
