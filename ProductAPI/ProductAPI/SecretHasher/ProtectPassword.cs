﻿using Humanizer;
using System.Security.Cryptography;

namespace ProductAPI.SecretHasher
{
    public static class ProtectPassword
    {
        private const int _saltSize = 16; // 128 bits
        private const int _keySize = 32; // 256 bits
        private const int _iterations = 50000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';

        public static byte[] Salt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            return salt;
        }
        public static string Hash(string input)
        {
            var salt = Salt();
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }

        public static bool Verify(string input, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        /*
             // Hash:
            string password = "...";
            string hashed = SecretHasher.Hash(password);

            // Verify:
            string enteredPassword = "...";
            bool isPasswordCorrect = SecretHasher.Verify(enteredPassword, hashed);
         */
    }
}
