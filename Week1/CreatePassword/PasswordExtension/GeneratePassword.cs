using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePassword.PasswordExtension
{
    public static class GeneratePassword
    {
        public static string CreatePassword(this Random random)
        {
            int generatePassword = random.Next(33, 126);
            string result = ((char)generatePassword).ToString();
            return result;
        }
    }
}
