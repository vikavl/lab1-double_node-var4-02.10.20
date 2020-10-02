using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myCollection;

namespace TestApp
{
    class Program
    {
        public static string[] menuItems = { "1 - Create Double Node structure", "2 - Add to the first", "3 - Add to the last", 
            "4 - Check availability of value", "5 - Delete first", "6 - Delete last", "7 - Clear current Double Node structure", "8 - Exit"};
        public static myQueue<string> test = new myCollection.myQueue<string>();
        public static int key;
        public static string current;
        static void Main(string[] args)
        {
            test.Notify += DisplayMessage;
            do
            {
                Console.WriteLine("MENU:");
                foreach (string str in menuItems)
                {
                    string item = str + ";";
                    Console.WriteLine(item);
                }
                Console.Write("Choose menu item: "); key = Convert.ToInt32(Console.ReadLine());
                Menu(key);
                current = "Double Node: ";
                foreach (object item in test)
                {
                    current += item + "\t";
                }
                Console.WriteLine(current);
                Console.ReadKey();
                Console.Clear();
            } while (key != 8);
        }

        static int Menu(int key)
        {
            switch (key)
            {
                case 1:
                    {
                        Console.Write("Enter value: ");
                        current = Console.ReadLine();
                        test.AddFirst(current);
                        break;
                    }
                case 2: 
                    {
                        Console.Write("Enter value: ");
                        current = Console.ReadLine();
                        test.AddFirst(current);
                        break; 
                    }
                case 3: 
                    {
                        Console.Write("Enter value:");
                        current = Console.ReadLine();
                        test.AddLast(current);
                        break; 
                    }
                case 4: 
                    {
                        Console.Write("Enter value:");
                        current = Console.ReadLine();
                        if (test.Contains(current)) Console.WriteLine("This node is present.");
                        else Console.WriteLine("This node is absent.");
                        break; 
                    }
                case 5: 
                    {
                        if(test.IsEmpty) Console.WriteLine("Double Node structure is empty.");
                        else test.RemoveFirst();
                        break; 
                    }
                case 6: 
                    {
                        if (test.IsEmpty) Console.WriteLine("Double Node structure is empty.");
                        else test.RemoveLast();
                        break; 
                    }
                case 7: 
                    {
                        test.Clear();
                        break; 
                    }
                default:
                    {
                        Console.WriteLine("Choose another menu item!");
                        break;
                    }
            }
            return key;
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
