using System;
using System.Security.Cryptography;

namespace BirackiSpisakDataManager.Helpers
{
    public static class Password
    {
        private const int saltSize = 32;
        private const int hashSize = 20;
        private const int loopCount = 10000;

        public static string MakeHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, loopCount);
            var hash = pbkdf2.GetBytes(hashSize);

            var saltedHash = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, saltedHash, 0, saltSize);
            Array.Copy(hash, 0, saltedHash, saltSize, hashSize);

            return Convert.ToBase64String(saltedHash);
        }

        public static bool Compare(string password, string hash)
        {
            var decoded = Convert.FromBase64String(hash);

            var salt = new byte[saltSize];
            Array.Copy(decoded, 0, salt, 0, saltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, loopCount);
            byte[] DbHash = pbkdf2.GetBytes(hashSize);

            for (var i = 0; i < hashSize; i++)
            {
                if (decoded[i + saltSize] != DbHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
