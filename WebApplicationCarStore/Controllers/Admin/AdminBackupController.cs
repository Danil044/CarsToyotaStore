using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Helpers.DataBase.DumpBackups;

namespace WebApplicationCarStore.Controllers.Admin
{
    public class AdminBackupController : Controller
    {

        private readonly ApplicationDbContext _context;
        public readonly DumpDatabase dumpDatabase;

        public AdminBackupController(ApplicationDbContext context)
        {
            _context = context;
            dumpDatabase = new DumpDatabase(_context);
            dumpDatabase.OnBackupCreated += (string message) => Helpers.Notification.Mail.SendEmailAsync(message, "backup database", "daniali230410@gmail.com");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
