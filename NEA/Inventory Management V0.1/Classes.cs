using System;
using System.Collections.Generic;
using System.Text;
using System.IO;  // include the System.IO namespace
using System.Linq;

namespace Inventory_Management_V0._1
{
    class Menus
    {
        public static void view()
        {
            Console.WriteLine("=====Inventory=====");
            string text = File.ReadAllText("C:\\Users\\tkh\\OneDrive\\Documents\\Greenhead\\Computer Science\\NEA\\Inventory Management V0.1\\Inventroy.csv");
            string[] lines = text.Split("\r\n");
            List<string[]>AllSplit = new List<string[]>();
            foreach (string i in lines)
            {
                AllSplit.Add(i.Split(","));
            }
            Console.WriteLine("1:Alphabetical");
            Console.WriteLine("2:Price H-L");
            Console.WriteLine("3:Price L-H");
            Console.WriteLine("4:Stock H-L");
            Console.WriteLine("5:Stock L-H");
            Console.WriteLine("X:Back");
            string j = Console.ReadLine();
            List<string[]> newList = new List<string[]>();
            switch (j)
            {
                case "1":
                    newList = AllSplit.OrderBy(n => n[0]).ToList();
                    break;
                case "2":
                    newList = AllSplit.OrderBy(n => n[1]).ToList(); // doesnt sort by number needs fixing samew for all below :)
                    break;
                case "3":
                    newList = AllSplit.OrderBy(n => n[1]).ToList();
                    newList.Reverse();
                    break;
                case "4":
                    newList = AllSplit.OrderBy(n => n[2]).ToList();
                    break;
                case "5":
                    newList = AllSplit.OrderBy(n => n[2]).ToList();
                    newList.Reverse();
                    break;
                case "X":
                    break;
            }
            foreach(string[] arr in newList)
            {
                string temp = "";
                foreach(string item in arr)
                {
                    temp = temp + item + " ";
                }
                Console.WriteLine(temp);
            }

        }
    }

}
