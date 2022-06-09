using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Menu
    {
        public List<string> items = new List<string>();
        public string menuHeading { get; set; }
        public string lastOption { get; set; }

        public Menu(string menuHeading)
        {
            this.menuHeading = menuHeading;
            lastOption = "Exit";
        }

        public Menu(string menuHeading,string lastOption)
        {
            this.menuHeading = menuHeading;
            this.lastOption = lastOption;
        }

        public void addItem(string item)
        {
            items.Add(item);
        }

        public void displayMenu()
        {
            Console.WriteLine("\n"+menuHeading);
            int count = 1;
            foreach (string item in items)
            {
                Console.Write(count++ + ".");
                Console.WriteLine(item);
            }
            Console.WriteLine("{0}.{1}", count,lastOption);
        }

        public virtual int getReply()
        {
            Console.Write("Please type the number of the function you want to perform: ");
            string input = Console.ReadLine();
            return checkInput(input, 1, items.Count + 1);

        }

        private static int checkInt(string input)
        {
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("\n{0} is not a number, please enter a valid number.", input);
                input = Console.ReadLine();
            }
            int num = int.Parse(input);
            return num;
        }

        private static bool checkParameters(int min, int max, int num)
        {
            if (num > max) { return false; }
            if (num < min) { return false; }
            return true;
        }

        public static int checkInput(string input, int min, int max)
        {
            int num = checkInt(input);
            while (!checkParameters(min, max, num))
            {
                Console.WriteLine("{0} is not on the list of numbers to choose from, please try again", num);
                input = Console.ReadLine();
                num = int.Parse(input);
            }
            return num;
        }
                
    }
}
