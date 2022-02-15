using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;

namespace WebApplicationCarStore.Helpers.DataBase.DumpBackups
{
    public abstract class DumpBackup
    {
        public static readonly String Path = Media.WebRootStoragePath + "\\dumps\\";
        protected ApplicationDbContext context;

        public DumpBackup(ApplicationDbContext _context)
        {
            context = _context;
        }

        public abstract String Create();
        public abstract bool Restore(String filePath);

    }
}
