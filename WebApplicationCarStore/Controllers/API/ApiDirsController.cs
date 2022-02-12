using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDirsController : ControllerBase
    {
        [HttpGet("{path}")]
        public async Task<ActionResult<string[]>> GetFiles(string? path)
        {
            path = path.Replace('~', '\\');
            string rootDirr = Helpers.Media.WebRootStoragePath;
            string[] files = Directory.GetFiles(rootDirr + path);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(Helpers.Media.WebRootStoragePath, "");
            }

            return files;
        }
    }
}
