using PharmacySystemConsole.Models;
using System.Collections.Generic;

namespace PharmacySystemConsole.Interfaces
{
    public interface IOrder
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public Order Add(Order order);
        public Order Update(Order order);
        public void Delete(int id);
    }
}
