using PharmacySystemConsole.Context;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystemConsole.Repository
{
    public class OrderDetailRepository : IOrderDetail
    {
        readonly EFCContext _eFCContext = new EFCContext();

        public OrderDetail Add(OrderDetail orderDetail)
        {
            try
            {
                _eFCContext.OrderDetails.Add(orderDetail);

                _eFCContext.SaveChanges();

                return orderDetail;
            }
            catch (Exception ex)
            {
                return orderDetail;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var obj = GetById(id);

                _eFCContext.OrderDetails.Remove(obj);

                _eFCContext.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public List<OrderDetail> GetAll()
        {
            return _eFCContext.OrderDetails.ToList();
        }

        public OrderDetail GetById(int id)
        {
            return _eFCContext.OrderDetails.FirstOrDefault(p => p.Id == id);
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            try
            {
                var obj = GetById(orderDetail.Id);

                obj.MedicinePrice = orderDetail.MedicinePrice;

                obj.MedicineQuantity = orderDetail.MedicineQuantity;
                
                obj.Medicine = orderDetail.Medicine;

                obj.Order = orderDetail.Order;

                _eFCContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _eFCContext.SaveChanges();

                return orderDetail;
            }
            catch (Exception ex)
            {
                return orderDetail;
            }

        }
    }
}
