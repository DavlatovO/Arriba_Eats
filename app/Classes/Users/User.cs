using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents the base class for all user types in the Arriba Eats system.
    /// Contains common user properties and authentication logic.
    /// </summary>
    public abstract class User
    {
        private string name;
        private int age;
        private string email;
        private string mobile_number;
        private string password;
        private bool isloggedin;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">User's full name.</param>
        /// <param name="age">User's age.</param>
        /// <param name="email">User's email address.</param>
        /// <param name="mobile_number">User's mobile number.</param>
        /// <param name="password">User's password.</param>
        public User(string name, int age, string email, string mobile_number, string password)
        {
            // Optional: Add null/empty checks and validation here
            this.name = name;
            this.age = age;
            this.email = email;
            this.mobile_number = mobile_number;
            this.password = password;
        }

        /// <summary>
        /// Gets or sets the user's mobile number.
        /// </summary>
        public string Mobile_Number
        {
            get { return mobile_number; }
            set { mobile_number = value; }
        }

        /// <summary>
        /// Gets or sets the user's age.
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Gets or sets the user's login status.
        /// </summary>
        public bool IsLoggedin
        {
            get { return isloggedin; }
            set { isloggedin = value; }
        }

        /// <summary>
        /// Attempts to log in the user with the given email and password.
        /// </summary>
        /// <param name="email">The email address entered.</param>
        /// <param name="password">The password entered.</param>
        /// <returns>True if credentials match and login is successful; otherwise, false.</returns>
        public virtual bool Login(string email, string password)
        {
            
            if (Email == email && Password == password)
            {
                isloggedin = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Logs out the user if currently logged in.
        /// </summary>
        public virtual void Logout()
        {
            if (isloggedin)
            {
                isloggedin = false;
                Console.WriteLine("You are now logged out.");
            }
            else
            {
                Console.WriteLine("Please log in the system first.");
            }
        }

        /// <summary>
        /// Abstract method to be implemented by derived classes for handling user sign-up.
        /// </summary>
        public abstract void SignUp();

        /// <summary>
        /// Abstract method to return user details in string format.
        /// </summary>
        /// <returns>Details about the user as a string.</returns>
        public abstract string Details();
    }
}
