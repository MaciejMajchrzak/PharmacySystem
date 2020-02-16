using DryIoc;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Menus;
using PharmacySystemConsole.Repository;

namespace PharmacySystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<IMedicine, MedicineRepository>();
            container.Register<IOrder, OrderRepository>();
            container.Register<IOrderDetail, OrderDetailRepository>();
            container.Register<IPrescription, PrescriptionRepository>();

            new MainMenu(container);
        }
    }
}
