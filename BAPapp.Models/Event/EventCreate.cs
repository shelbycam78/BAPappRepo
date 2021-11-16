using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class EventCreate
    {
        [Required]
        [Display(Name = "Invoice Number")]
        public string EventId { get; set; }


        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueId { get; set; }

        [Required]
        [Display(Name = "Crewer")]
        public string CrewerId { get; set; }

        public string Position { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        [Required]
        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }
    }
}
