using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models.Crewer
{
    public class CrewerDetail
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual List<Data.Event> Events { get; set; }

    }
}
