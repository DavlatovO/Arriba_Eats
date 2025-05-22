using System;

namespace Arriba_Eats
{

    public abstract class User
    {
        private string name;
        private int age;
        private string email;
        private string mobile_number;
        private string password;
        private bool isloggedin;

        public User(string name, int age, string email, string mobile_number, string password)
        {
            this.name = name;
            this.age = age;
            this.email = email;
            this.mobile_number = mobile_number;
            this.password = password;
        }

        public string Mobile_Number
        {
            get { return mobile_number; }
            set { mobile_number = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get {return name;}
            set { name = value;}
        }

        public string Password 
        {
            get {return password;}
            set {if (value.Length>=8)
                    {password = value;}
                else 
                 {throw new Exception("Must be at least 8 characters long");}
            }
        }

        public string Email
        {
            get {return email;}
            set {email = value;}
        }

        public bool IsLoggedin
        {
            get {return isloggedin;}
            set {isloggedin = value;}
        }

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

        public virtual void Logout()
        {
            if (isloggedin)
            {
                isloggedin = false;
                Console.WriteLine($"You are now logged out.");
                
            }
            else 
            {
                Console.WriteLine("Please log in the system first.");
                
            }
        }

  
        public abstract void SignUp();
        public abstract string Details();

    }









}