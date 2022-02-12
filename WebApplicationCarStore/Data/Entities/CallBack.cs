using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Data.Entities
{
    public class CallBack
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        [NotMapped]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
