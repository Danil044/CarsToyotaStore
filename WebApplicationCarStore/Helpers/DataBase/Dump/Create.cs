using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Helpers.DataBase.Dump
{
    public class Create //Преобраззование xml в поля таблицы БД на 39минуте 
    {

        public string DumpDatabase(ApplicationDbContext db)
        {
            List<Modification> allDB = new List<Modification>();
            allDB = db.Modifications.Include(mod => mod.Model).ToList();

            string fileName = Guid.NewGuid() + ".xml";

            string fileServerPath;

            fileServerPath = Media.WebRootStoragePath + "dumps/";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Modification>));

            using (FileStream fs = new FileStream(fileServerPath + fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, allDB);
            }

            string msg = "https://localhost:44343/storage/dumps/" +
                 fileName + "' target='_top'> Download </a>";

            Helpers.Notification.Mail.SendEmailAsync(
                "daniali230410@gmail.com",
                "backUp Database",
                msg
                );

            return fileName;
        }

        public  string DumpColors(ApplicationDbContext db)
        {
            /*
            List<Modification> allDB = new List<Modification>();
            allDB = db.Modifications
                .Include(mod => mod.Model)
                .Include(mod => mod.ModificationColors)
                .ThenInclude(modc => modc.Color)
                .ToList();
            */
            List<Color> tblColors = db.Colors.ToList();

            string fileName = Guid.NewGuid() + ".xml";

            string fileServerPath;
            //fileServerPath  = Helpers.Media.CreateDirectory("dumps"); //Вариант с датами
            fileServerPath = Media.WebRootStoragePath + "dumps/";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Color>));

            using (FileStream fs = new FileStream(fileServerPath + fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tblColors);
            }

            string msg = "https://localhost:44343/storage/dumps/" +
                fileName + "' target='_top'> Download </a>";

            Helpers.Notification.Mail.SendEmailAsync(
                "daniali230410@gmail.com",
                "backUp Colors",
                msg
                );

                return fileName;
        }
    }
}
