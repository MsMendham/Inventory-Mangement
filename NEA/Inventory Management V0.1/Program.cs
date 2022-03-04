using System;

namespace Inventory_Management_V0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("=====Menu=====");
                Console.WriteLine("1:Add Item");
                Console.WriteLine("2:Edit Item");
                Console.WriteLine("3:Delete Item");
                Console.WriteLine("4:View Inventory");
                Console.WriteLine("X:Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        Menus.view();
                        break;
                    case "X":
                        run = false;
                        break;
                }

            }
        }
    }
}
