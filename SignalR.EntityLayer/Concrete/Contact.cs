using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Contact:BaseEntity
    {
        public string? Location { get; set; }

        public string? Phone { get; set; }

        public string? EMail { get; set; }

        public string? FooterTitle { get; set; } 

        public string? FooterDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }
    }
}
