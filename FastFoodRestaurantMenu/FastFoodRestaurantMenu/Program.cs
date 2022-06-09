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
            int choise;
            do
            {
                mainMenu.displayMenu();
                choise = mainMenu.getReply() - 1;//the reply should be reduced
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
                                do
                                {
                                    choise = allDayBrekkiesMenu.getReply() - 1;
                                } while (addAlldayBrekiesItemToCart(choise));
                                break;

                            case BreakfastMenu.ToastedSandwiches:
                                Menu toastedSandwichesMenu = createToastedSandwichesMenu();
                                toastedSandwichesMenu.displayMenu();
                                do
                                {
                                    choise = toastedSandwichesMenu.getReply() - 1;
                                } while (addToastedSandwichesItemToCart(choise));
                                break;
                        }

                        break;

                    case MainMenu.Lunch:

                        //switch ((LunchMenu)choise)
                        //{
                        //    case LunchMenu.Burgers:
                        //        Menu burgerMenu = createBurgerMenu();
                        //        burgerMenu.displayMenu();
                        //        do
                        //        {
                        //            choise = burgerMenu.getReply() - 1;
                        //        } while (addBurgerItemToCart(choise));
                        //        break;

                        //    case LunchMenu.FamousGrills:
                        //        Menu famousGrillsMenu = createFamousGrillsMenu();
                        //        famousGrillsMenu.displayMenu();
                        //        do
                        //        {
                        //            choise = famousGrillsMenu.getReply() - 1;
                        //        } while (addFamousGrillsItemToCart(choise));
                        //        break;
                        //}

                        break;

                    case MainMenu.Drinks:

                        //switch ((DrinksMenu)choise) 
                        //{
                        //    case DrinksMenu.FrozenLemonades:
                        //        Menu frozenLemonades = createFrozenLemonadesMenu();
                        //        frozenLemonades.displayMenu();
                        //        do
                        //        {
                        //            choise = frozenLemonades.getReply() - 1;
                        //        } while (addFrozenLemonadesItemToCart(choise));
                        //        break;

                        //    case DrinksMenu.Milkshake:
                        //        Menu milkshakeMenu = createMilkshakeMenu();
                        //        milkshakeMenu.displayMenu();
                        //        do
                        //        {
                        //            choise = milkshakeMenu.getReply() - 1;
                        //        } while (addMilkshakeItemToCart(choise));
                        //        break;

                        //    case DrinksMenu.HotDrinks:
                        //        Menu hotDrinksMenu = createHotDrinksMenu();
                        //        hotDrinksMenu.displayMenu();
                        //        do
                        //        {
                        //            choise = hotDrinksMenu.getReply() - 1;
                        //        } while (addHotDrinksItemToCart(choise));
                        //        break;
                        //}

                        break;

                    case MainMenu.CheckOut:
                        checkOut();
                        break;
                }
            } while (choise != 4);

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
                    "---------", "Back");

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


                    "----------------", "Back");

                allDayBrekkiesMenu.addItem("Mzansi Brekkie");
                allDayBrekkiesMenu.addItem("Early Bird");
                allDayBrekkiesMenu.addItem("Streaky Breakfast");
                allDayBrekkiesMenu.addItem("Omelette");
                allDayBrekkiesMenu.addItem("Avo On Toast");
                return allDayBrekkiesMenu;
            }
        }
        static bool addAlldayBrekiesItemToCart(int choise)//having a cart list makes it easy to add items 
        {                                                 //and store the amounts they costs

            bool OrderAgain = true;  //the boolean value will allow a loop to be used in the switch statement               
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

                default:
                    OrderAgain = false;
                    break;
            }
            return OrderAgain;
        }


        static Menu createToastedSandwichesMenu()//this allows us to use this  
        {                                        //menu in a switch statement
            {
                Menu toastedSandwichesMenu = new Menu(
                    "Toasted Sandwiches" + "\n" +

                    "------------------", "Back");

                toastedSandwichesMenu.addItem("Cheese");
                toastedSandwichesMenu.addItem("Cheese And Tomato");
                toastedSandwichesMenu.addItem("Chicken Mayo");
                toastedSandwichesMenu.addItem("Bacon And Egg");
                toastedSandwichesMenu.addItem("Dagwood");
                return toastedSandwichesMenu;
            }
        }
        static bool addToastedSandwichesItemToCart(int choise)//having a cart list makes it easy to add items
        {                                                     //and store the amounts they costs

            bool OrderAgain = true;    //the boolean value will allow a loop to be used in the switch statement              
            switch ((ToastedSandwichesMenu)choise)
            {
                case ToastedSandwichesMenu.Cheese:
                    cart.Add(new Product("Cheese", 34.90));
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.CheeseAndTomato:
                    cart.Add(new Product("Cheese And Tomato", 42.90));
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.ChickenMayo:
                    cart.Add(new Product("Chicken Mayo", 49.90));
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.BaconAndEgg:
                    cart.Add(new Product("Bacon And Egg", 59.90));
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.Dagwood:
                    cart.Add(new Product("Dagwood", 64.90));
                    createBreakfastMenu();
                    break;
                default:
                    OrderAgain = false;
                    break;

            }
            return OrderAgain;
        }



        static void checkOut()
        {
            Console.WriteLine("------Your order:------");
            double sum = 0;
            foreach (Product product in cart)//going throug the list and displaying each item
            {                                //ass well as counting up the total
                Console.WriteLine(product.productName + "\tR" + product.productPrice);
                sum += product.productPrice;
            }
            Console.WriteLine(
                "+++++++++++++++++++++++++" + "\n" +//displaying the total in an easy to read way
                "Your Total Amount R{0}" + "\n" +
                "+++++++++++++++++++++++++", Math.Round(sum, 2));
            cart.Clear();
        }
    }


}




//        switch ((BurgerMenu)choise)
//        {
//            case BurgerMenu.Wimpy:
//                cart.Add(new Product("Wimpy", 59.90));
//                createLunchMenu();
//                break;

//            case BurgerMenu.Cheese:
//                cart.Add(new Product("Cheese", 69.90));
//                createLunchMenu();
//                break;

//            case BurgerMenu.Chicken:
//                cart.Add(new Product("Chicken", 69.90));
//                createLunchMenu();
//                break;

//            case BurgerMenu.Champion:
//                cart.Add(new Product("Champion", 89.90));
//                createLunchMenu();
//                break;

//        }


//        switch ((FamousGrillsMenu)choise)
//        {
//            case FamousGrillsMenu.ChickenAndChips:
//                cart.Add(new Product("Chicken And Chips", 56.90));
//                createLunchMenu();
//                break;

//            case FamousGrillsMenu.GrilledChickenFillets:
//                cart.Add(new Product("Grilled Chicken Fillets", 74.90));
//                createLunchMenu();
//                break;

//            case FamousGrillsMenu.ThrillOfTheGrill:
//                cart.Add(new Product("Thrill Of The Grill", 79.90));
//                createLunchMenu();
//                break;

//            case FamousGrillsMenu.ChickenWings:
//                cart.Add(new Product("Chicken Wings", 109.90));
//                createLunchMenu();
//                break;

//        }



//        switch ((FrozenLemonadesMenu)choise)
//        {
//            case FrozenLemonadesMenu.PassionFruit:
//                cart.Add(new Product("Passion Fruit Lemonade", 39.90));
//                createDrinksMenu();
//                break;

//            case FrozenLemonadesMenu.PassionFruitJug:
//                cart.Add(new Product("Passion Fruit Lemonade Jug", 94.90));
//                createDrinksMenu();
//                break;

//            case FrozenLemonadesMenu.Naartjie:
//                cart.Add(new Product("Naartjie Lemonade", 39.90));
//                createDrinksMenu();
//                break;

//            case FrozenLemonadesMenu.NaartjieJug:
//                cart.Add(new Product("Naartjie Lemonade Jug", 94.90));
//                createDrinksMenu();
//                break;

//        }


//        switch ((MilkshakeMenu)choise)
//        {
//            case MilkshakeMenu.Classic:
//                cart.Add(new Product("Classic", 39.90));
//                createDrinksMenu();
//                break;

//            case MilkshakeMenu.BarOne:
//                cart.Add(new Product("Bar One", 49.90));
//                createDrinksMenu();
//                break;

//            case MilkshakeMenu.MilkTart:
//                cart.Add(new Product("Milk Tart", 49.90));
//                createDrinksMenu();
//                break;

//            case MilkshakeMenu.ToffeMocha:
//                cart.Add(new Product("Toffe Mocha", 49.90));
//                createDrinksMenu();
//                break;

//        }


//        switch ((HotDrinksMenu)choise)
//        {
//            case HotDrinksMenu.Cappachino:
//                cart.Add(new Product("Cappachino", 34.90));
//                createDrinksMenu();
//                break;

//            case HotDrinksMenu.HotChocolate:
//                cart.Add(new Product("Hot Chocolate", 42.90));
//                createDrinksMenu();
//                break;

//            case HotDrinksMenu.Coffee:
//                cart.Add(new Product("Coffee", 24.90));
//                createDrinksMenu();
//                break;

//            case HotDrinksMenu.Tea:
//                cart.Add(new Product("Tea", 21.90));
//                createDrinksMenu();
//                break;

//        }