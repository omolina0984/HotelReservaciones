using System;
namespace HotelReservaciones.Controlador
{
	public class Service
	{

        //private string urlservicio = "http://192.168.100.50/AppHotelService/";
        private string urlservicio = "http://eyecomers.com/";
        public string urlHotel()
		{
			string url = urlservicio+"Hotel.php";
			return url;
        }

        public string urlHotelId()
        {
            string url = urlservicio + "Hotel.php?idHotel=";
            return url;
        }

        public string urlGetTipoHabitacion()
        {
            string url = urlservicio+"TipoHabitacion.php";
            return url;
        }

        public string urlGetHabitacion()
        {
            string url = urlservicio+"Habitacion.php";
            return url;
        }
        public string urlGetHabitacionIdHabitacion()
        {
            string url = urlservicio + "Habitacion.php?idHabitacion=";
            return url;
        }

        public string urlGetHotelHabitacion()
        {
            string url = urlservicio+"HotelHabitacion.php?idHotel=";
            return url;
        }

        public string urlLogin()
        {
            string url = urlservicio + "usuarioLogin.php?usuario=";
            return url;
        }

        public string urlGetUsuario()
        {
            string url = urlservicio + "usuario.php";
            return url;
        }


        public string urlGetUsuarioId()
        {
            string url = urlservicio + "usuario.php?idUsuario=";
            return url;
        }

        public string urlGetCliente()
        {
            string url = urlservicio + "Cliente.php";
            return url;
        }
        public string urlGetClientesReserva()
        {
            string url = urlservicio + "ClientesReserva.php";
            return url;
        }
        public string urlGetReserva()
        {
            string url = urlservicio + "Reservas.php";
            return url;
        }

        public string urlGetHtml()
        {
            string url = urlservicio + "htmlCorreo.php";
            return url;
        }

    }
}

