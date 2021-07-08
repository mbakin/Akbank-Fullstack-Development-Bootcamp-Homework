using CreatePassword.PasswordExtension;
using System;

namespace CreatePassword
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please create username : ");
            string input = Console.ReadLine();
            Console.WriteLine("For your security, the system will generate a one-time password for you.");

            Random random = new Random();
            string Password = random.CreatePassword();
            string GeneratePassword = string.Empty;

            while(GeneratePassword.Length < 6)
            {
                GeneratePassword += random.CreatePassword();
            }
            Console.WriteLine("Password : {0}", GeneratePassword);
        }
    }
}
