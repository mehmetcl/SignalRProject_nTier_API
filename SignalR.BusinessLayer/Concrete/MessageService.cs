﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MessageService : GenericService<Message>, IMessageService
    {
        public MessageService(IGenericDal<Message> genericDal, IUnitOfWork unitOfWork) : base(genericDal, unitOfWork)
        {
        }
    }
}
