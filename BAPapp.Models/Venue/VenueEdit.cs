using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Venue
{
    public class VenueEdit
    {
        public Guid OwnerId { get; set; }

  
        public string VenueId { get; set; }

        public string VenueName { get; set; }


        public string VenueLocation { get; set; }

        public string PointOfContact { get; set; }
    }
}
