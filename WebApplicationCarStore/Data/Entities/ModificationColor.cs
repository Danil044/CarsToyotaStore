using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Data.Entities
{
    public class ModificationColor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Slug { get; set; }

        public Modification Modification { get; set; }

        public Guid ModificationId { get; set; }

        public Color Color { get; set;}

        public Guid ColorId { get; set; }

        public string ImgUrl { get; set; }

        public List<ModificationColor> ModificationColors { get; set; }
    }
}
