using System;
namespace HotelReservaciones.Datos
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string usuario { get; set; }
        public string contrasenaUsuario { get; set; }
        public string estadoUsuario { get; set; }
        public string FullName => $"{nombreUsuario} {apellidoUsuario}";
    }
}

