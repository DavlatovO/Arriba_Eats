using System;
using System.Collections.Generic;

namespace Arriba_Eats

{
    class Program
    {
        static void Main (string[] args)
        {
            List<User> users = new List<User>();
            User? loggedinUser = null;

            const int LOGIN_INDEX = 1;
            const int SIGNUP_INDEX = 2;
            const int EXIT_INDEX = 3;
            const int LOGOUT_INDEX = 4;

            


            while (true)
            {
               
                Console.WriteLine("Welcome to Arriba Eats!");
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Login as a registered user");
                Console.WriteLine("2: Register as a new user");
                Console.WriteLine("3: Exit");
                

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case SIGNUP_INDEX:
                        SignUpHandler.SignUp(users);
                        break; 

                    case LOGIN_INDEX:
                        foreach (User s in users)
                            Console.WriteLine(s.Details());

                        if (loggedinUser != null)
                        {
                            Console.WriteLine($"User '{loggedinUser.Email}' already logged in.");
                            break;
                        }
                            Console.WriteLine("Please enter your email.");
                        string email1 = Console.ReadLine();
                        Console.WriteLine("Please enter your password: ");
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
                        }
                        else if (foundUser == null)
                        {
                            Console.WriteLine("No such a user. Please sign up.");
                        }
                        else
                        {
                            Console.WriteLine("The email or password is incorrect. Try again");
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
                        Console.WriteLine("Exiting program...");
                        return;




                    default:
                        Console.WriteLine("Invalid option. Please choose between 1-4.");
                        break;
                }

                
               
            }









        }



    }


}