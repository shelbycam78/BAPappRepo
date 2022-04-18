using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Client
{
    public class ClientDetail
    {
        
        public int ClientId { get; set; }

        public string Company { get; set; }

        public string Contact { get; set; }

        //public virtual List<Data.Event> Events { get; set; }
    }
}
