using System;

namespace Arriba_Eats
{
    public static class SignUpHandler
    {
        public static void SignUp()
        {
            const int CUSTOMER_INDEX = 1;
            const int DELIVERER_INDEX = 2;
            const int CLIENT_INDEX = 3;
            const int BACK_INDEX = 4;

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
                case BACK_INDEX:
                    return;
                default:
                    Console.WriteLine("Invalid role selected.");
                    return;
            }
            if (newUser == null)
            {
                return;
            }

            newUser.SignUp(); // collect user input
            



        }




    }
}