using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HotelReservaciones.Vistas.Menu
{
	public class RootPage : MasterDetailPage
	{
        MenuPage menuPage;
      
        public RootPage()
        {
            menuPage = new MenuPage();

            menuPage.Menu.ItemSelected +=
                (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
            Master = menuPage;

            Detail = new NavigationPage(new Principal());

            MasterBehavior = MasterBehavior.Popover;
        }

        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = null;

            switch (menu.TargetType.Name)
            {
                case "Inicio":
                case "Clientes":
                case "Hoteles":
                case "Habitaciones":
                case "Reservas":
                default:
                    displayPage = (Page)Activator.CreateInstance(menu.TargetType);
                    break;
            };

            try
            {
                Detail = new NavigationPage(displayPage);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("ERRO", "Erro " + ex.Message, "OK");
            }

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}

