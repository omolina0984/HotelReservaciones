using System;
namespace HotelReservaciones.Datos
{
	public class Habitacion
	{
        public int idHabitacion { get; set; }
        public int idHotel { get; set; }
        public string codigoHabitacion { get; set; }
        public string tipoHabitacion { get; set; }
        public string nombreHabitacion { get; set; }
        public string foto1Habitacion { get; set; }
        public string foto2Habitacion { get; set; }
        public int capacidadHabitacion { get; set; }
        public double precioHabitacion { get; set; }
        public string estadoHabitacion { get; set; }
    }
}

