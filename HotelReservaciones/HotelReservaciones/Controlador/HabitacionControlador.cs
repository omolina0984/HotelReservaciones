using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using HotelReservaciones.Datos;
namespace HotelReservaciones.Controlador
{
    public class HabitacionControlador
    {
        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Habitacion> _post;
        WebClient cliente = new WebClient();

        public string  nuevaHabitacion(int idHotel,
                                    string codigoHabitacion,
                                    string tipoHabitacion,
                                    string nombreHabitacion,
                                    string foto1Habitacion,
                                    string foto2Habitacion,
                                    int capacidadHabitacion,
                                    double precioHabitacion)
        {
            string mensaje = "";
            try
            {
                var parametros = new NameValueCollection();
                parametros.Add("idHotel", idHotel.ToString());
                parametros.Add("codigoHabitacion", codigoHabitacion);
                parametros.Add("tipoHabitacion", tipoHabitacion);
                parametros.Add("nombreHabitacion", nombreHabitacion);
                parametros.Add("foto1Habitacion", foto1Habitacion);
                parametros.Add("foto2Habitacion", foto1Habitacion);
                parametros.Add("capacidadHabitacion", capacidadHabitacion.ToString());
                parametros.Add("precioHabitacion", precioHabitacion.ToString());
                cliente.UploadValues(servicio.urlGetHabitacion().ToString(), "POST", parametros);
                mensaje = "Exito";
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return mensaje;
            }
        }
    }
}

