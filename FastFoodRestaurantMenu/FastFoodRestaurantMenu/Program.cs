using System;
using System.Collections.Generic;

namespace FastFoodRestaurantMenu
{
    internal class Program
    {
        enum MainMenu
        {
            Breakfast, Lunch, Drinks, CheckOut
        }

        enum BreakfastMenu
        {
            AllDayBrekkies, ToastedSandwiches
        }

        enum AllDayBrekkiesMenu
        {
            MzansiBrekkie, EarlyBird, StreakyBreakfast, Omelette, AvoOnToast
        }

        enum ToastedSandwichesMenu
        {
            Cheese, CheeseAndTomato, ChickenMayo, BaconAndEgg, Dagwood
        }

        enum LunchMenu
        {
            Burgers, FamousGrills
        }

        enum BurgerMenu
        {
            Wimpy, Cheese, Chicken, Champion
        }

        enum FamousGrillsMenu
        {
            ChickenAndChips, GrilledChickenFillets, ThrillOfTheGrill, ChickenWings
        }
        enum DrinksMenu
        {
            FrozenLemonades, Milkshake, HotDrinks
        }

        enum FrozenLemonadesMenu
        {
            PassionFruit, PassionFruitJug, Naartjie, NaartjieJug
        }

        enum MilkshakeMenu
        {
            Classic, BarOne, MilkTart, ToffeMocha
        }
        enum HotDrinksMenu
        {
            Cappachino, HotChocolate, Coffee, Tea
        }

        static List<Product> cart = new List<Product>();
        static void Main(string[] args)
        {
            Menu mainMenu = createMainMenu();
            mainMenu.displayMenu();
            int choise = mainMenu.getReply() - 1;//the reply should be reduced
                                                 //since enums are zero based 
                                                 //and the list the user sees 
                                                 //starts with 1

            switch ((MainMenu)choise)//Using the enums in a switch statement
            {
                case MainMenu.Breakfast:
                    Menu breakfastMenu = createBreakfastMenu();
                    breakfastMenu.displayMenu();
                    choise = breakfastMenu.getReply() - 1;

                    switch ((BreakfastMenu)choise)
                    {
                        case BreakfastMenu.AllDayBrekkies:
                            Menu allDayBrekkiesMenu = createAllDayBrekkiesMenu();
                            allDayBrekkiesMenu.displayMenu();
                            choise = allDayBrekkiesMenu.getReply() - 1;
                            addAlldayBrekiesItemToCart(choise);
                            break;

                        case BreakfastMenu.ToastedSandwiches:

                            break;
                    }

                    break;
            }

        }

        static Menu createMainMenu()//this allows us to use this  
        {                           //menu in a switch statement
            Menu mainMenu = new Menu(
                "==========" + "\n" +
                "WIMPY MENU" + "\n" +
                "==========");
            mainMenu.addItem("Breakfast");
            mainMenu.addItem("Lunch");
            mainMenu.addItem("Drinks");
            mainMenu.addItem("Check Out");
            return mainMenu;

        }

        static Menu createBreakfastMenu()//this allows us to use this  
        {                                //menu in a switch statement
            {
                Menu breakfastMenu = new Menu(
                    "---------" + "\n" +
                    "Breakfast" + "\n" +
                    "---------");

                breakfastMenu.addItem("All Day Brekkies");
                breakfastMenu.addItem("Toasted Sandwiches");
                return breakfastMenu;
            }
        }

        static Menu createAllDayBrekkiesMenu()//this allows us to use this  
        {                                     //menu in a switch statement
            {
                Menu allDayBrekkiesMenu = new Menu(
                    "All Day Brekkies" + "\n" +
                    "----------------");

                allDayBrekkiesMenu.addItem("Omelette");
                allDayBrekkiesMenu.addItem("Mzansi Brekkie");
                allDayBrekkiesMenu.addItem("Early Bird");
                allDayBrekkiesMenu.addItem("Streaky Breakfast");
                allDayBrekkiesMenu.addItem("Avo On Toast");
                return allDayBrekkiesMenu;
            }
        }
        static void addAlldayBrekiesItemToCart(int choise)
        {
            switch ((AllDayBrekkiesMenu)choise)
            {
                case AllDayBrekkiesMenu.Omelette:
                    cart.Add(new Product("Omelette", 59.90));
                    Console.WriteLine("Omelette added to order");
                    break;

                case AllDayBrekkiesMenu.MzansiBrekkie:
                    cart.Add(new Product("Mzansi Brekkie", 34.90));
                    Console.WriteLine("Mzansi Brekkie added to order");
                    break;

                case AllDayBrekkiesMenu.EarlyBird:
                    cart.Add(new Product("Early Bird", 42.90));
                    Console.WriteLine("Early Bird added to order");
                    break;

                case AllDayBrekkiesMenu.StreakyBreakfast:
                    cart.Add(new Product("Streaky Breakfast", 49.90));
                    Console.WriteLine("Streaky Breakfast added to order");
                    break;

                case AllDayBrekkiesMenu.AvoOnToast:
                    cart.Add(new Product("Avo On Toast", 64.90));
                    Console.WriteLine("Avo On Toast added to order");
                    break;
            }
        }

    }
}


