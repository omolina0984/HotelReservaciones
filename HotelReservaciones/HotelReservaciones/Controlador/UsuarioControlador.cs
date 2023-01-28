using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;

namespace HotelReservaciones.Controlador
{
	public class UsuarioControlador
	{
        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        //private ObservableCollection<Datos.Usuario> _post;
        WebClient cliente = new WebClient();

        public string nuevoUsuario(
                                    //int idTipoUsuario,
                                    string nombreUsuario,
                                    string apellidoUsuario,
                                    string correoUsuario,
                                    string usuario,
                                    string passwordUsuario)
        //string estadoUsuario)
        {
            string mensaje = "";
            try
            {
                var parametros = new NameValueCollection();
                //parametros.Add("idUsuario", idUsuario.ToString());
                //parametros.Add("idTipoUsuario", idTipoUsuario.ToString());
                parametros.Add("nombreUsuario", nombreUsuario);
                parametros.Add("apellidoUsuario", apellidoUsuario);
                parametros.Add("correoUsuario", correoUsuario);
                parametros.Add("usuario", usuario);
                parametros.Add("contrasenaUsuario", passwordUsuario);
                //parametros.Add("estadoUsuario", estadoUsuario);
                string urlser = servicio.urlGetUsuario().ToString();
                cliente.UploadValues(servicio.urlGetUsuario().ToString(), "POST", parametros);
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

