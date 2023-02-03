using System;
using System.Net;
using System.Net.Mail;

namespace HotelReservaciones.Controlador
{
	public class CN_Mail
	{
        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        public bool enviarcorreo(string to, string mensaje)
        {
            try
            {

                string from = " ";
                string pass = "";
                m.From = new MailAddress(from);
                m.To.Add(new MailAddress(to));

                m.Body = mensaje;
                m.IsBodyHtml = true;
                m.Subject = "Reserva Realizada con exito";
                smtp.Host = "SMTP.Office365.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.EnableSsl = true;


                smtp.Send(m);
               
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
                throw;
            }

        }
    }
}

