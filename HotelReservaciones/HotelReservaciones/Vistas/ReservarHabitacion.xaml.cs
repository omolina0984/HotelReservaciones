using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservaciones.Controlador;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms.Shapes;
using System.IO;

namespace HotelReservaciones.Vistas
{
    public partial class ReservarHabitacion : ContentPage
    {
        ReservaControlador reserva = new ReservaControlador();
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Habitacion> _post;
        private ObservableCollection<Datos.Cliente> _postCliente;
        private ObservableCollection<Datos.Usuario> _postUser;
        private ObservableCollection<Datos.htmlCorreo> _postHtml;
        private ObservableCollection<Datos.Hotel> _posthotel;

        int idhabitacion;
        int idHotel;
        double precio;
        public ReservarHabitacion(string idHabitacion)
        {
            InitializeComponent();
            MostrarHabitacion(idHabitacion);
            listarCliente();
        }

      

        public async void listarCliente()
        {
            Service servicio = new Service();

            string url = servicio.urlGetClientesReserva().ToString();
            var content = await client.GetStringAsync(url);
            if (content.Contains("[") && content.Contains("]"))
            {

            }
            else
            {
                content = "[" + content + "]";
            }

            List<Datos.Cliente> posts = JsonConvert.DeserializeObject<List<Datos.Cliente>>(content);
            _postCliente = new ObservableCollection<Datos.Cliente>(posts);
            listCliente.ItemsSource = _postCliente;
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
            idHotel = _post[0].idHotel;
            idhabitacion = _post[0].idHabitacion;
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
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void listCliente_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
        }
        public async void Reservar()
        {
            string codigoReserva = txtCodigo.Text;
            int idCliente = ((Datos.Cliente)listCliente.SelectedItem).idCliente;
            int idUsuario = ((Datos.Cliente)listCliente.SelectedItem).idUsuario;
            int numdiasReserva = Convert.ToInt32(txtDias.Text);
            string horaIngreso = txtHoraIngreso.Text;
            string horaSalida = txtHoraSalida.Text;
            DateTime fechaIngreso = DateTime.Now;
            DateTime fechaSalida = fechaIngreso.AddDays(numdiasReserva);
            double total = Convert.ToDouble(txtTotal.Text);
            string resultado = reserva.nuevaReserva(codigoReserva,
                                                    idCliente,
                                                    idHotel,
                                                    idhabitacion,
                                                    numdiasReserva,
                                                    horaIngreso,
                                                    horaSalida,
                                                    fechaIngreso,
                                                    fechaSalida,
                                                    total);
            Service servicio = new Service();
            string urlUser = servicio.urlGetUsuarioId().ToString() + idUsuario;
            var content = await client.GetStringAsync(urlUser);
            if (content.Contains("[") && content.Contains("]"))
            {

            }
            else
            {
                content = "[" + content + "]";
            }

            List<Datos.Usuario> posts = JsonConvert.DeserializeObject<List<Datos.Usuario>>(content);
            _postUser = new ObservableCollection<Datos.Usuario>(posts);
            string to = _postUser[0].correoUsuario;


            //nombre hotel
            string urlHotel = servicio.urlHotelId().ToString()+idHotel;
            var contentH = await client.GetStringAsync(urlHotel);

            if (contentH.Contains("[") && contentH.Contains("]"))
            {

            }
            else
            {
                contentH = "[" + contentH + "]";
            }

            List<Datos.Hotel> postsHotel = JsonConvert.DeserializeObject<List<Datos.Hotel>>(contentH);
            _posthotel = new ObservableCollection<Datos.Hotel>(postsHotel);
            string nombreHotel = _posthotel[0].nombreHotel;





            //correo html
            string urlhtml = servicio.urlGetHtml().ToString();
            var content1 = await client.GetStringAsync(urlhtml);
            List<Datos.htmlCorreo> postsHtml = JsonConvert.DeserializeObject<List<Datos.htmlCorreo>>(content1);
            _postHtml = new ObservableCollection<Datos.htmlCorreo>(postsHtml);
            string correo = _postHtml[0].htmldesc;
            correo = correo.Replace("@@hotel@@", nombreHotel);
            correo = correo.Replace("@@habitacion@@", lblNombre.Text);
            correo = correo.Replace("@@tipo@@", lbltipo.Text);
            correo = correo.Replace("@@codigo@@", txtCodigo.Text);
            correo = correo.Replace("@@dia@@", txtDias.Text);
            correo = correo.Replace("@@total@@", "$"+txtTotal.Text);

            if (resultado == "Exito")
            {
                await DisplayAlert("Alerta", "Rsgistro correcto, se ha enviado un correo con los datos de su reserva", "Cerrar");
                await Navigation.PushAsync(new Principal());

                CN_Mail mail = new CN_Mail();
                mail.enviarcorreo(to, correo);

            }
            else
            {
                await DisplayAlert("Alerta", resultado, "Cerrar");
            }
        }


        void btnReservar_Clicked(System.Object sender, System.EventArgs e)
        {
            Reservar();
        }
    }
}

