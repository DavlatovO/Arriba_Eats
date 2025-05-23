using System;
using System.Linq;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents a deliverer in the Arriba Eats system, inheriting from the User base class.
    /// </summary>
    public class Deliverer : User
    {
        /// <summary>
        /// Gets or sets the deliverer's current geographic coordinates.
        /// </summary>
        private Location AddressCoordinates { get; set; }

        private string licence_plate;
        private DelivererStatus status;
        private Order? order;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deliverer"/> class.
        /// </summary>
        public Deliverer(string name, int age, string email, string mobile_number, string password)
            : base(name, age, email, mobile_number, password)
        {
            AddressCoordinates = new Location(0, 0);
            order = null;
            status = DelivererStatus.Free;
        }

        /// <summary>
        /// Gets the vehicle licence plate of the deliverer.
        /// </summary>
        public string LicencePlate
        {
            get { return licence_plate; }
        }

        /// <summary>
        /// Gets or sets the current order assigned to the deliverer.
        /// Internal to restrict setting outside assembly scope.
        /// </summary>
        internal Order? CurrentOrder
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// Gets or sets the deliverer's current location.
        /// </summary>
        public Location Location
        {
            get { return AddressCoordinates; }
            set { AddressCoordinates = value; }
        }

        /// <summary>
        /// Gets or sets the current delivery status of the deliverer.
        /// </summary>
        public DelivererStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Returns detailed information about the deliverer, including order status if applicable.
        /// </summary>
        /// <returns>Formatted string with deliverer details.</returns>
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
                       $"Order #{CurrentOrder.Number} from {CurrentOrder.FromRestaurant.Restaurant_Name} at " +
                       $"{CurrentOrder.FromRestaurant.Restaurant_Location.X},{CurrentOrder.FromRestaurant.Restaurant_Location.Y}.\n " +
                       $"To be delivered to {CurrentOrder.GetOwner.Name} at " +
                       $"{CurrentOrder.GetOwner.Location.X},{CurrentOrder.GetOwner.Location.Y}.";
            }
        }

        /// <summary>
        /// Prompts the deliverer to enter a valid licence plate and registers them in the system.
        /// </summary>
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

            // Add the user into the system's persistent user store
            Save_User.Register(this);
            this.IsLoggedin = false;

            Console.WriteLine($"You have been successfully registered as a deliverer, {Name}!");
        }
    }

    /// <summary>
    /// Enum representing the various delivery statuses a deliverer can have.
    /// </summary>
    public enum DelivererStatus
    {
        Free,
        AtRestaurant,
        HeadingToCustomer,
    }
}
