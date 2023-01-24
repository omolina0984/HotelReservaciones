using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservaciones.Datos;
using Newtonsoft.Json;

namespace HotelReservaciones.Controlador
{
	public class HotelControlador
	{
        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Hotel> _post;
        WebClient cliente = new WebClient();

        public async Task<IEnumerable<Hotel>> GetAllHotel()
        {

            string url = "http://192.168.100.50/AppHotelService/Hotel.php";
            var content = await client.GetStringAsync(url);
            List<Hotel> posts = JsonConvert.DeserializeObject<List<Hotel>>(content);
            ObservableCollection<Hotel> resultado = new ObservableCollection<Hotel>(posts);
            return resultado;
        }

        public void nuevoHotel(string nombreHotel,
                               string descripcionHotel,
                               string correoHotel,
                               string direccionHote,
                               string ubicacionHotel,
                               string telefonoHotel,
                               string fotoHotel)
        {
            try
            {
                var parametros = new NameValueCollection();
                parametros.Add("nombreHotel", nombreHotel);
                parametros.Add("descripcionHotel", descripcionHotel);
                parametros.Add("correoHotel", correoHotel);
                parametros.Add("direccionHotel", direccionHote);
                parametros.Add("ubicacionHotel", ubicacionHotel);
                parametros.Add("telefonoHotel", telefonoHotel);
                parametros.Add("fotoHotel", fotoHotel);
                cliente.UploadValues(servicio.urlHotel().ToString(), "POST", parametros);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }


    }
}

