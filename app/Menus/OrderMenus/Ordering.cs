using System;
namespace Arriba_Eats
{

    class OrderMenu
    {

        public static void Ordering(Customer customer, Restaurant restaurant)
        {

            while (true)
            {
                const int MENU_INDEX = 1;
                const int NUMBER_OPTIONS = 3;
                
                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}");
              

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
                            int COMPLETE_INDEX = i + 1;
                            int CANCEL_INDEX = i + 2;
                            Console.WriteLine($"{COMPLETE_INDEX}: Complete order");

                            Console.WriteLine($"{CANCEL_INDEX}: Cancel order");



                            int choice2;
                            if (!int.TryParse(Console.ReadLine(), out choice2))
                            {
                                Console.WriteLine("Invalid choice.");
                                continue;
                            }
                             
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