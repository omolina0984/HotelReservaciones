using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservaciones.Controlador;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace HotelReservaciones.Vistas
{
    public partial class ReservarHabitacion : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Habitacion> _post;
        double precio;
        public ReservarHabitacion(string idHabitacion)
        {
            InitializeComponent();
            MostrarHabitacion(idHabitacion);
        }

        public async void MostrarHabitacion(string idHabitacion)
        {
            Service servicio = new Service();

            string url = servicio.urlGetHabitacionIdHabitacion().ToString() + idHabitacion;
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
            img1.Source = _post[0].foto1Habitacion;
            lblNombre.Text = _post[0].nombreHabitacion;
            lbltipo.Text = _post[0].tipoHabitacion;
            lblcapacidad.Text = _post[0].capacidadHabitacion.ToString();
            lblPrecio.Text = "$ " + _post[0].precioHabitacion.ToString();
            precio = _post[0].precioHabitacion;
        }

        void txtDias_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                int dias = Convert.ToInt32(txtDias.Text);
                txtTotal.Text = (precio * dias).ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

