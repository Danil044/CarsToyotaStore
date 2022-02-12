using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Helpers.Notification
{
    public class Mail
    {
        public static string ukrNet_pswd = "nsXybdfCGGHGvsAv";

        public static async Task SendEmailAsync(
            string email = "daniali230410@gmail.com",
            string subject = "test",
            string message = "<div style='font-family: Arial; '>"
                    + "<hr style = 'height: 40px; background-color: orange;' >"
                    + "<h1 style = 'font-size: 62px; text-align: center;' > Toyota </ h1 >"
                    + "<div>"
                    + "<p style = 'font-size: 34px; margin-left: 25px; margin-top: 8rem;' >"
                      + "Мы работаем над тем, что бы связаться с вами!"
                    + "</p>"
                    + "<div style = 'color: white; margin-top: 8rem; font-size: 22px; text-align: center; background-color: rgb(0, 0, 0, 0.5); padding-top: 10px;padding-bottom: 10px;' >"
                    + "<h2> ИНФОРМАЦТИЯ НЕ ЯВЛЯЕТЬСЯ СПАМОМ </h2>"
                    + "<p style = 'font-size: 14px; text-align: center;' > ВАМИ БЫЛО НАДАНО РАЗРЕШНИЕ ОТПРАВКИ ДЛЯ СВЯЗИ</ p >"
                    + "</div>"
                    + "</div>"
                    + "<hr style = 'height: 40px; background-color: orange;' >"
                    + "</div>")
        {
            var emailMessage = new MimeMessage();

            CallBack call = new CallBack();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "danilblago@ukr.net"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message//"Заявка от: " + $"{call.Name}" + "<br>" + "Номер телефона: " + $"{call.Phone}" + "<br>(30 секунд на ответ!)"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.ukr.net", 2525, true);
                await client.AuthenticateAsync("danilblago@ukr.net", ukrNet_pswd);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
