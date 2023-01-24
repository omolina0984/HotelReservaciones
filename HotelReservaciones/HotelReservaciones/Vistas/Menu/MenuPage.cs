using System;
using Xamarin.Forms;

namespace HotelReservaciones.Vistas.Menu
{
	public class MenuPage : ContentPage
	{
        public ListView Menu { get; set; }

        public MenuPage()
        {
            Title = "Menu";
            BackgroundColor = Color.FromHex("000000");

            Menu = new MenuListView();

            var layout = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 10
            };

            layout.Children.Add(Menu);

            Content = layout;
        }
    }
}

