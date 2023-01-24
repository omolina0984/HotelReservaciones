using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HotelReservaciones.Vistas
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Menu.RootPage());
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

