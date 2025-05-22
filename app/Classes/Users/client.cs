using System;

namespace Arriba_Eats
{
    public class Client : User
    {
        public Client(string name, int age, string email, string mobileNumber, string password) : base(name, age, email, mobileNumber, password)
        {
        }

        private Restaurant OwnedRestaurant;

        public Restaurant GetRestaurant
        {
            get { return OwnedRestaurant; }
        }

        public override string Details()
        {
            return "Your user details are as follows:\n" +
                $"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                $"Mobile: {Mobile_Number}\n" +
                $"Restaurant name: {this.GetRestaurant.Restaurant_Name}\n" +
                $"Restaurant style: {this.GetRestaurant.CuisineStyle}\n" +
                $"Restaurant location: {this.GetRestaurant.Restaurant_Location.X},{this.GetRestaurant.Restaurant_Location.Y}";
        }


        public override void SignUp()
        {

            string restaurant_name;
            while (true)
            {
                Console.WriteLine("Please enter your restaurant's name:");
                restaurant_name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(restaurant_name))
                    break;

                Console.WriteLine("Invalid restaurant name.");
            }


            Console.WriteLine("Please select your restaurant's style:");
            foreach (var style in Enum.GetValues(typeof(CuisineType)))
            {
                Console.WriteLine($"{(int)style+1}: {style}");
            }
            Console.WriteLine("Please enter a choice between 1 and 6:");

            // Ask until a valid style choice is made
            int styleChoice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out styleChoice) &&
                    Enum.IsDefined(typeof(CuisineType), styleChoice - 1))
                {
                    break;
                }
                Console.WriteLine("Invalid choice.");
            }
            CuisineType cuisineStyle = (CuisineType)(styleChoice - 1);

            // Ask until a valid location is entered
            int x, y;
            while (true)
            {
                Console.WriteLine("Please enter your location (in the form of X,Y):");
                string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
                string[] parts = input.Split(',');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out x) &&
                    int.TryParse(parts[1], out y))
                {
                    break;
                }

                Console.WriteLine("Invalid location.");
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
