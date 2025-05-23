using System;
using System.Linq;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents a customer in the Arriba Eats system, extending the User base class.
    /// </summary>
    public class Customer : User
    {
        /// <summary>
        /// Gets or sets the customer's location coordinates.
        /// </summary>
        private Location AddressCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the current order of the customer.
        /// Internal to restrict access outside of assembly.
        /// </summary>
        private Order currentOrder { get; set; }

        /// <summary>
        /// Constructs a new customer instance with the specified details.
        /// </summary>
        public Customer(string name, int age, string email, string mobile_number, string password)
            : base(name, age, email, mobile_number, password)
        {
            AddressCoordinates = new Location(0, 0);
            currentOrder = null;
        }

        /// <summary>
        /// Gets the customer's location.
        /// </summary>
        public Location Location
        {
            get { return AddressCoordinates; }
        }

        /// <summary>
        /// Gets or sets the customer's current active order.
        /// </summary>
        internal Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; }
        }

        /// <summary>
        /// Returns a detailed summary of the customer's profile and activity.
        /// </summary>
        /// <returns>String summary including name, contact info, location, and order stats.</returns>
        public override string Details()
        {
            var orders = Order_List.GetAllOrders().Where(order => order.GetOwner == this).ToList();
            var totalSpent = orders.Sum(order => order.TotalPrice);

            return "Your user details are as follows:\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Email: {Email}\n" +
                   $"Mobile: {Mobile_Number}\n" +
                   $"Location: {AddressCoordinates.X},{AddressCoordinates.Y}\n" +
                   $"You've made {orders.Count} order(s) and spent a total of ${totalSpent:F2} here.";
        }

        /// <summary>
        /// Prompts the customer to enter a valid location and registers them in the system.
        /// </summary>
        public override void SignUp()
        {
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

            AddressCoordinates = new Location(x, y);

            // Add the customer to the registered user list
            Save_User.Register(this);
            IsLoggedin = false;

            Console.WriteLine($"You have been successfully registered as a customer, {Name}!");
        }
    }
}
