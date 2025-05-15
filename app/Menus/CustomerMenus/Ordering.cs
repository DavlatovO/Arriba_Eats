using System;
 namespace Arriba_Eats
{

    class OrderingMenu
    {
        public static void OrderMenu(Customer customer, Restaurant restaurant)
        {

            while (true)
            {
                const int MENU_INDEX = 1;
                const int REVIEWS_INDEX = 2;
                const int BACK_INDEX = 3;
                const int NUMBER_OPTIONS = 3;

                int OPTIONS = restaurant.Menu.Count;

                Console.WriteLine();
                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}");
                Console.WriteLine($"1: See this restaurant's menu and place an order");
                Console.WriteLine($"2: See reviews for this restaurant");
                Console.WriteLine("3: Return to main menu");
                Console.WriteLine($"Please enter a choice between 1 and {OPTIONS+2}:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                if ((choice > 0) && (choice <= NUMBER_OPTIONS))
                {
                    switch (choice)
                    {
                        case MENU_INDEX:
                            Console.WriteLine($"Current order total: $TotalPrice");
                            int i = 0; 
                            foreach (var menu in restaurant.Menu)
                            {
                                i++;
                                Console.WriteLine($"{i}:   ${menu.Price}  {menu.Name}");
                            }
                            Console.WriteLine($"{i + 1}: Complete order");
                            Console.WriteLine($"{i + 2}: Cancel order");  
                            break;
                        case REVIEWS_INDEX:
                            Console.WriteLine();
                            break;
                        case BACK_INDEX:
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;


                    }
                }
            }
        }





    }





}