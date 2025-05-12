using System;
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
                        Customer.SignUp();

                    break; 
                }


            }
        








        }



    }


}