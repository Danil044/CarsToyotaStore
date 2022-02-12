using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Helpers.Notification
{
    public class Telegram
    {
        public static string apiTelegram = "5087021463:AAFzDrwzm4xpXSVArfbVBZcWbVH59pUyHSk";
        public static string chatId_my = "580223379";
        public static string chatId_group = "-1001277396998";

        public static bool SendMessage(string msg)
        {
            string uri = "https://api.telegram.org/bot"
                + apiTelegram +
                "/sendMessage?chat_id=" + chatId_my
                + "&text=" + msg;

            var request = WebRequest.Create(uri);
            request.Method = "GET";

            var response = request.GetResponse();
     
            return true;
        }

    }
}
