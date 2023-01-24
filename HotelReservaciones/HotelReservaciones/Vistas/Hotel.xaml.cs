using System;
using System.Collections.Generic;

using Xamarin.Forms;
using HotelReservaciones.Controlador;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace HotelReservaciones.Vistas
{
    public partial class Hotel : ContentPage
    {
        HotelControlador hotel = new HotelControlador();

        Service servicio = new Service();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Hotel> _post;
       
        public Hotel()
        {
            InitializeComponent();

            MyMap.MoveToRegion(
             MapSpan.FromCenterAndRadius(
                    new Position(19.242142,-90.237137),
                    Distance.FromKilometers(30))
                );
         
        }
        //protected override void OnAppearing()
        //{
          //  base.OnAppearing();
            //MyMap.MoveToRegion(
              // MapSpan.FromCenterAndRadius(
                //   new Position(19.242142, -90.237137),
                  // Distance.FromKilometers(30))
               //);
        //}



        public async void listarHotel()
        {
            Service servicio = new Service();
            
            string url = servicio.urlHotel().ToString();
            var content = await client.GetStringAsync(url);
            List<Datos.Hotel> posts = JsonConvert.DeserializeObject<List<Datos.Hotel>>(content);
            _post = new ObservableCollection<Datos.Hotel>(posts);
            //MyListView.ItemsSource = _post;
        }

        void btnRegistro_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                hotel.nuevoHotel(txtNombre.Text,
                                 txtDescripcion.Text,
                                 txtEmail.Text,
                                 txtDireccion.Text,
                                 txtUbicacion.Text,
                                 txtTelefono.Text,
                                 txtFoto.Text);
                DisplayAlert("Alerta", "Rsgistro correcto", "Cerrar");
                Navigation.PushAsync(new Principal());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void btnVer_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Reserva());
        }


    }
}

