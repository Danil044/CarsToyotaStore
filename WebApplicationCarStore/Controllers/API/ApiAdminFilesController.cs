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
    public class ApiAdminFilesController : ControllerBase
    {

        [HttpGet("{path}")]
        public async Task<ActionResult<string[]>> GetDirs(string? path)
        {
            path = path.Replace('~', '\\');
            string rootDir = Helpers.Media.WebRootStoragePath;
            string[] dirs = Directory.GetDirectories(rootDir + path);

            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Replace(Helpers.Media.WebRootStoragePath, "");
            }

            return dirs;
        }

    }
}
