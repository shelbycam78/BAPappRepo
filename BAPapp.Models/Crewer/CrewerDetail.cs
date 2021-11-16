using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class CrewerDetail
    {
        public string CrewerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Venue")]
        public string VenueId { get; set; }
  
        [Display(Name = "Event")]
        public string EventId { get; set; }
      


    }
}
