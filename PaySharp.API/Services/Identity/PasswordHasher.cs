using PaySharp.API.Services.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PaySharp.API.Services.Identity
{
    public class PasswordHasher : IPasswordHasher
    {
        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
