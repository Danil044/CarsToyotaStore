using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Controllers.Admin
{
    public class AdminFileController : Controller
    {
        /*
        Action<string> RemoveRootDir = (dir) =>
        {
            dir = dir.Replace(Helpers.Media.WebRootStoragePath, "");

        };
        */
        public IActionResult Index()
        {
            string curDir = "/";
            ViewBag.currentDir = curDir;

            string rootDirr = Helpers.Media.WebRootStoragePath;
            //string curDir = "/";
            string[] dirs = Directory.GetDirectories(rootDirr);

            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Replace(rootDirr, "");
            }

            ViewBag.Directories = dirs;
            ViewBag.Files = Directory.GetFiles(rootDirr);

            return View();
        }
    }
}
