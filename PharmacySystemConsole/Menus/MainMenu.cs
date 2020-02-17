using DryIoc;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.Menus
{
    public class MainMenu: Menu
    {
        Container _container;

        IMedicine _medicine;

        public MainMenu(Container container)
        {
            _container = container;

            _medicine = container.Resolve<IMedicine>();

            Loop();
        }

        public void Loop()
        {
            while (true)
            {
                string command = EnterCommand("main");
                string[] commandSplit = command.Split(' ');

                ///<summary>
                ///Adding medicine by entering the command:
                ///add medicine 'Name' 'Manufacturer' 'Price' 'Amount' 'WithPrescription'
                /// </summary>
                if(commandSplit.Length == 7)
                {
                    if (commandSplit[0] == "add"
                       && commandSplit[1] == "medicine"
                       && decimal.TryParse(commandSplit[4], out decimal price) == true
                       && int.TryParse(commandSplit[5], out int amount) == true
                       && bool.TryParse(commandSplit[6], out bool withPrescription) == true)
                    {
                        Medicine medicine = new Medicine()
                        {
                            Name = commandSplit[2],
                            Manufacturer = commandSplit[3],
                            Price = price,
                            Amount = amount,
                            WithPrescription = withPrescription
                        };

                        _medicine.Add(medicine);
                    }
                }

                ///<summary>
                ///Updating medicine by entering the command:
                ///update medicine 'Id' name 'Name' or
                ///update medicine 'Id' manufacturer 'Manufacturer' or
                ///update medicine 'Id' price 'Price' or
                ///update medicine 'Id' amount 'Amount' or
                ///update medicine 'Id' withprescription 'WithPrescription'
                /// </summary>
                if (commandSplit.Length == 5)
                {
                    if(commandSplit[0] == "update"
                       && commandSplit[1] == "medicine"
                       && int.TryParse(commandSplit[2], out int medicineId) == true)
                    {
                        Medicine medicine = _medicine.GetById(medicineId);

                        if(commandSplit[3] == "name")
                        {
                            medicine.Name = commandSplit[4];

                            _medicine.Update(medicine);
                        }
                        if(commandSplit[3] == "manufacturer")
                        {
                            medicine.Manufacturer = commandSplit[4];

                            _medicine.Update(medicine);
                        }
                        if(commandSplit[3] == "price"
                           && decimal.TryParse(commandSplit[4], out decimal price) == true)
                        {
                            medicine.Price = price;

                            _medicine.Update(medicine);
                        }
                        if(commandSplit[3] == "amount"
                           && int.TryParse(commandSplit[4], out int amount) == true)
                        {
                            medicine.Amount = amount;

                            _medicine.Update(medicine);
                        }
                        if(commandSplit[3] == "withprescription"
                           && bool.TryParse(commandSplit[4], out bool withPrescription) == true)
                        {
                            medicine.WithPrescription = withPrescription;

                            _medicine.Update(medicine);
                        }
                    }
                }

                ///<summary>
                ///Deleting a medicine by entering the command:
                ///delete medicine 'Id'
                /// </summary>
                if (commandSplit.Length == 3)
                {
                    if(commandSplit[0] == "delete"
                       && commandSplit[1] == "medicine"
                       && int.TryParse(commandSplit[2], out int medicineId) == true)
                    {
                        _medicine.Delete(medicineId);
                    }
                }

                if(command == "show medicines")
                { 
                    ShowMedicines(_medicine.GetAll());
                }

                ///<summary>
                ///Going to point of sale menu
                /// </summary>
                if(command == "pos")
                {
                    new PointOfSaleMenu(_container);
                }

                if (command == "exit")
                {
                    Console.WriteLine("Are you sure to log out? (y/n)[n]:");

                    if (EnterCommand("exit") == "y") { Environment.Exit(1); }
                }
            }
        }

        public void ShowMedicines(List<Medicine> medicines)
        {
            Console.WriteLine("   Id Name                 Manufacturer              Price     Amount WithPrescription");
            Console.WriteLine("===== ==================== ==================== ========== ========== ====================");
            
            foreach(var medicine in medicines)
            {
                Console.WriteLine($"{medicine.Id.ToString().PadLeft(5)}" +
                                  $" {medicine.Name.PadRight(20)}" +
                                  $" {medicine.Manufacturer.PadRight(20)}" +
                                  $" {medicine.Price.ToString().PadLeft(10)}" +
                                  $" {medicine.Amount.ToString().PadLeft(10)}" +
                                  $" {medicine.WithPrescription.ToString().PadLeft(20)}");
            }
        }
    }
}
