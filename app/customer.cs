using System;
namespace Arriba_Eats
{
    public class Customer: User
    {
        public Location AddressCoordinates {get; set;}

        public Customer(): base("", 0, "", "", "", false)
        {
            AddressCoordinates = new Location(0, 0);
        }

      

        public override void SignUp()
        {
            Console.WriteLine("=== Customer Sign Up ===");

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