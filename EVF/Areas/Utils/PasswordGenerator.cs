using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using SecurityDriven.Core;
using System.Security.Cryptography;

namespace EVF.Admin.Areas.Utils
{
    public class PasswordGenerator
    {
        public PasswordGenerator() { }
        public static string GenerateRandomPassword(UserManager<UserInfo> userManager)
        {


            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "#@!"                       // non-alphanumeric
            };
            CryptoRandom rand = new CryptoRandom();
            List<char> chars = new List<char>();
            
            if (userManager.Options.Password.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (userManager.Options.Password.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (userManager.Options.Password.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (userManager.Options.Password.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < userManager.Options.Password.RequiredLength
                || chars.Distinct().Count() < userManager.Options.Password.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

    }
}
