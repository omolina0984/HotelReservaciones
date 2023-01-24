using System;
namespace HotelReservaciones.Controlador
{
	public class Service
	{

        private string urlservicio = "http://192.168.100.50";
		public string urlHotel()
		{
			string url = urlservicio+"/AppHotelService/Hotel.php";
			return url;
        }


        public string urlGetTipoHabitacion()
        {
            string url = urlservicio+"/AppHotelService/TipoHabitacion.php";
            return url;
        }

        public string urlGetHabitacion()
        {
            string url = urlservicio+"/AppHotelService/Habitacion.php";
            return url;
        }
        public string urlGetHabitacionIdHabitacion()
        {
            string url = urlservicio + "/AppHotelService/Habitacion.php?idHabitacion=";
            return url;
        }

        public string urlGetHotelHabitacion()
        {
            string url = urlservicio+"/AppHotelService/HotelHabitacion.php?idHotel=";
            return url;
        }

    }
}

