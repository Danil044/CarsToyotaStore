using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Helpers.DataBase.DumpBackups
{
    public class ColorDump : DumpBackup
    {
        public ColorDump(ApplicationDbContext context) : base(context) { }

        public override String Create()
        {
            XmlSerializer formatter = new(typeof(List<Color>));

            String fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}backupColors.xml";

            using (FileStream fs = new FileStream(Path + fileName, FileMode.OpenOrCreate))
                formatter.Serialize(fs, context.Colors.ToList());

            String message = $"<a href='https://localhost:44343/storage/dumps/{fileName}' target='_top'>Download</a>";

            Helpers.Notification.Mail.SendEmailAsync(message, "backup colors", "daniali230410@gmail.com");

            return Path + fileName;
        }

        public override bool Restore(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Color>));
            List<Color> backup;

            using (Stream reader = new FileStream(filePath, FileMode.Open))
                backup = (List<Color>)serializer.Deserialize(reader);

            return true;
        }
    }
}
