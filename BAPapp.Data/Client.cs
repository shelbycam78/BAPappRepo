using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Client
    {

        public Guid OwnerId { get; set; }
        
        [Key]
        [Required]
        public int ClientId { get; set; }

        [Required]
        public string Company { get; set; }

        public string Contact { get; set; }

        //public List<Venue> Venues { get; set; }

        //public List<Event> Events { get; set; }
    }
}
