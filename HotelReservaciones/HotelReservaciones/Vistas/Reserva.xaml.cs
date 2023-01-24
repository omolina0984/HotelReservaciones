using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservaciones.Controlador;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace HotelReservaciones.Vistas
{
    public partial class Reserva : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Hotel> _post;
        public Reserva()
        {
            InitializeComponent();
            listarHotel();
        }
        public async void listarHotel()
        {
            Service servicio = new Service();

            string url = servicio.urlHotel().ToString();
            var content = await client.GetStringAsync(url);
            List<Datos.Hotel> posts = JsonConvert.DeserializeObject<List<Datos.Hotel>>(content);
            _post = new ObservableCollection<Datos.Hotel>(posts);
            ListHotel.ItemsSource = _post;
        }

       

        async void ListHotel_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var hotelSelect = (Datos.Hotel)e.Item;
                string codigo = hotelSelect.idHotel.ToString();
                // await DisplayAlert("You selected", codigo, "Cancel");
                await Navigation.PushAsync(new HabitacionesHotel(codigo));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");

            }
        }
    }
}

