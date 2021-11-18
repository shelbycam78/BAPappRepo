using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Event
    {
        public Guid OwnerId { get; set; }

        [Key]
   
        [Display(Name = "Invoice Number")]
        public string EventId { get; set; }
        
       
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        [Required]
        [ForeignKey(nameof(Venue))]
        [Display(Name = "Venue")]
        public string VenueId { get; set; }

        [Required]
        [ForeignKey(nameof(Crewer))]
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


        public virtual Venue Venue { get; set; }
        public virtual Crewer Crewer { get; set; }

        //public Category EventType { get; set; }


    }
}
