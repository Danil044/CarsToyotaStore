using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Data.Entities
{
    public class Model
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public List<Modification> Modifications { get; set; }
    }
}
