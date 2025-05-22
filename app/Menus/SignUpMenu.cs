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
            // Name: must have at least one letter and only letters, spaces, apostrophes, hyphens
            string name;
            while (true)
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name) &&
                    name.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-'))
                {
                    break;
                }
                Console.WriteLine("Invalid name.");
            }

            // Age: must be integer between 18 and 100 inclusive
            int age;
            while (true)
            {
                Console.WriteLine("Please enter your age (18-100):");
                if (int.TryParse(Console.ReadLine(), out age) && age >= 18 && age <= 100)
                    break;

                Console.WriteLine("Invalid age.");
            }

            // Email: must contain exactly one '@' and at least one character before and after
            string email;
            while (true)
            {
                Console.WriteLine("Please enter your email address:");
                email = Console.ReadLine();

                bool isValidFormat = !string.IsNullOrWhiteSpace(email) &&
                                     email.Count(c => c == '@') == 1 &&
                                     email.IndexOf('@') > 0 &&
                                     email.IndexOf('@') < email.Length - 1;

                bool isDuplicate = Save_User.GetAllUsers().Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (!isValidFormat)
                {
                    Console.WriteLine("Invalid email address.");
                }
                else if (isDuplicate)
                {
                    Console.WriteLine("This email address is already in use.");
                }
                else
                {
                    break;
                }
            }


            // Mobile number: exactly 10 digits starting with zero
             string mobileNumber;
            while (true)
            {
                Console.WriteLine("Please enter your mobile phone number:");
                mobileNumber = Console.ReadLine();

                if (mobileNumber.Length == 10 &&
                    mobileNumber[0] == '0' &&
                    mobileNumber.All(char.IsDigit))
                {
                    break;
                }
                Console.WriteLine("Invalid phone number.");
            }

            // Password: at least 8 chars, contain number, uppercase and lowercase letters; confirm matching
            string password;
            while (true)
            {
                Console.WriteLine("Your password must:\r\n- be at least 8 characters long\r\n- contain a number\r\n- contain a lowercase letter\r\n- contain an uppercase letter\r\nPlease enter a password:");
                password = Console.ReadLine();

                bool hasUpper = password.Any(char.IsUpper);
                bool hasLower = password.Any(char.IsLower);
                bool hasDigit = password.Any(char.IsDigit);

                if (password.Length >= 8 && hasUpper && hasLower && hasDigit)
                {
                    Console.WriteLine("Please confirm your password: ");
                    string password2 = Console.ReadLine();

                    if (password == password2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid password.");
                }
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
