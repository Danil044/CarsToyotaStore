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
    public class ApiBackupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiBackupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var files = Directory.GetFiles(DumpBackup.Path);
            List<String> dumps = new();

            foreach (var file in files)
                if (file.EndsWith(".json"))
                    dumps.Add(file.Replace(DumpBackup.Path, ""));

            return dumps;
        }
    }
}
