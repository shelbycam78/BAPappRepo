using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Event
{
    public class EventCreate
    { 

        public DateTime EventDate { get; set; }

        public string EventTitle { get; set; }

        public bool IsPaid { get; set; }

        public int VenueId { get; set; }

        //public int ClientId { get; set; }



    }
}
