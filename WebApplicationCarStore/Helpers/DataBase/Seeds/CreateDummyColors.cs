using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Helpers.DataBase.Seeds
{
    public class CreateDummyColors
    {
        public void Creat(ApplicationDbContext db)
        {
            Color c = new Color();
            //...
            db.Colors.Add(c);
            db.SaveChanges();
        }
    }
}
