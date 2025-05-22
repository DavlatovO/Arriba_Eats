using System;
using System.Linq;

namespace Arriba_Eats
{
    public class Deliverer : User
    {
        private Location AddressCoordinates { get; set; }

        private string licence_plate;
        private DelivererStatus status;
        private Order? order;

        public Deliverer(string name, int age, string email, string mobile_number, string password)
            : base(name, age, email, mobile_number, password)
        {
            AddressCoordinates = new Location(0, 0);
            order = null;
            status = DelivererStatus.Free;
        }

        public string LicencePlate
        {
            get { return licence_plate; }
        }

        internal Order? CurrentOrder
        {
            get { return order; }
            set { order = value; }
        }

        public Location Location
        {
            get { return AddressCoordinates; }
            set { AddressCoordinates = value; }
        }
        public DelivererStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public override string Details()
        {
            if (CurrentOrder == null)
            { 
                return $"Your user details are as follows:\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Email: {Email}\n" +
                   $"Mobile: {Mobile_Number}\n" +
                   $"Licence plate: {licence_plate}";
            }
            else
            {
                return $"Your user details are as follows:\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Email: {Email}\n" +
                   $"Mobile: {Mobile_Number}\n" +
                   $"Licence plate: {licence_plate}\n" +
                   $"Current delivery:\n " +
                   $"Order #{CurrentOrder.Number} from {CurrentOrder.FromRestaurant.Restaurant_Name} at {CurrentOrder.FromRestaurant.Restaurant_Location.X},{CurrentOrder.FromRestaurant.Restaurant_Location.Y}.\n " +
                   $"To be delivered to {CurrentOrder.GetOwner.Name} at {CurrentOrder.GetOwner.Location.X},{CurrentOrder.GetOwner.Location.Y}.";
            }
                    
            
            
        }

        public override void SignUp()
        {
            string licencePlate;
            while (true)
            {
                Console.WriteLine("Please enter your licence plate:");
                licencePlate = Console.ReadLine();

                bool isValid =
                    !string.IsNullOrWhiteSpace(licencePlate?.Trim()) &&
                    licencePlate.Length >= 1 &&
                    licencePlate.Length <= 8 &&
                    licencePlate.All(c => char.IsUpper(c) || char.IsDigit(c) || c == ' ');

                if (isValid)
                    break;

                Console.WriteLine("Invalid licence plate.");
            }

            licence_plate = licencePlate;

            // Add the user into the list database
            Save_User.Register(this);
            this.IsLoggedin = false;

            Console.WriteLine($"You have been successfully registered as a deliverer, {Name}!");
        }
    }

    public enum DelivererStatus
    {
        Free,
        HeadingToRestaurant,
        AtRestaurant,
        OnTheWay,
    }
}
