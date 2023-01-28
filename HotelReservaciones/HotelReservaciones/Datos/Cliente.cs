using System;
namespace HotelReservaciones.Datos
{
	public class Cliente
	{
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public string cedulaCliente { get; set; }
        public int idHotel { get; set; }
        public string estadoCliente { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string FullName => $"{nombreUsuario} {apellidoUsuario}";
    }
}

