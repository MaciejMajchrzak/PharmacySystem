using Microsoft.EntityFrameworkCore;
using PharmacySystemConsole.Models;

namespace PharmacySystemConsole.Context
{
    public class EFCContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=PharmacySystem;Integrated Security=True";

            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
