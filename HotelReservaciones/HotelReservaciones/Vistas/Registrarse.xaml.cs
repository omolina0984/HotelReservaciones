using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HotelReservaciones.Vistas
{
    public partial class Registrarse : ContentPage
    {
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
        }

        void btnRegistroGoogle_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

