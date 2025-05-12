using System;
namespace Arriba_Eats
{
    public class Deliverer : User
    {
        public Location AddressCoordinates { get; set; }
        private string licence_plate;

        public Deliverer(string licence_plate) : base("", 0, "", "", "", false)
        {
            AddressCoordinates = new Location(0, 0);
            this.licence_plate = licence_plate;
        }

        public string Licence_plate
        {
            get { return this.licence_plate; }
        }

        public override void SignUp()
        {
            Console.WriteLine("=== Customer Sign Up ===");

            Console.Write("Enter your licence plate: ");
            string licence_plate = Console.ReadLine();

            Console.Write("Enter your name: ");
            string name1 = Console.ReadLine();

            Console.Write("Enter your age: ");
            int Age = int.Parse(Console.ReadLine());

            Console.Write("Enter your email: ");
            string Email = Console.ReadLine();


            Console.Write("Enter your mobile number: ");
            string MobileNumber = Console.ReadLine();

            Console.Write("Enter your password: ");
            string Password = Console.ReadLine();

            Console.Write("Enter your X coordinate: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Enter your Y coordinate: ");
            double y = double.Parse(Console.ReadLine());

            AddressCoordinates = new Location(x, y);
            IsLoggedin = false;

            Console.WriteLine("Sign-up successful.\n");
        }





    }








}