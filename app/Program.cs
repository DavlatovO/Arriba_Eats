using System;
using System.Collections.Generic;

namespace Arriba_Eats

{
    class Program
    {
        static void Main (string[] args)
        {
            User? loggedinUser = null;

            const int LOGIN_INDEX = 1;
            const int SIGNUP_INDEX = 2;
            const int EXIT_INDEX = 3;
            

            Console.WriteLine("Welcome to Arriba Eats!");
            while (true)
            {
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Login as a registered user");
                Console.WriteLine("2: Register as a new user");
                Console.WriteLine("3: Exit");
                Console.WriteLine("Please enter a choice between 1 and 3:");
                

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case SIGNUP_INDEX:
                        SignUpMenu.SignUp();
                        break; 

                    case LOGIN_INDEX:
                        var users = Save_User.GetAllUsers();
                        
                        Console.WriteLine("Email:");
                        string email1 = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string password = Console.ReadLine();

                        User foundUser = users.Find(u => u.Email == email1);
                        if (foundUser != null && foundUser.Login(email1, password))
                        {
                            loggedinUser = foundUser;

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

                        break;

                    case EXIT_INDEX:
                        Console.WriteLine("Thank you for using Arriba Eats!");
                        return;




                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                
               
            }









        }



    }


}