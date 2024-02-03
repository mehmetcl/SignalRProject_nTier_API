using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Booking:BaseEntity
    {
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Mail { get; set; }

        public int? PersonCount { get; set; }
    }
}
