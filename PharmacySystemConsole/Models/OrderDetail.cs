namespace PharmacySystemConsole.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public decimal MedicinePrice { get; set; }
        public int MedicineQuantity { get; set; }

        public Medicine Medicine { get; set; }
        public Order Order { get; set; }
    }
}
