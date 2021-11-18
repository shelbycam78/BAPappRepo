using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public partial class Crewer
    {
        public Guid OwnerId { get; set; }

        [Key]
        public string CrewerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }


        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public Crewer()
        {
            Venues = new HashSet<Venue>();
            Events = new HashSet<Event>();
        }
    

        




    }
}
