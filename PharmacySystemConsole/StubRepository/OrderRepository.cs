using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.StubRepository
{
    public class OrderRepository : IOrder
    {
        public Order Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
