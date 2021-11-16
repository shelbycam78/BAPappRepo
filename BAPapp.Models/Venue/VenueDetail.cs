using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class VenueDetail
    {
        public string VenueId { get; set; }

        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        [Display(Name = "Address")]
        public string VenueLocation { get; set; }
        
        [Display(Name = "Crewer")]
        public string CrewerId { get; set; }
        
        [Display(Name = "Point of Contact")]
        public string PointOfContact { get; set; }
    }
}
