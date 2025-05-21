
using System;
namespace Arriba_Eats
{
    public class Deliverer : User
    {
        public Location AddressCoordinates { get; set; }
        private string licence_plate;
        private DelivererStatus status;

        private Order? order;



        public Deliverer(string name, int age, string email, int mobile_number, string password, bool isloggedin, string licenceplate, string addresscoordinates) : base(name, age, email, mobile_number, password, isloggedin)
        {

            AddressCoordinates = new Location(0,0);
            licence_plate = licenceplate;
            order = null;
            status = DelivererStatus.Free;
        }

        public Location location
        {
            get { return AddressCoordinates; }
            set { location = value; }
        }
        public string Licence_plate
        {
            get { return licence_plate; }
        }

        internal Order GetOrder
        {
            get { return order; }
            set { order = value; }
            
        }

        public DelivererStatus Status
        {
            get { return status; }
            set { status = value; }
        }


        public override void SignUp()
        {

            Console.Write("Please enter your licence plate: ");
            string licence_plate = Console.ReadLine();

            Console.Write("Please enter your name: ");
            string Name = Console.ReadLine();

            Console.Write("Please enter your age: ");
            int Age = int.Parse(Console.ReadLine());

            Console.Write("Please enter your email: ");
            string Email = Console.ReadLine();


            Console.Write("Please enter your mobile number: ");
            int Mobile_Number = Int32.Parse(Console.ReadLine());

            Console.Write("Please enter your password: ");
            Console.WriteLine("Your password must:\r\n- be at least 8 characters long\r\n- contain a number\r\n- contain a lowercase letter\r\n- contain an uppercase letter\r\nPlease enter a password:");
            string Password = Console.ReadLine();


            // Add the user into the list database

            Save_User.Register(this);
            IsLoggedin = false;
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