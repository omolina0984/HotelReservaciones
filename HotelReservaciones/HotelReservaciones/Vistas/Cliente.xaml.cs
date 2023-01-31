using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HotelReservaciones.Controlador;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace HotelReservaciones.Vistas
{
    public partial class Cliente : ContentPage
    {
        ClienteControlador cliente = new ClienteControlador();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Hotel> _post;
        private ObservableCollection<Datos.Usuario> _postUser;

        public Cliente()
        {
            InitializeComponent();
            listarHotel();
            listarUsuario();
        }

        public async void listarHotel()
        {
            Service servicio = new Service();

            string url = servicio.urlHotel().ToString();
            var content = await client.GetStringAsync(url);
            List<Datos.Hotel> posts = JsonConvert.DeserializeObject<List<Datos.Hotel>>(content);
            _post = new ObservableCollection<Datos.Hotel>(posts);
            listHotel.ItemsSource = _post;
        }

        public async void listarUsuario()
        {
            Service servicio = new Service();

            string url = servicio.urlGetUsuario().ToString();
            var content = await client.GetStringAsync(url);
            List<Datos.Usuario> posts = JsonConvert.DeserializeObject<List<Datos.Usuario>>(content);
            _postUser = new ObservableCollection<Datos.Usuario>(posts);
            listUsuario.ItemsSource = _postUser;
        }



        void listUsuario_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
        }

        void listHotel_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
        }

        void btnAgregar_Clicked(System.Object sender, System.EventArgs e)
        {
            int idUsuario = ((Datos.Usuario)listUsuario.SelectedItem).idUsuario;
            string cedula = txtCedula.Text; 
            int idHotel = ((Datos.Hotel)listHotel.SelectedItem).idHotel;
        
            string resultado = cliente.nuevaCliente(idUsuario,
                                                    cedula,
                                                    idHotel);
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

        void btnVer_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Reserva());
        }
    }
}

