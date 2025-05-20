
using System;
namespace Arriba_Eats
{
    public class Customer: User
    {
        public Location AddressCoordinates {get; set;}
        private Order currentOrder { get; set; }

        public Customer(): base("", 0, "", "", "", false)
        {
            AddressCoordinates = new Location(0, 0);
            currentOrder = null;
        }

        public Location location
        {
            get { return AddressCoordinates; }
        }

        internal Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; }
        }

        public override void SignUp()
        {
           

            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();

            Console.Write("Please enter your age: ");
            Age = int.Parse(Console.ReadLine());

            Console.Write("Please enter your email: ");
            Email = Console.ReadLine();
            

            Console.Write("Please enter your mobile number: ");
            Mobile_Number = Console.ReadLine();

            Console.Write("Please enter your password: ");

            Console.WriteLine("Your password must:\r\n- be at least 8 characters long\r\n- contain a number\r\n- contain a lowercase letter\r\n- contain an uppercase letter\r\nPlease enter a password:");
            Password = Console.ReadLine();

            Console.Write("Please enter your location (X,Y): ");
            string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
            string[] parts = input.Split(',');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y))
            {
                Console.WriteLine("Invalid location.");
                return;
            }

            AddressCoordinates = new Location(x, y);

            // Add the user into the list database
            Save_User.Register(this);
            IsLoggedin = false;
            Console.WriteLine($"You have been successfully registered as a customer, {Name}!");
        }





    }








}