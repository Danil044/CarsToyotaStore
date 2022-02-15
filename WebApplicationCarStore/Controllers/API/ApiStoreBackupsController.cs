using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Helpers.DataBase.DumpBackups;


namespace WebApplicationCarStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiStoreBackupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DumpDatabase dumpDatabase;

        public ApiStoreBackupsController(ApplicationDbContext context)
        {
            _context = context;
            dumpDatabase = new DumpDatabase(_context);
            dumpDatabase.OnBackupCreated += (String message) => Helpers.Notification.Mail.SendEmailAsync(message, "backup database", "makstyulyukov@gmail.com");
        }

        [HttpGet]
        public ActionResult<String> CreateBackup()
        {
            String backupPath = dumpDatabase.Create();
            backupPath = backupPath.Replace(DumpBackup.Path, "");

            return backupPath;
        }

        [HttpGet("{backupName}")]
        public ActionResult RestoreBackup(String backupName)
        {
            if (!dumpDatabase.Restore(DumpBackup.Path + backupName))
                return BadRequest();

            return CreatedAtAction("RestoreBackup", backupName);
        }
    }
}
