using System.Collections.Generic;

namespace PharmacySystemConsole.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool WithPrescription { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
