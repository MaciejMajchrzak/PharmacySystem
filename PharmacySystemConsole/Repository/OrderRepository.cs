using PharmacySystemConsole.Context;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystemConsole.Repository
{
    public class OrderRepository : IOrder
    {
        readonly EFCContext _eFCContext = new EFCContext();

        public Order Add(Order order)
        {
            try
            {
                _eFCContext.Orders.Add(order);

                _eFCContext.SaveChanges();

                return order;
            }
            catch (Exception ex)
            {
                return order;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var obj = GetById(id);

                _eFCContext.Orders.Remove(obj);

                _eFCContext.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public List<Order> GetAll()
        {
            return _eFCContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _eFCContext.Orders.FirstOrDefault(p => p.Id == id);
        }

        public Order Update(Order order)
        {
            try
            {
                var obj = GetById(order.Id);

                obj.TransactionDate = order.TransactionDate;

                obj.OrderDetails = order.OrderDetails;

                obj.Prescriptions = order.Prescriptions;

                _eFCContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _eFCContext.SaveChanges();

                return order;
            }
            catch (Exception ex)
            {
                return order;
            }
        }
    }
}
