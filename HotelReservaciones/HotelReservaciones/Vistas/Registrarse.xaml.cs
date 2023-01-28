using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HotelReservaciones.Controlador;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace HotelReservaciones.Vistas
{
    public partial class Registrarse : ContentPage
    {
        UsuarioControlador usuario = new UsuarioControlador();
        private readonly HttpClient client = new HttpClient();
        //private ObservableCollection<Datos.Usuario> _post;
        //private ObservableCollection<Datos.TipoUsuario> _posttipo;

        public Registrarse()
        {
            InitializeComponent();
        }

        void btnIniciar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        void btnRegistro_Clicked(System.Object sender, System.EventArgs e)
        {
            if (txtContraseña.Text == txtConfirmar.Text)
            {
                //int idTipoUsuario = ((Datos.TipoUsuario)listhotel.SelectedItem).idHotel;
                string resultado = usuario.nuevoUsuario(txtNombres.Text,
                                                              txtApellidos.Text,
                                                              txtEmail.Text,
                                                              txtUsuario.Text,
                                                              txtContraseña.Text
                                                               );
                if (resultado == "Exito")
                {
                    DisplayAlert("Alerta", "Registro correcto", "Cerrar");
                    Navigation.PushAsync(new Login());
                }
                else
                {
                    DisplayAlert("Alerta", resultado, "Cerrar");
                }
            }
            else
            {
                DisplayAlert("Alerta", "Contraseñas no Coinciden", "Cerrar");
                Navigation.PushAsync(new Registrarse());
            }
        }

        void btnRegistroGoogle_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

