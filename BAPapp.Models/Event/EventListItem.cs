using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Event
{
    public class EventListItem
    {
        public DateTime EventDate { get; set; }
         
        public string EventTitle { get; set; }
        public int VenueId { get; set; }

        public virtual Data.Crewer Crewer { get; set; }

    }
}
