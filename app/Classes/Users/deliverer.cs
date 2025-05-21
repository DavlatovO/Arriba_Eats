
using System;
namespace Arriba_Eats
{
    public class Deliverer : User
    {
        public Location AddressCoordinates { get; set; }
        private string licence_plate;
        private DelivererStatus status;

        private Order? order;



        public Deliverer(string name, int age, string email, int mobile_number, string password) : base(name, age, email, mobile_number, password)
        {
            AddressCoordinates = new Location(0,0);
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

            Console.Write("Please enter your licence plate:");
            licence_plate = Console.ReadLine();

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