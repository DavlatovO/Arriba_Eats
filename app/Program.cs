using System;
using System.Collections.Generic;

namespace Arriba_Eats
{
    /// <summary>
    /// Entry point for the Arriba Eats application.
    /// Handles user login, registration, and main menu navigation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method. Displays the menu and processes user input.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            User? loggedinUser = null;

            // Menu option constants
            const int LOGIN_INDEX = 1;
            const int SIGNUP_INDEX = 2;
            const int EXIT_INDEX = 3;

            Console.WriteLine("Welcome to Arriba Eats!");
            while (true)
            {
                // Display main menu options
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Login as a registered user");
                Console.WriteLine("2: Register as a new user");
                Console.WriteLine("3: Exit");
                Console.WriteLine("Please enter a choice between 1 and 3:");

                int choice;
                // Validate user input
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case SIGNUP_INDEX:
                                    
                        // Handle user registration
                        SignUpMenu.SignUp();
                        break;

                    case LOGIN_INDEX:
                        // Handle user login
                        try
                        {
                            // Handle user login
                            var users = Save_User.GetAllUsers();
                            Console.WriteLine("Email:");
                            string email1 = Console.ReadLine();
                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();

                            // Find user by email
                            User foundUser = users.Find(u => u.Email == email1);
                            if (foundUser != null && foundUser.Login(email1, password))
                            {
                                loggedinUser = foundUser;

                                // Check user type and direct them to the appropriate menu to reduce the complexity of the code.
                                if (loggedinUser is Client client)
                                {
                                    Console.WriteLine($"Welcome back, {client.Name}!");
                                    ClientMenus.ClientMenu(client);
                                }
                                else if (loggedinUser is Customer customer)
                                {
                                    Console.WriteLine($"Welcome back, {customer.Name}!");
                                    CustomerMenus.CustomerMenu(customer);
                                }
                                else if (loggedinUser is Deliverer deliverer)
                                {
                                    Console.WriteLine($"Welcome back, {deliverer.Name}!");
                                    DelivererMenus.DelivererMenu(deliverer);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid email or password.");
                            }


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;

                    case EXIT_INDEX:
                        // Exit the application
                        Console.WriteLine("Thank you for using Arriba Eats!");
                        return;

                    default:
                        // Handle invalid menu choice
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}