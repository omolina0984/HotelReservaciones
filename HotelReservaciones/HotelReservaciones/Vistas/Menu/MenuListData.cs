using System;
using System.Collections.Generic;

namespace HotelReservaciones.Vistas.Menu
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Titulo = "Inicio",
                Icon = "casa.png",
                TargetType = typeof(Principal)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Clientes",
                Icon = "cliente.png",
                TargetType = typeof(Cliente)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Hoteles",
                Icon = "hotel.png",
                TargetType = typeof(Hotel)
            });

            this.Add(new MenuItem()
            {
                Titulo = "Habitaciones",
                Icon = "cama.png",
                TargetType = typeof(Habitacion)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Reservas",
                Icon = "reserva.png",
                TargetType = typeof(Reserva)
            });
        }
    }
}

