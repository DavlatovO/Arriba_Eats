using System;

namespace Arriba_Eats
{
    class CustomerMenus
    {
        public static void CustomerMenu(Customer customer)
        {
            
            bool back = false;
            while (!back)
            {


                const int DISPLAY_INDEX = 1;
                const int RESTAURANTS_INDEX = 2;
                const int ORDERSTATUS_INDEX = 3;
                const int RATE_INDEX = 4;
                const int LOGOUT_INDEX = 5;
                const int NUMBER_OPTIONS = 5;

              
                Console.WriteLine($"Please make a choice from the menu below:");
                Console.WriteLine($"1: Display your user information");
                Console.WriteLine($"2: Select a list of restaurants to order from");
                Console.WriteLine($"3: See the status of your orders");
                Console.WriteLine($"4: Rate a restaurant you've ordered from");
                Console.WriteLine($"5: Log out");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

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
                        case DISPLAY_INDEX:
                            Console.WriteLine(customer.Details());
                            break;
                        case RESTAURANTS_INDEX:
                            SortMenu.Sort(customer);
                            break;
                        case ORDERSTATUS_INDEX:
                            OrderStatusMenu.OrderStatus(customer);
                            break;
                        case RATE_INDEX:
                            RateMenu.Rate(customer);
                            break;
                        case LOGOUT_INDEX:
                            back = true;
                            customer.Logout();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                Console.WriteLine();

            }
        }

    }


}