
using System;
namespace Arriba_Eats
{
    public class Deliverer : User
    {
        public Location AddressCoordinates { get; set; }
        private string licence_plate;

        public Deliverer() : base("", 0, "", "", "", false)
        {
            AddressCoordinates = new Location(0, 0);
            licence_plate = "";
        }

        public string Licence_plate
        {
            get { return licence_plate; }
        }

        public override void SignUp()
        {
            Console.WriteLine("=== Customer Sign Up ===");

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

            Console.Write("Enter restaurant location (X,Y): ");
            string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
            string[] parts = input.Split(',');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y))
            {
                Console.WriteLine("Invalid location.");
                return;
            }

            AddressCoordinates = new Location(x, y);
            // Add the user into the list database
            Save_User.Register(this);
            IsLoggedin = false;

            Console.WriteLine("Sign-up successful.\n");
            Console.WriteLine();
        }





    }








}