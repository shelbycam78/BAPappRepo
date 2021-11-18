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
        public int EventId { get; set; }
        
       
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

           
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

        [ForeignKey(nameof(VenueId))]
        public int VenueId { get; set; }
        public virtual List<Venue> Venues { get; set; }

        [ForeignKey(nameof(CrewerId))]
        public int CrewerId { get; set; }
        public virtual Crewer Crewer { get; set; }

        //public Category EventType { get; set; }


    }
}
