using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Venue
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int VenueId { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueName { get; set; }


        [Required]
        [Display(Name = "Location")]
        public string VenueLocation { get; set; }

        
        //public List<Client> Clients { get; set; }

        //public List<Event> Events { get; set; }
    }
}
