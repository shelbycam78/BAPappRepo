using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Event
{
    public class EventDetail
    {
       
        public DateTime EventDate { get; set; }

        public string EventTitle { get; set; }

        public int VenueId { get; set; }

        public virtual Data.Crewer Crewer { get; set; }

        public string Position { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        public bool IsPaid { get; set; }

        public bool IsTaxed { get; set; }

        public bool IsDirectDeposit { get; set; }
    }
}
