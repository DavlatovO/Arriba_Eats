using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Provides menu operations for customers to interact with the Arriba Eats system.
    /// </summary>
    class CustomerMenus
    {
        /// <summary>
        /// Displays the customer menu and handles all customer-related actions.
        /// </summary>
        /// <param name="customer">The currently logged-in customer.</param>
        public static void CustomerMenu(Customer customer)
        {
            // Controls the main menu loop
            bool back = false;
            while (!back)
            {
                // Menu option constants
                const int DISPLAY_INDEX = 1;
                const int RESTAURANTS_INDEX = 2;
                const int ORDERSTATUS_INDEX = 3;
                const int RATE_INDEX = 4;
                const int LOGOUT_INDEX = 5;
                const int NUMBER_OPTIONS = 5;

                // Display menu options
                Console.WriteLine($"Please make a choice from the menu below:");
                Console.WriteLine($"1: Display your user information");
                Console.WriteLine($"2: Select a list of restaurants to order from");
                Console.WriteLine($"3: See the status of your orders");
                Console.WriteLine($"4: Rate a restaurant you've ordered from");
                Console.WriteLine($"5: Log out");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

                // Read and validate user input
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
                        // Display customer information
                        case DISPLAY_INDEX:
                            Console.WriteLine(customer.Details());
                            break;
                        // Show restaurant sorting and selection menu
                        case RESTAURANTS_INDEX:
                            SortMenu.Sort(customer);
                            break;
                        // Show the status of the customer's orders
                        case ORDERSTATUS_INDEX:
                            OrderStatusMenu.OrdersStatus(customer);
                            break;
                        // Allow the customer to rate a restaurant
                        case RATE_INDEX:
                            RateMenu.Rate(customer);
                            break;
                        // Log out the customer and exit the menu
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

                // Add a blank line for readability between menu iterations
                Console.WriteLine();
            }
        }
    }
}