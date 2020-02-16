using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
