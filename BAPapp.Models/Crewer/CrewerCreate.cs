using BAPapp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class CrewerCreate
    {
        [Key]
        [Required]
        public string CrewerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }


        [ForeignKey(nameof(Venue))]
        [Display(Name = "Venue")]
        public string VenueId { get; set; }
        public virtual Venue Venue { get; set; }


        [ForeignKey(nameof(Event))]
        [Display(Name = "Event")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
