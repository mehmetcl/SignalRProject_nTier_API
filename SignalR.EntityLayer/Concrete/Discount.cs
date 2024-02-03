using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Discount : BaseEntity
    {
        public string? Title { get; set; }

        public string? Amount { get; set; }

        public string? Description { get; set; }

        public int? ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}
