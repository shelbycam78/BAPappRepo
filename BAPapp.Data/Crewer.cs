using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Crewer
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int CrewerId { get; set; }

        [Required]
        public string Name { get; set; }
     
        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Venue> Venues { get; set; }

        public List<Event> Events { get; set; }
    }
}
