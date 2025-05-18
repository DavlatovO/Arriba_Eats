using System;

using System;
namespace Arriba_Eats
{
    public class Client : User
    {
        public Client() : base("", 0, "", "", "", false)
        {
        }

        private Restaurant OwnedRestaurant;

        public Restaurant GetRestaurant
        {
            get { return OwnedRestaurant; }
        }

        public override void SignUp()
        {
            Console.WriteLine("=== Client (Restaurant Owner) Sign Up ===");

            Console.Write("Enter your name: ");
            Name = Console.ReadLine();

            Console.Write("Enter your age: ");
            Age = int.Parse(Console.ReadLine());

            Console.Write("Enter your email: ");
            Email = Console.ReadLine();

            Console.Write("Enter your mobile number: ");
            Mobile_Number = Console.ReadLine();

            Console.Write("Enter your password: ");
            Password = Console.ReadLine();

            Console.Write("Enter your restaurant name: ");
            string restaurant_name = Console.ReadLine();

            Console.WriteLine("Select your cuisine style:");
            foreach (var style in Enum.GetValues(typeof(CuisineType)))
            {
                Console.WriteLine($"{(int)style} - {style}");
            }

            int styleChoice = int.Parse(Console.ReadLine());
            CuisineType cuisineStyle = (CuisineType)styleChoice;

            Console.Write("Enter restaurant location (X,Y): ");
            string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
            string[] parts = input.Split(',');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y))
            {
                Console.WriteLine("Invalid location format.");
                return;
            }

            Location location = new Location(x, y);

            // Create the restaurant
            OwnedRestaurant = new Restaurant(restaurant_name, location, cuisineStyle, this);
            // Add the restaurant into the list database
            Restaurant_Register.Register(OwnedRestaurant);
            // Add the user into the list database
            Save_User.Register(this);

            IsLoggedin = false;


            Console.WriteLine($"You have been successfully registered as a client, {Name}!");
        }
    }
}
