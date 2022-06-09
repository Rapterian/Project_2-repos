using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRestaurantMenu
{
    internal class Menu
    {
        //the list will allow us to count and easaly loop through the items in the menu
        //and to easally track them down if needed
        public List<string> items = new List<string>();
        public string menuHeading { get; set; }
        public string lastOption { get; set; }

        public Menu(string menuHeading)
        {
            this.menuHeading = menuHeading;
            lastOption = "Exit";//making sure there is always an exit option is nice
        }

        public Menu(string menuHeading,string lastOption)
        {
            this.menuHeading = menuHeading;
            this.lastOption = lastOption;//giving the us the flexibility to change
                                         //the last option to something like back
        }

        public void addItem(string item)
        {
            items.Add(item);
        }

        public void displayMenu()
        {
            Console.WriteLine("\n"+menuHeading);//Leaving a line open before the menu
                                                //makes it esier to read
            int count = 1;
            foreach (string item in items)//automating the listing and counting saves time
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
            return checkInput(input, 1, items.Count + 1);//making sure the user can only give
                                                         //a valid number
        }

        private static int checkInt(string input)
        {
            while (!int.TryParse(input, out int result))//keep asking for a numbe untill 
            {                                           //one is given
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
            return true;//making sure the user gives a number that is on the list
        }

        public static int checkInput(string input, int min, int max)
        {
            int num = checkInt(input);
            while (!checkParameters(min, max, num))//keep asking the user for a number on the list
            {                                      //untill one is given
                Console.WriteLine("{0} is not on the list of numbers to choose from, please try again", num);
                input = Console.ReadLine();
                num = int.Parse(input);
            }
            return num;
        }
                
    }
}
