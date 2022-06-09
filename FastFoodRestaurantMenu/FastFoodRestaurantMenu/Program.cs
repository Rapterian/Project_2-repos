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
            Menu mainMenu=createMainMenu();

            
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
}
