using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using HotelReservaciones.Datos;

namespace HotelReservaciones.Controlador
{
    public class ReservaControlador
    {
        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Reserva> _post;
        WebClient cliente = new WebClient();


        public string nuevaReserva( string codigoReserva,
                                    int idCliente,
                                    int idHotel,
                                    int idHabitacion,
                                    int numdiasReserva,
                                    string horaIngreso,
                                    string horaSalida,
                                    DateTime fechaIngreso,
                                    DateTime fechaSalida,
                                    double total)
        {
            string mensaje = "";
            try
            {
                var parametros = new NameValueCollection();
                parametros.Add("codigoReserva", codigoReserva);
                parametros.Add("idCliente", idCliente.ToString());
                parametros.Add("idHotel", idHotel.ToString());
                parametros.Add("idHabitacion", idHabitacion.ToString());
                parametros.Add("numdiasReserva", numdiasReserva.ToString());
                parametros.Add("horaIngreso", horaIngreso);
                parametros.Add("horaSalida", horaSalida);
                parametros.Add("fechaIngreso", fechaIngreso.ToString());
                parametros.Add("fechaSalida", fechaSalida.ToString());
                parametros.Add("total", total.ToString());
                cliente.UploadValues(servicio.urlGetReserva().ToString(), "POST", parametros);
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

