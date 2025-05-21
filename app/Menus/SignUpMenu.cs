using Arriba_Eats;

public static class SignUpHandler
{
    public static void SignUp()
    {
        Console.WriteLine("Which type of user would you like to register as?");
        Console.WriteLine("1: Customer");
        Console.WriteLine("2: Deliverer");
        Console.WriteLine("3: Client");
        Console.WriteLine("4: Cancel");

        int roleChoice = int.Parse(Console.ReadLine());

        // Common user details
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your mobile number: ");
        int mobileNumber = Int32.Parse(Console.ReadLine());

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        User user = null;

        switch (roleChoice)
        {
            case 1: // Customer
                user = new Customer
                {
                    Name = name,
                    Age = age,
                    Email = email,
                    Mobile_Number = mobileNumber,
                    Password = password
                };
                break;

            case 2: // Deliverer
                user = new Deliverer
                {
                    Name = name,
                    Age = age,
                    Email = email,
                    Mobile_Number = mobileNumber,
                    Password = password
                };
                break;

            case 3: // Client
                user = new Client
                {
                    Name = name,
                    Age = age,
                    Email = email,
                    Mobile_Number = mobileNumber,
                    Password = password
                };
                break;

            case 4: // Cancel
                Console.WriteLine("Returning to previous menu.");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        // Now call the SignUp method for the specific user type to gather any additional info
        user.SignUp();

        // Optionally, add the user to a database or in-memory collection
        Console.WriteLine("User successfully registered!");
    }
}
