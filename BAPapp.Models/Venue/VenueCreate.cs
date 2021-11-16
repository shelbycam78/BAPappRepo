using BAPapp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class VenueCreate
    {
        [Key]
        [Required]
        public string VenueId { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string VenueLocation { get; set; }


        [ForeignKey(nameof(Crewer))]
        [Display(Name = "Crewer")]
        public string CrewerId { get; set; }
        public virtual Crewer Crewer { get; set; }

        [Display(Name = "Point of Contact")]
        public string PointOfContact { get; set; }
    }
}
