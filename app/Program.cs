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

            const int SIGNUP_INDEX = 1;
            const int LOGIN_INDEX = 2;
            const int LOGOUT_INDEX = 3;
            const int EXIT_INDEX = 4;

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("Select one of the following:");
                Console.WriteLine("1. Sign up");
                Console.WriteLine("2. Log In");
                Console.WriteLine("3. Log Out");
                Console.WriteLine("4. Exit");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case SIGNUP_INDEX:
                        static void SignUp()
                        {
                            Console.Write("Sign up as Customer or Deliverer? (c/d): ");
                            string role = Console.ReadLine().ToLower();

                            User newUser = role switch
                            {
                                "c" => new Customer(),
                                "d" => new Deliverer(),
                                _ => null
                            };

                            if (newUser == null)
                            {
                                Console.WriteLine("❌ Invalid role selection.");
                                return;
                            }

                            newUser.SignUp();

                            if (users.Exists(u => u.Email == newUser.Email))
                            {
                                Console.WriteLine("❌ Error: A user with this email already exists.");
                                return;
                            }

                            users.Add(newUser);
                            Console.WriteLine("✅ Sign-up successful!");
                        }

                        break; 

                    case LOGIN_INDEX:
                        foreach (Customer s in users)
                            Console.WriteLine(s);
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

                        break;

                    case EXIT_INDEX:



                    default:
                        Console.WriteLine("Invalid option. Please choose between 1-4.");
                        break;
                }


            }
        




            



        }



    }


}