using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents a restaurant-owning user (client) in the Arriba Eats system.
    /// Inherits from the abstract User class.
    /// </summary>
    public class Client : User
    {
        /// <summary>
        /// Initializes a new instance of the Client class.
        /// </summary>
        public Client(string name, int age, string email, string mobileNumber, string password)
            : base(name, age, email, mobileNumber, password)
        {
        }

        /// <summary>
        /// Gets the restaurant owned by this client.
        /// </summary>
        private Restaurant OwnedRestaurant;

        /// <summary>
        /// Public accessor for the client's owned restaurant.
        /// </summary>
        public Restaurant GetRestaurant
        {
            get { return OwnedRestaurant; }
        }

        /// <summary>
        /// Provides detailed information about the client and their restaurant.
        /// </summary>
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

        /// <summary>
        /// Interactively collects client and restaurant details, registers the restaurant, and saves the client.
        /// </summary>
        public override void SignUp()
        {
            // Get restaurant name
            string restaurant_name;
            while (true)
            {
                Console.WriteLine("Please enter your restaurant's name:");
                restaurant_name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(restaurant_name))
                    break;

                Console.WriteLine("Invalid restaurant name.");
            }

            // Choose cuisine style
            Console.WriteLine("Please select your restaurant's style:");
            foreach (var style in Enum.GetValues(typeof(CuisineType)))
            {
                Console.WriteLine($"{(int)style + 1}: {style}");
            }

            Console.WriteLine("Please enter a choice between 1 and 6:");

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

            // Get location
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

            // Create and register the restaurant
            OwnedRestaurant = new Restaurant(restaurant_name, location, cuisineStyle, this);
            Restaurant_Register.Register(OwnedRestaurant);

            // Register client
            Save_User.Register(this);
            IsLoggedin = false;

            Console.WriteLine($"You have been successfully registered as a client, {Name}!");
        }
    }
}
