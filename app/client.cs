using System;
namespace Arriba_Eats
{
    public class Client : User
    {
        public Location AddressCoordinates { get; set; }
        private string restaurant_name;
        private CuisineType cuisineStyle;



        public Client() : base("", 0, "", "", "", false)
        {
            restaurant_name = "";
            AddressCoordinates = new Location(0, 0);
            
        }

        public string Restaurant_name
        {
            get { return this.restaurant_name; }
        }

        public CuisineType CuisineStyle
        {
            get { return cuisineStyle; }
            set { this.cuisineStyle = value; }
        }

        public override void SignUp()
        {
            Console.WriteLine("=== Client Sign Up ===");

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

            Console.Write("Enter your restaurant name: ");
            restaurant_name = Console.ReadLine();

            Console.WriteLine("Select your cuisine style:");
            foreach (var style in Enum.GetValues(typeof(CuisineType)))
            {
                Console.WriteLine($"{(int)style} - {style}");
            }

            int styleChoice = int.Parse(Console.ReadLine());
            CuisineStyle = (CuisineType)styleChoice;

            Console.Write("Enter your X coordinate: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Enter your Y coordinate: ");
            double y = double.Parse(Console.ReadLine());

            AddressCoordinates = new Location(x, y);
            IsLoggedin = false;

            Console.WriteLine("Sign-up successful.\n");
        }

        public enum CuisineType
        {
            Italian,
            French,
            Chinese,
            Japanese,
            American,
            Australian
        }



    }








}