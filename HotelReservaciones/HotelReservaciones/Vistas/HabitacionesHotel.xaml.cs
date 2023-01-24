using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using HotelReservaciones.Controlador;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace HotelReservaciones.Vistas
{
    public partial class HabitacionesHotel : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Habitacion> _post;

        public HabitacionesHotel(string idHotel)
        {
            InitializeComponent();
            listarHabitaciones(idHotel);

        }

        public async void listarHabitaciones(string idHotel)
        {
            Service servicio = new Service();

            string url = servicio.urlGetHotelHabitacion().ToString()+idHotel;
            var content = await client.GetStringAsync(url);

            if (content.Contains("[") && content.Contains("]"))
            {

            }
            else
            {
                content = "[" + content + "]";
            }
          
            List<Datos.Habitacion> posts = JsonConvert.DeserializeObject<List<Datos.Habitacion>>(content);
            _post = new ObservableCollection<Datos.Habitacion>(posts);
            ListHabitaciones.ItemsSource = _post;
        }


        async void ListHotel_ItemTappedAsync(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var habitacionSelect = (Datos.Habitacion)e.Item;
                string codigo = habitacionSelect.idHabitacion.ToString();
                await DisplayAlert("You selected", codigo, "Cancel");
                //await Navigation.PushAsync(new HabitacionesHotel(codigo));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");

            }
        }

       async void ListHabitaciones_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var habitacionSelect = (Datos.Habitacion)e.Item;
                string codigo = habitacionSelect.idHabitacion.ToString();
                //await DisplayAlert("You selected", codigo, "Cancel");
                await Navigation.PushAsync(new ReservarHabitacion(codigo));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");

            }
        }

    

    }
}

