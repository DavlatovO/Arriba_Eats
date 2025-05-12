using System;

namespace Arriba_Eats
{
    public static class SignUpHandler
    {
        public static void SignUp(List<User> users)
        {
            const int CUSTOMER_INDEX = 1;
            const int DELIVERER_INDEX = 2;
            const int CLIENT_INDEX = 3;
            const int BACK_INDEX = 3;

            Console.WriteLine("Which type of user would you like to register as?");
            Console.WriteLine("1: Customer");
            Console.WriteLine("2: Deliverer");
            Console.WriteLine("3: Client");
            Console.WriteLine("4: Return to previous menu");

            int role;
            if (!int.TryParse(Console.ReadLine(), out role))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            User newUser = null;

            switch (role)
            {
                case CUSTOMER_INDEX:
                    newUser = new Customer();
                    break;
                case DELIVERER_INDEX:
                    newUser = new Deliverer();
                    break;
                case CLIENT_INDEX:
                    newUser = new Client();
                    break;
                default:
                    Console.WriteLine("Invalid role selected.");
                    return;
            }

            newUser.SignUp();

            if (users.Exists(u => u.Email == newUser.Email))
            {
                Console.WriteLine("A user with that email already exists.");
            }
            else
            {
                users.Add(newUser);
                Console.WriteLine($"{newUser.GetType().Name} signed up successfully!");
                Console.WriteLine("===========================");
            }
        }




    }
}