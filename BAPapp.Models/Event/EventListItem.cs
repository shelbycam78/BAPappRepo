using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class EventListItem
    {
        public string EventId { get; set; }
        public DateTime EventDate { get; set; }
         
        public string EventTitle { get; set; }
        
    }
}
