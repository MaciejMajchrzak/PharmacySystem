using DryIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemConsole.Menus
{
    public class PointOfSaleMenu
    {
        Container _container;

        public PointOfSaleMenu(Container container)
        {
            _container = container;

            Loop();
        }

        public void Loop()
        {
            while(true)
            {
                string command = EnterCommand("pos");

                if(command == "new transaction")
                {
                    new TransactionMenu(_container);
                }
                
                if(command == "exit")
                {
                    Console.WriteLine("Are you sure to log out? (y/n)[n]:");

                    if (EnterCommand("exit") == "y") { new MainMenu(_container); }
                }
            }
        }

        public string EnterCommand(string tag)
        {
            Console.Write($"{tag}>");

            string command = Console.ReadLine();

            string[] commandSplit = command.Split(' ');

            command = "";

            foreach (var item in commandSplit)
            {
                if (string.IsNullOrWhiteSpace(item) == false)
                {
                    if (item != commandSplit[^1])
                    {
                        command += $"{item} ";
                    }

                    if (item == commandSplit[^1])
                    {
                        command += $"{item}";
                    }
                }
            }

            command = command.Trim(' ');

            return command;
        }
    }
}
