﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EFOrderDetailDal(SignalRContext context) : base(context)
        {
        }
    }
}