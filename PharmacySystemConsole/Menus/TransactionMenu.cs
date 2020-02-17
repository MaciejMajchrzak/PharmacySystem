using DryIoc;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.Menus
{
    public class TransactionMenu: Menu
    {
        readonly Container _container;

        readonly IMedicine _medicine;
        readonly IOrder _order;
        readonly IOrderDetail _orderDetail;
        readonly IPrescription _prescription;

        public List<OrderDetail> OrderDetails = new List<OrderDetail>();
        
        public TransactionMenu(Container container)
        {
            _container = container;
            
            _medicine = container.Resolve<IMedicine>();
            _order = container.Resolve<IOrder>();
            _orderDetail = container.Resolve<IOrderDetail>();
            _prescription = container.Resolve<IPrescription>();

            Loop();
        }
        
        public void Loop()
        {

            while(true)
            {
                string command = EnterCommand("transaction");
                string[] commandSplit = command.Split(' ');

                if(command == "show order details")
                {
                    ShowOrderDetails(OrderDetails);
                }

                ///<summary>
                ///Adding medicine to order by entering the command:
                ///add medicine 'Id' quantity 'Quantity'
                /// </summary>
                if (commandSplit.Length == 5)
                {
                    if(commandSplit[0] == "add" 
                        && commandSplit[1] == "medicine" 
                        && int.TryParse(commandSplit[2], out int medicineId) == true 
                        && commandSplit[3] == "quantity"
                        && int.TryParse(commandSplit[4], out int quantity) == true)
                    {
                        Medicine medicine = _medicine.GetById(medicineId);

                        if(medicine != null)
                        {
                            if(quantity < medicine.Amount)
                            {
                                OrderDetail orderDetail = new OrderDetail()
                                {

                                    MedicinePrice = medicine.Price,
                                    MedicineQuantity = quantity,
                                    Medicine = medicine
                                };

                                OrderDetails.Add(orderDetail);

                                ShowMessage("OK", true);
                            }
                            else
                            {
                                ShowMessage("Not enough product", false);
                            }
                        }
                        else
                        {
                            ShowMessage("Does not exist", false);
                        }
                    }
                }

                if(command == "sell")
                {   
                    Order order = new Order()
                    {
                        TransactionDate = DateTime.UtcNow
                    };

                    order = _order.Add(order);

                    bool prescriptionWasAdd = false;

                    if (TransactionWithPrescription() == true)
                    {
                        do
                        {
                            command = EnterCommand("prescription");
                            commandSplit = command.Split(' ');

                            ///<summary>
                            ///Adding prescription to order by entering the command:
                            ///add prescription 'Number' 'Pesel' 'FirstName' 'LastName'
                            /// </summary>
                            if (commandSplit[0] == "add"
                               && commandSplit[1] == "prescription"
                               && commandSplit[3].Length == 11
                               && float.TryParse(commandSplit[3], out float pesel) == true)
                            {
                                Prescription prescription = new Prescription()
                                {
                                    Number = commandSplit[2],
                                    Pesel = commandSplit[3],
                                    FirstName = commandSplit[4],
                                    LastName = commandSplit[5],
                                    Order = order
                                };

                                _prescription.Add(prescription);

                                prescriptionWasAdd = true;
                            }
                        } while (prescriptionWasAdd == false);
                    }

                    foreach(var orderDetail in OrderDetails)
                    {
                        orderDetail.Order = order;

                        _orderDetail.Add(orderDetail);

                        Medicine medicine = _medicine.GetById(orderDetail.Medicine.Id);
                        medicine.Amount -= orderDetail.MedicineQuantity;
                        medicine = _medicine.Update(medicine);
                    }

                    new PointOfSaleMenu(_container);
                }

                ///<summary>
                ///Going back to point of sale menu
                /// </summary>
                if (command == "exit")
                {
                    Console.WriteLine("Are you sure to log out? (y/n)[n]:");

                    if (EnterCommand("exit") == "y") { new PointOfSaleMenu(_container); }
                }
            }
        }

        public void ShowOrderDetails(List<OrderDetail> OrderDetails)
        {
            decimal wholePrice = 0;
            Console.WriteLine("    # Name                        Quantity           Price");
            Console.WriteLine("===== ========================= ========== ===============");

            int count = 0;

            foreach (var orderDetail in OrderDetails)
            {
                count++;

                wholePrice += orderDetail.MedicinePrice * orderDetail.MedicineQuantity;

                Console.WriteLine($"{count.ToString().PadLeft(5)}" +
                                  $" {orderDetail.Medicine.Name.PadRight(25)}" +
                                  $" {orderDetail.MedicineQuantity.ToString().PadLeft(10)}" +
                                  $" {orderDetail.MedicinePrice.ToString().PadLeft(15)}");
            }

            Console.WriteLine("                                               Whole Price");
            Console.WriteLine("                                           ===============");
            Console.WriteLine($"{wholePrice.ToString().PadLeft(58)}");
        }

        /// <summary>
        /// Checks if the List<OrderDetails> contains prescription drugs
        /// </summary>
        /// <returns>True if at least one is on prescription</returns>
        public bool TransactionWithPrescription()
        {
            foreach(var orderDetail in OrderDetails)
            {
                if(orderDetail.Medicine.WithPrescription == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
