using System;
using System.Collections.Generic;

namespace TakeAwayApp
{

    class Program
    {

        //Global Variables

        static List<int> selectedPizzas = new List<int>();

        static Dictionary<int, string> pizzaMenu = new Dictionary<int, string>()

        {

            {1, "Ham & cheese"},
            {2, "Beef & onion"},
            {3, "Hawaiian"},
            {4, "Vegetarian"},
            {5, "Pepperoni"},
            {6, "Margherita"},
            {7, "Chicken BBQ"},
            {8, "Buffalo chicken"},
            {9, "Neapolitan"},
            {10, "Chicken Cranberry"},
            {11, "Hot & Spicy Veggie"},
            {12, "Cheesy Garlic"}

        };

        static Dictionary<int, double> pizzaPrices = new Dictionary<int, double>()

        {
            {1, 8.50},
            {2, 8.50},
            {3, 8.50},
            {4, 8.50},
            {5, 8.50},
            {6, 8.50},
            {7, 8.50},
            {8, 5.00},
            {9, 5.00},
            {10, 5.00},
            {11, 5.00},
            {12, 5.00}
        };

        //Decimal storage
        static double FinalPrice = 0;
        static double AdditionalPrice = 0;
        static double deliveryCharge = 3;

        //String storage
        static string CustomerName = "";
        static string DeliveryChoice = "";        

        //Delivery selection list
        static List<string> deliveryChoice = new List<string>()
        {"Delivery", "Pickup"};

        //Methods and/or functions  

        static void CalculateCost()
        {

            while (selectedPizzas.Count < 5)

            {

                Console.WriteLine("\nType the number of the pizza you would want:\n\n");

                foreach (var item in pizzaMenu)

                {

                    Console.WriteLine($"{item.Key}. {item.Value}");

                }



                if (int.TryParse(Console.ReadLine(), out int pizzaChoice))

                {

                    if (pizzaMenu.ContainsKey(pizzaChoice) && !selectedPizzas.Contains(pizzaChoice))

                    {

                        selectedPizzas.Add(pizzaChoice);

                        Console.WriteLine($"You have selected : {pizzaMenu[pizzaChoice]}\n");
                        

                    }

                    else

                    {

                        Console.WriteLine("Invalid choice or pizza already selected. Please press enter to try again..");
                        Console.ReadLine();
                        Console.Clear();
                        

                    }
                    
                }

                else

                {

                    Console.WriteLine("Invalid input. Please enter a number. Please press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();

                }

                double totalPrice = 0;

                foreach (var pizza in selectedPizzas)

                {

                    totalPrice += pizzaPrices[pizza];

                }

                totalPrice = totalPrice + AdditionalPrice;

                Console.WriteLine($"Delivery Charge: ${AdditionalPrice:F2}");

                Console.WriteLine($"Total Price: ${totalPrice:F2}");

                FinalPrice = totalPrice;

                //get user's choice
                Console.WriteLine("Press <Enter> to select more pizza's for your order or press 'XXX' to finish ordering");
                string userInput = Console.ReadLine();
                Console.Clear();

                //Convert user input to uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX"))
                {
                    //End loop
                    break;
                }
                else
                {
                    continue;

                }

            }

            Console.WriteLine("Selected Pizzas:\n");

            foreach (var pizza in selectedPizzas)

            {

                Console.WriteLine($"{pizzaMenu[pizza]} - ${pizzaPrices[pizza]:F2}\n");

            }

            Console.WriteLine($"Total Price: ${FinalPrice:F2}");
            

        }

        static string CheckName()
        {
            while (true)
            {
                //get name
                Console.WriteLine("\n\nEnter your name for the order:\n");

                string customerName = Console.ReadLine();

                if (!customerName.Equals(""))
                {
                    //convert employee name to capitalised name
                    customerName = customerName[0].ToString().ToUpper() + customerName.Substring(1);

                    return customerName;

                }

                Console.WriteLine("Error: You must enter a name for your order");
            }
        }

        static int CheckDelivery(string question, int min, int max)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine(question);
                    int userInt = Convert.ToInt32(Console.ReadLine());
                    if ((userInt < 1) || (userInt > 2))
                    {
                        //Display an error message letting th euser know it's too low/High what they have entered
                        Console.WriteLine("\nError:Enter a number 1-2 for recieving your order " +
                            "| Please press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        return userInt;
                    }
                }

                catch (System.FormatException)
                {
                    //Display an error message letting user know that intergers can only be entered
                    Console.WriteLine("\nError: Enter a number 1-2 for recieving your order\n" +
                            "| Please press enter to try again");
                    Console.ReadLine();
                    Console.Clear();
                }


            }

        }

        static void OneOrder()
        {


            //Enter and store delivery choice

            int deliveryName = CheckDelivery("Please select a choice for recieving your order:\n1.Delivery\n2.Pickup\n", 1, 2);

            //Display delivery choice
            Console.WriteLine($"\nYou have selected: {deliveryChoice[deliveryName - 1]}\n");

            DeliveryChoice = deliveryChoice[deliveryName - 1];

            if (deliveryName > 1)
            {
                string customerName = CheckName();

                Console.WriteLine($"\nThis is your name |{customerName}|\n" +
                                   "\n\n---------------------------------------------\n");

                CustomerName = customerName;
            }
            else
            {
                string customerName = CheckName();

                Console.WriteLine($"\nThis is your name |{customerName}|\n" +
                                   "\n\n---------------------------------------------\n");

                CustomerName = customerName;

                Console.WriteLine("A $3 charge will be added to your total price for your delivery.\n");

                Console.WriteLine("Enter an address for your delivery:");

                string customerAddress = Console.ReadLine();

                Console.WriteLine($"\nThis is the address |{customerAddress}|\n" +
                                   "\n\n---------------------------------------------\n");

                Console.WriteLine("Enter your phone number:");

                string customerPhone = Console.ReadLine();

                Console.WriteLine($"\nThis is the phone number |{customerPhone}|\n");

                //Add $3 charge to final price

                AdditionalPrice = AdditionalPrice + deliveryCharge;

                Console.WriteLine($"Your current price is : ${FinalPrice + AdditionalPrice}\n");


            }

        }

        static string CheckFlag()
        {
            while (true)
            {
                //get user's choice
                Console.WriteLine("\nPress <Enter> to restart your order or press 'XXX' to finish ordering");
                string userInput = Console.ReadLine();

                //Convert user input to uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX") || userInput.Equals(""))
                {
                    return userInput;
                }

                Console.WriteLine("Error: Please type the correct choice.\n");
            }
        }

        //Main process
        static void Main(string[] args)
        {
            //Take-away app introduction
            Console.WriteLine("TAKEAWAY APP");

            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("Introduction:\n" +
                "Dream pizza's will recieve an order and it's transport preference " +
                "then list each pizza with it's chosen flavour up to a maxium of 5 chosen pizza's" +
                "\nLastly, Takeaway App will display the entirety of the user's choices and its final price.");

            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("Press enter to proceed with your order. . .");
            Console.ReadLine();
            Console.Clear();



            //Loop(while) OneOrder() until user types "XXX" or "xxx"
            string flagMain = "";

            while (!flagMain.Equals("XXX"))
            {

                OneOrder();

                Console.WriteLine("----------- Customer Details ----------\n");

                CalculateCost();

                //Cancel Order option
                Console.WriteLine("\nPress <Enter> to continue or press 'XXX' to cancel your order");
                string userInput = Console.ReadLine();
                Console.Clear();

                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX"))
                {
                    break;
                }

                //Display summary of order
                Console.WriteLine("----------- Customer Details ----------\n");

                Console.WriteLine($"\nYou have selected | {DeliveryChoice} |  as your transport choice.\n");

                Console.WriteLine($"Your name is | {CustomerName} |\n");
                
                Console.WriteLine($"Final Price: ${FinalPrice:F2}\n");

                Console.WriteLine("Your pizza choices and prices were:\n");

                foreach (var pizza in selectedPizzas)

                {

                    Console.WriteLine($"{pizzaMenu[pizza]} - ${pizzaPrices[pizza]:F2}\n");

                }

                //End of main loop
                flagMain = CheckFlag();


            }

            Console.Clear();
            Console.WriteLine("\n\n----------- Thank you for using Takeaway App! ----------\n");

        }

    }
}

