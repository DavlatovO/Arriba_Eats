
using System;
namespace Arriba_Eats
{
    public class Customer: User
    {
        private Location AddressCoordinates {get; set;}
        private Order currentOrder { get; set; }

        public Customer(string name, int age, string email, string mobile_number, string password) : base(name, age, email, mobile_number, password)
        {
            AddressCoordinates = new Location(0, 0);
            currentOrder = null;
        }

        public Location Location
        {
            get { return AddressCoordinates; }
        }

        internal Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; }
        }

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

        public override void SignUp()
        {

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

            AddressCoordinates = new Location(x, y);

            // Add the user into the list database
            Save_User.Register(this);
            IsLoggedin = false;
            Console.WriteLine($"You have been successfully registered as a customer, {Name}!");
        }





    }








}