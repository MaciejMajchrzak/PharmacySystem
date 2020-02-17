using System;

namespace PharmacySystemConsole.Menus
{
    public abstract class Menu
    {
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
        public void ShowMessage(string message, bool check)
        {
            if (check == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{message}");

                Console.ResetColor();
            }

            if (check == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{message}");

                Console.ResetColor();
            }
        }
    }
}
