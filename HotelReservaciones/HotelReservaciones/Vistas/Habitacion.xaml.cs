using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservaciones.Controlador;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HotelReservaciones.Vistas
{
    public partial class Habitacion : ContentPage
    {
        HabitacionControlador habitacion = new HabitacionControlador();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Hotel> _post;
        private ObservableCollection<Datos.TipoHabitacion> _posttipo;
        private string idHotel = "";
        public Habitacion()
        {
            InitializeComponent();
            listarHotel();
            listarTipoHabitacion();
        }

        void btnAgregar_Clicked(System.Object sender, System.EventArgs e)
        {
            int idHotel = ((Datos.Hotel)listhotel.SelectedItem).idHotel;
            string tipoHabitacion = ((Datos.TipoHabitacion)ddllTipo.SelectedItem).descTipo;
            int capacidad = Convert.ToInt32(txtcapacidad.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            string resultado = habitacion.nuevaHabitacion(idHotel,
                                                          txtcodigoHabitacion.Text,
                                                          tipoHabitacion,
                                                          txtnombreHabitacion.Text,
                                                          txtfoto1Habitacion.Text,
                                                          txtfoto2Habitacion.Text,
                                                          capacidad,
                                                          precio);
            if (resultado == "Exito")
            {
                DisplayAlert("Alerta", "Rsgistro correcto", "Cerrar");
                Navigation.PushAsync(new Principal());
            }
            else
            {
                DisplayAlert("Alerta", resultado, "Cerrar");
            }

        }
        public async void listarHotel()
        {
            Service servicio = new Service();

            string url = servicio.urlHotel().ToString();
            var content = await client.GetStringAsync(url);
            List<Datos.Hotel> posts = JsonConvert.DeserializeObject<List<Datos.Hotel>>(content);
            _post = new ObservableCollection<Datos.Hotel>(posts);
            listhotel.ItemsSource = _post;
        }

        public async void listarTipoHabitacion()
        {
            Service servicio = new Service();

            string urlTipo = servicio.urlGetTipoHabitacion().ToString();
            var contentTipo = await client.GetStringAsync(urlTipo);
            List<Datos.TipoHabitacion> postsTipo = JsonConvert.DeserializeObject<List<Datos.TipoHabitacion>>(contentTipo);
            _posttipo = new ObservableCollection<Datos.TipoHabitacion>(postsTipo);
            ddllTipo.ItemsSource = _posttipo;
        }

        void btnVer_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Reserva());
        }

        void listhotel_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
           // int id = ((Datos.Hotel)listhotel.SelectedItem).idHotel;
           
        }

        void ddllTipo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //string tipo =((Datos.TipoHabitacion)ddllTipo.SelectedItem).descTipo;
        }
    }
}

