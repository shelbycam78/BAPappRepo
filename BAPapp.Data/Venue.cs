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
        [Required]
        public string VenueId { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueName { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string VenueLocation { get; set; }


        public ICollection<Crewer> Crewers { get; set; }

        public ICollection<Event> Events { get; set; }


        [Display(Name = "Point of Contact")]
        public string PointOfContact { get; set; }
    }
}
