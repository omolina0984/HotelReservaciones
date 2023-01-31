using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using HotelReservaciones.Controlador;
using Newtonsoft.Json;

namespace HotelReservaciones.Vistas
{
    public partial class Login : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos.Usuario> _post;

        public Login()
        {
            InitializeComponent();
        }


        public async void login(string usuario, string contrasena)
        {
            Service servicio = new Service();

            string url = servicio.urlLogin().ToString()+usuario+ "&contrasenaUsuario="+contrasena;
            var content = await client.GetStringAsync(url);
            if (content != "[]")
            {
                if (content.Contains("[") && content.Contains("]"))
                {

                }
                else
                {
                    content = "[" + content + "]";
                }


                List<Datos.Usuario> posts = JsonConvert.DeserializeObject<List<Datos.Usuario>>(content);
                _post = new ObservableCollection<Datos.Usuario>(posts);
                string user = _post[0].usuario.ToString();
                string pass = _post[0].contrasenaUsuario.ToString();

                if (user == usuario && pass == contrasena)
                {
                    await Navigation.PushAsync(new Menu.RootPage());
                }
                else
                {
                    await DisplayAlert("Alerta", "Usuario o contraseña incorrectos, vuelva a intentarlo", "Cerrar");
                }

            }
            else
            {
                await DisplayAlert("Alerta", "Usuario o contraseña incorrectos, vuelva a intentarlo", "Cerrar");
            }
        
        }

        void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            login(txtEmail.Text, txtPassword.Text);
        }

        void btnRegistrarse_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registrarse());
        }

        void btnIngresoGoogle_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

