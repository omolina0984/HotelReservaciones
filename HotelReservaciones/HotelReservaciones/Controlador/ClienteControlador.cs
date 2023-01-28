using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using HotelReservaciones.Datos;

namespace HotelReservaciones.Controlador
{
	public class ClienteControlador
	{
        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Cliente> _post;
        WebClient cliente = new WebClient();

        public string nuevaCliente(int idUsuario,
                                   string cedulaCliente,
                                   int idHotel)
        {
            string mensaje = "";
            try
            {
                var parametros = new NameValueCollection();
                parametros.Add("idUsuario", idUsuario.ToString());
                parametros.Add("cedulaCliente", cedulaCliente);
                parametros.Add("idHotel", idHotel.ToString());
                cliente.UploadValues(servicio.urlGetCliente().ToString(), "POST", parametros);
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

