using Arriba_Eats;

public static class SignUpMenu
{
    public static void SignUp()
    {

        Console.WriteLine("Which type of user would you like to register as?");
        Console.WriteLine("1: Customer");
        Console.WriteLine("2: Deliverer");
        Console.WriteLine("3: Client");
        Console.WriteLine("4: Return to the previous menu");
        Console.WriteLine("Please enter a choice between 1 and 4:");

        int roleChoice;
        while (!int.TryParse(Console.ReadLine(), out roleChoice) || roleChoice < 1 || roleChoice > 4)
        {
            Console.WriteLine("Invalid choice.");    
            Console.WriteLine("Please enter a choice between 1 and 4:");
        }

        // Common user details
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Please enter your age (18-100):");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter your email address:");
        string email = Console.ReadLine();

        Console.WriteLine("Please enter your mobile phone number:");
        string mobileNumber = Console.ReadLine();

        Console.WriteLine("Your password must:\r\n- be at least 8 characters long\r\n- contain a number\r\n- contain a lowercase letter\r\n- contain an uppercase letter\r\nPlease enter a password:");    
        string password = Console.ReadLine();
        Console.WriteLine("Please confirm your password: ");
        string password2 = Console.ReadLine();
        if (password != password2)
        {
            Console.WriteLine("Passwords do not match.");
        }

       User user = null;

        switch (roleChoice)
        {
            case 1: // Customer
                user = new Customer(name, age, email, mobileNumber, password);
                break;

            case 2: // Deliverer
                user = new Deliverer(name, age, email, mobileNumber, password);
                break;

            case 3: // Client
                user = new Client(name, age, email, mobileNumber, password);
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

    }
}
