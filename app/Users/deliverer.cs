
using System;
namespace Arriba_Eats
{
    public class Deliverer : User
    {
        public Location AddressCoordinates { get; set; }
        private string licence_plate;
        private DelivererStatus status;

        private Order? order;



        public Deliverer() : base("", 0, "", "", "", false)
        {
            AddressCoordinates = new Location(0, 0);
            licence_plate = "";
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

            Console.Write("Enter your licence plate: ");
            licence_plate = Console.ReadLine();

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