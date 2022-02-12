using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Models;

namespace WebApplicationCarStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            //Будет работать при заходе на страницу
            //Helpers.Notification.Telegram.SendMessage($"Заявка от {callBack.Name}\nНомер телефона: {callBack.Phone}\n(30 секунд на ответ!)");
            //await Helpers.Notification.Mail.SendEmailAsync();
            var d = new Helpers.DataBase.Dump.Create();
            d.DumpColors(_context);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cars()
        {
            return View();
        }

        public IActionResult Auth()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
