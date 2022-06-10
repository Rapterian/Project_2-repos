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
            do  //this loop will make sure the only way the program can end is by using the 6th option
            {   //wich is exit
                mainMenu.displayMenu();
                choise = mainMenu.getReply() - 1;//the reply should be reduced
                                                 //since enums are zero based 
                                                 //and the list the user sees 
                                                 //starts with 1

                switch ((MainMenu)choise)//Using the enums in a switch statement
                {
                    case MainMenu.Breakfast:
                        Menu breakfastMenu = createBreakfastMenu();
                        do
                        {
                            breakfastMenu.displayMenu();
                            choise = breakfastMenu.getReply() - 1;

                            switch ((BreakfastMenu)choise)      //Having nested switch statements allows us to easily
                            {                                   //move through menus and submenus
                                case BreakfastMenu.AllDayBrekkies:
                                    Menu allDayBrekkiesMenu = createAllDayBrekkiesMenu();
                                    allDayBrekkiesMenu.displayMenu();
                                    do  //this loop will allow the user to get multiple items on the menu instead of 
                                    {   //cycling throug all the menus and submenus just to get at the sam place
                                        choise = allDayBrekkiesMenu.getReply() - 1;
                                    } while (addAlldayBrekiesItemToCart(choise));
                                    break;

                                case BreakfastMenu.ToastedSandwiches:
                                    Menu toastedSandwichesMenu = createToastedSandwichesMenu();
                                    toastedSandwichesMenu.displayMenu();
                                    do  //this loop will allow the user to get multiple items on the menu instead of 
                                    {
                                        choise = toastedSandwichesMenu.getReply() - 1;
                                    } while (addToastedSandwichesItemToCart(choise));
                                    break;
                            }
                        }while(choise != 2);

                        break;

                    case MainMenu.Lunch:
                        Menu lunchMenu = createLunchMenu();
                        do
                        {
                            lunchMenu.displayMenu();
                            choise = lunchMenu.getReply() - 1;
                            switch ((LunchMenu)choise)        //Having nested switch statements allows us to easily
                            {                                 //move through menus and submenus  
                                case LunchMenu.Burgers:
                                    Menu burgerMenu = createBurgerMenu();
                                    burgerMenu.displayMenu();
                                    do    //this loop will allow the user to get multiple items on the menu instead of 
                                    {     //cycling throug all the menus and submenus just to get at the sam place
                                        choise = burgerMenu.getReply() - 1;
                                    } while (addBurgerItemToCart(choise));
                                    break;

                                case LunchMenu.FamousGrills:
                                    Menu famousGrillsMenu = createFamousGrillsMenu();
                                    famousGrillsMenu.displayMenu();
                                    do    //this loop will allow the user to get multiple items on the menu instead of 
                                    {     //cycling throug all the menus and submenus just to get at the sam place
                                        choise = famousGrillsMenu.getReply() - 1;
                                    } while (addFamousGrillsItemToCart(choise));
                                    break;
                            }
                        }while (choise != 2);

                        break;

                    case MainMenu.Drinks:
                        Menu drinksMenu = createDrinksMenu();
                        do
                        {
                            drinksMenu.displayMenu();
                            choise = drinksMenu.getReply() - 1;

                            switch ((DrinksMenu)choise)   //Having nested switch statements allows us to easily
                            {                             //move through menus and submenus
                                case DrinksMenu.FrozenLemonades:
                                    Menu frozenLemonades = createFrozenLemonadesMenu();
                                    frozenLemonades.displayMenu();
                                    do    //this loop will allow the user to get multiple items on the menu instead of 
                                    {     //cycling throug all the menus and submenus just to get at the sam place
                                        choise = frozenLemonades.getReply() - 1;
                                    } while (addFrozenLemonadesItemToCart(choise));
                                    break;

                                case DrinksMenu.Milkshake:
                                    Menu milkshakeMenu = createMilkshakeMenu();
                                    milkshakeMenu.displayMenu();
                                    do    //this loop will allow the user to get multiple items on the menu instead of 
                                    {     //cycling throug all the menus and submenus just to get at the sam place
                                        choise = milkshakeMenu.getReply() - 1;
                                    } while (addMilkshakeItemToCart(choise));
                                    break;

                                case DrinksMenu.HotDrinks:
                                    Menu hotDrinksMenu = createHotDrinksMenu();
                                    hotDrinksMenu.displayMenu();
                                    do    //this loop will allow the user to get multiple items on the menu instead of 
                                    {     //cycling throug all the menus and submenus just to get at the sam place
                                        choise = hotDrinksMenu.getReply() - 1;
                                    } while (addHotDrinksItemToCart(choise));
                                    break;
                            }
                        } while (choise != 3);

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

        static Menu createLunchMenu()//this allows us to use this  
        {                                //menu in a switch statement
            {
                Menu lunchtMenu = new Menu(
                    "-----" + "\n" +
                    "Lucnh" + "\n" +
                    "-----", "Back");

                lunchtMenu.addItem("Burgers");
                lunchtMenu.addItem("Famous Grills");
                return lunchtMenu;
            }
        }

        static Menu createDrinksMenu()//this allows us to use this  
        {                                //menu in a switch statement
            {
                Menu drinksMenu = new Menu(
                    "---------" + "\n" +
                    "Breakfast" + "\n" +
                    "---------", "Back");

                drinksMenu.addItem("FrozenLemonades");
                drinksMenu.addItem("Milkshake");
                drinksMenu.addItem("Hot Drinks");
                return drinksMenu;
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
                    Console.WriteLine("Cheese added to order");
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.CheeseAndTomato:
                    cart.Add(new Product("Cheese And Tomato", 42.90));
                    Console.WriteLine("Cheese And Tomato added to order");
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.ChickenMayo:
                    cart.Add(new Product("Chicken Mayo", 49.90));
                    Console.WriteLine("Chicken Mayo added to order");
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.BaconAndEgg:
                    cart.Add(new Product("Bacon And Egg", 59.90));
                    Console.WriteLine("Bacon And Egg added to order");
                    createBreakfastMenu();
                    break;
                case ToastedSandwichesMenu.Dagwood:
                    cart.Add(new Product("Dagwood", 64.90));
                    Console.WriteLine("Dagwood added to order");
                    createBreakfastMenu();
                    break;
                default:
                    OrderAgain = false;
                    break;

            }
            return OrderAgain;
        }

        static Menu createBurgerMenu()
        {
            Menu burgerMenu = new Menu(
            "Burgers" + "\n" +
            "------------------", "Back");

            burgerMenu.addItem("Wimpy");
            burgerMenu.addItem("Cheese");
            burgerMenu.addItem("Chicken");
            burgerMenu.addItem("Champion");
            return burgerMenu;
        }



        static bool addBurgerItemToCart(int choice)
        {
            bool orderAgain = true;
            switch ((BurgerMenu)choice)
            {
                case BurgerMenu.Wimpy:
                    cart.Add(new Product("Wimpy", 59.90));
                    Console.WriteLine("Wimpy added to order");
                    createBurgerMenu();
                    break;



                case BurgerMenu.Cheese:
                    cart.Add(new Product("Cheese", 69.90));
                    Console.WriteLine("Omelette added to order");
                    createBurgerMenu();
                    break;



                case BurgerMenu.Chicken:
                    cart.Add(new Product("Chicken", 69.90));
                    Console.WriteLine("Chicken added to order");
                    createBurgerMenu();
                    break;



                case BurgerMenu.Champion:
                    cart.Add(new Product("Champion", 89.90));
                    Console.WriteLine("Champion added to order");
                    createBurgerMenu();
                    break;
                default:
                    orderAgain = false;
                    break;



            }
            return orderAgain;
        }

        static Menu createFamousGrillsMenu()
        {
            Menu famousGrillsMenu = new Menu(
            "Famous Grills" + "\n" +
            "------------------", "Back");

            famousGrillsMenu.addItem("Chicken And Chips");
            famousGrillsMenu.addItem("Grilled Chicken Fillets");
            famousGrillsMenu.addItem("Thrill Of The Grill");
            famousGrillsMenu.addItem("Chicken Wings");
            return famousGrillsMenu;
        }



        static bool addFamousGrillsItemToCart(int choice)
        {
            bool orderAgain = true;
            switch ((FamousGrillsMenu)choice)
            {
                case FamousGrillsMenu.ChickenAndChips:
                    cart.Add(new Product("Chicken And Chips", 56.90));
                    Console.WriteLine("Chicken And Chips added to order");
                    createFamousGrillsMenu();
                    break;



                case FamousGrillsMenu.GrilledChickenFillets:
                    cart.Add(new Product("Grilled Chicken Fillets", 74.90));
                    Console.WriteLine("Grilled Chicken Fillets added to order");
                    createFamousGrillsMenu();
                    break;



                case FamousGrillsMenu.ThrillOfTheGrill:
                    cart.Add(new Product("Thrill Of The Grill", 79.90));
                    Console.WriteLine("Thrill Of The Grill added to order");
                    createFamousGrillsMenu();
                    break;



                case FamousGrillsMenu.ChickenWings:
                    cart.Add(new Product("Chicken Wings", 109.90));
                    Console.WriteLine("Chicken Wings added to order");
                    createFamousGrillsMenu();
                    break;
                default:
                    orderAgain = false;
                    break;
            }
            return orderAgain;
        }

        static Menu createFrozenLemonadesMenu()
        {
            Menu frozenLemonadesMenu = new Menu(
            "Frozen Lemondes" + "\n" +
            "------------------", "Back");

            frozenLemonadesMenu.addItem("Passion Fruit");
            frozenLemonadesMenu.addItem("Passion Fruit Jug");
            frozenLemonadesMenu.addItem("Naartjie");
            frozenLemonadesMenu.addItem("Naartjie Jug");
            return frozenLemonadesMenu;
        }



        static bool addFrozenLemonadesItemToCart(int choice)
        {
            bool orderAgain = true;
            switch ((FrozenLemonadesMenu)choice)
            {
                case FrozenLemonadesMenu.PassionFruit:
                    cart.Add(new Product("Passion Fruit Lemonade", 39.90));
                    Console.WriteLine("Passion Fruit added to order");
                    createFrozenLemonadesMenu();
                    break;



                case FrozenLemonadesMenu.PassionFruitJug:
                    cart.Add(new Product("Passion Fruit Lemonade Jug", 94.90));
                    Console.WriteLine("Passion Fruit Jug added to order");
                    createFrozenLemonadesMenu();
                    break;



                case FrozenLemonadesMenu.Naartjie:
                    cart.Add(new Product("Naartjie Lemonade", 39.90));
                    Console.WriteLine("Naartjie added to order");
                    createFrozenLemonadesMenu();
                    break;



                case FrozenLemonadesMenu.NaartjieJug:
                    cart.Add(new Product("Naartjie Lemonade Jug", 94.90));
                    Console.WriteLine("Naartjie Jug added to order");
                    createFrozenLemonadesMenu();
                    break;
                default:
                    orderAgain = false;
                    break;
            }
            return orderAgain;
        }

        static Menu createMilkshakeMenu()
        {
            Menu milkshakeMenu = new Menu(
            "Milkshake" + "\n" +
            "------------------", "Back");

            milkshakeMenu.addItem("Classic");
            milkshakeMenu.addItem("Bar One");
            milkshakeMenu.addItem("Milk Tart");
            milkshakeMenu.addItem("Toffe Mocha");
            return milkshakeMenu;
        }



        static bool addMilkshakeItemToCart(int choice)
        {
            bool orderAgain = true;
            switch ((MilkshakeMenu)choice)
            {
                case MilkshakeMenu.Classic:
                    cart.Add(new Product("Classic", 39.90));
                    Console.WriteLine("Classic added to order");
                    createMilkshakeMenu();
                    break;



                case MilkshakeMenu.BarOne:
                    cart.Add(new Product("Bar One", 49.90));
                    Console.WriteLine("Bar One added to order");
                    createMilkshakeMenu();
                    break;



                case MilkshakeMenu.MilkTart:
                    cart.Add(new Product("Milk Tart", 49.90));
                    Console.WriteLine("Milk Tart added to order");
                    createMilkshakeMenu();
                    break;



                case MilkshakeMenu.ToffeMocha:
                    cart.Add(new Product("Toffe Mocha", 49.90));
                    Console.WriteLine("Toffe Mocha added to order");
                    createMilkshakeMenu();
                    break;
                default:
                    orderAgain = false;
                    break;
            }
            return orderAgain;
        }


        static Menu createHotDrinksMenu()
        {
            Menu hotDrinksMenu = new Menu(
            "Hot Drinks" + "\n" +
            "------------------", "Back"); hotDrinksMenu.addItem("Cappachino");
            hotDrinksMenu.addItem("Hot Chocolate");
            hotDrinksMenu.addItem("Coffee");
            hotDrinksMenu.addItem("Tea");
            return hotDrinksMenu;
        }
        static bool addHotDrinksItemToCart(int choice)
        {
            bool orderAgain = true;
            switch ((HotDrinksMenu)choice)
            {
                case HotDrinksMenu.Cappachino:
                    cart.Add(new Product("Cappachino", 34.90));
                    Console.WriteLine("Cappachino added to order");
                    createHotDrinksMenu();
                    break;
                case HotDrinksMenu.HotChocolate:
                    cart.Add(new Product("Hot Chocolate", 42.90));
                    Console.WriteLine("Hot Chocolate added to order");
                    createHotDrinksMenu();
                    break;
                case HotDrinksMenu.Coffee:
                    cart.Add(new Product("Coffee", 24.90));
                    Console.WriteLine("Coffee added to order");
                    createHotDrinksMenu();
                    break;
                case HotDrinksMenu.Tea:
                    cart.Add(new Product("Tea", 21.90));
                    Console.WriteLine("Tea added to order");
                    createHotDrinksMenu();
                    break;
                default:
                    orderAgain = false;
                    break;
            }
            return orderAgain;
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
            cart.Clear();//clearing the cart after checkout
        }
    }


}



