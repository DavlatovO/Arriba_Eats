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
            const int LOGOUT_INDEX = 4;

            


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("Welcome to Arriba Eats!");
                Console.WriteLine("1: Login as a registered user");
                Console.WriteLine("2: Register as a new user");
                Console.WriteLine("3: Exit");
                Console.WriteLine("Please enter a choice between 1 and 3:");
                

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case SIGNUP_INDEX:
                        SignUpHandler.SignUp();
                        break; 

                    case LOGIN_INDEX:
                        var users = Save_User.GetAllUsers();
                        foreach (User s in users)
                            Console.WriteLine(s.Details());

                        if (loggedinUser != null && loggedinUser.IsLoggedin)
                        {
                            Console.WriteLine($"User '{loggedinUser.Email}' already logged in.");
                            break;
                        }
                            Console.WriteLine("Email:");
                        string email1 = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string password = Console.ReadLine();

                        User foundUser = users.Find(u => u.Email == email1);
                        if (foundUser != null && foundUser.Login(email1, password))
                        {
                            loggedinUser = foundUser;
                            Console.WriteLine($"Login Successfull as {email1}");
                            if (loggedinUser is Client client)
                            {
                                ClientMenus.ClientMenu(client);
                            }
                            else if (loggedinUser is Customer customer)
                            {
                                CustomerMenus.CustomerMenu(customer);
                            }
                        }
                        else if (foundUser == null)
                        {
                            Console.WriteLine("No such a user. Please sign up.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid email or password.");
                        }

                    break;

                    case LOGOUT_INDEX:
                        if (loggedinUser == null)
                        {
                            Console.WriteLine("No user is currently logged in.");
                        }
                        else
                        {
                            loggedinUser.Logout();
                            Console.WriteLine("Logged out successfully.");
                            loggedinUser = null;
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