using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Event
{
    public class EventListItem
    {

        [Display(Name = "Invoice Number")]
        public int EventId { get; set; }


        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }


        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }


        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }


        [Display(Name = "Venue")]
        public int VenueId { get; set; }


        //[Display(Name = "Company")]
        //public int ClientId { get; set; }


        





    }
}
