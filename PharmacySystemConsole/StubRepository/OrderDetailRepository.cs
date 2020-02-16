using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemConsole.StubRepository
{
    public class OrderDetailRepository : IOrderDetail
    {
        public OrderDetail Add(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
