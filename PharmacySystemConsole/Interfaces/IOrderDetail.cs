using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemConsole.Interfaces
{
    public interface IOrderDetail
    {
        public List<OrderDetail> GetAll();
        public OrderDetail GetById(int id);
        public OrderDetail Add(OrderDetail orderDetail);
        public OrderDetail Update(OrderDetail orderDetail);
        public void Delete(int id);
    }
}
