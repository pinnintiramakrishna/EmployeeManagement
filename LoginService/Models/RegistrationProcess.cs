using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoginService.Models
{
    public class RegistrationProcess : IRegister
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string CreatePassword(RegistrationDetails registrationDetails)
        {
            string generatedPassword = CreateRandomPassword(registrationDetails.EmailAddress.Length);
           
            UserName = registrationDetails.UserName;
            Password = generatedPassword;

            return generatedPassword;
        }

        private string CreateRandomPassword(int length)
        {
            // Create a string of characters, numbers, and special characters that are allowed in the password
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string
            // and create an array of chars
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
