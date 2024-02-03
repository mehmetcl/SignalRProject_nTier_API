﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Order
    {
        public int Id { get; set; }

        public string TableNumber { get; set; }

        public string Description { get; set; }

        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public bool Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        
    }
}
