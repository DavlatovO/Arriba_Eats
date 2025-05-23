using Arriba_Eats;

/// <summary>
/// Provides the sign-up menu and handles user registration for different user roles.
/// </summary>
public static class SignUpMenu
{
    /// <summary>
    /// Displays the sign-up menu, collects user information, validates input, and registers a new user.
    /// </summary>
    public static void SignUp()
    {
        try
        {
            // Display user role options
            Console.WriteLine("Which type of user would you like to register as?");
            Console.WriteLine("1: Customer");
            Console.WriteLine("2: Deliverer");
            Console.WriteLine("3: Client");
            Console.WriteLine("4: Return to the previous menu");
            Console.WriteLine("Please enter a choice between 1 and 4:");

            int roleChoice;
            // Validate role selection input
            while (!int.TryParse(Console.ReadLine(), out roleChoice) || roleChoice < 1 || roleChoice > 4)
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Please enter a choice between 1 and 4:");
            }

            // Collect and validate user's name
            // Name must contain only letters, spaces, apostrophes, or hyphens
            string name;
            while (true)
            {
                string? input;
                while (true)
                {
                    Console.WriteLine("Please enter your name:");
                    input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input))
                    {
                        name = input;
                        break;
                    }

                    Console.WriteLine("Invalid name.");
                }

                    if (!string.IsNullOrWhiteSpace(name) &&
                    name.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-'))
                {
                    break;
                }
                Console.WriteLine("Invalid name.");
            }

            // Collect and validate user's age (must be between 18 and 100)
            int age;
            while (true)
            {
                Console.WriteLine("Please enter your age (18-100):");
                if (int.TryParse(Console.ReadLine(), out age) && age >= 18 && age <= 100)
                    break;

                Console.WriteLine("Invalid age.");
            }

            // Collect and validate user's email address
            // Email must have exactly one '@', and not be a duplicate
            string email;
            while (true)
            {
                Console.WriteLine("Please enter your email address:");
                string? input;
                while (true)
                {
                    input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        email = input;
                        break;
                    }

                    Console.WriteLine("Name cannot be empty. Please try again.");
                }

                bool isValidFormat = !string.IsNullOrWhiteSpace(email) &&
                                     email.Count(c => c == '@') == 1 &&
                                     email.IndexOf('@') > 0 &&
                                     email.IndexOf('@') < email.Length - 1;
                bool isDuplicate = false;
                try
                {
                    // Check for duplicate email in existing users
                    isDuplicate = Save_User.GetAllUsers().Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while checking for duplicates: {ex.Message}");
                    return;
                }
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

            // Collect and validate user's mobile number
            // Mobile number must be exactly 10 digits and start with zero
            string mobileNumber;
            while (true)
            {
                Console.WriteLine("Please enter your mobile phone number:");
                mobileNumber = Console.ReadLine()!;

                if (mobileNumber.Length == 10 &&
                    mobileNumber[0] == '0' &&
                    mobileNumber.All(char.IsDigit))
                {
                    break;
                }
                Console.WriteLine("Invalid phone number.");
            }

            // Collect and validate user's password
            // Password must be at least 8 characters, contain upper and lower case letters, and a digit
            string password;
            while (true)
            {
                Console.WriteLine("Your password must:\r\n- be at least 8 characters long\r\n- contain a number\r\n- contain a lowercase letter\r\n- contain an uppercase letter\r\nPlease enter a password:");
                password = Console.ReadLine()!;

                bool hasUpper = password.Any(char.IsUpper);
                bool hasLower = password.Any(char.IsLower);
                bool hasDigit = password.Any(char.IsDigit);

                if (password.Length >= 8 && hasUpper && hasLower && hasDigit)
                {
                    Console.WriteLine("Please confirm your password: ");
                    string password2 = Console.ReadLine()!;

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

            // User object to be created based on selected role
            User user = null;
            try
            {   
                // Create the user based on the selected role
                // Each user type constructor should accept (name, age, email, mobileNumber, password)
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

                    case 4: // Cancel and return to previous menu
                        Console.WriteLine("Returning to previous menu.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                // Call the SignUp method for the specific user type to gather any additional info
                user.SignUp();
            }
            catch (Exception ex)
            {
                // Handle errors during user creation
                Console.WriteLine($"An error occurred while creating the user: {ex.Message}");
                return;
            }
            
        }
        catch (Exception ex)
        {
            // Handle general errors in the sign-up process
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}   
