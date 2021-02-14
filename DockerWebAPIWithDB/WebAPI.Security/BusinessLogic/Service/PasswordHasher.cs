using DockerWebAPIWithDB.BusinessLogic.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;
using WebAPI.Security.BusinessLogic.Service;

namespace DockerWebAPIWithDB.BusinessLogic.WebAPI.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public PasswordHasher(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public (bool verified, bool needToBeUpgraded) Check(string hash, string password)
        {
            string[] keyParts = hash.Split(".");

            if (keyParts.Length != 3)
            {
                throw new FormatException("Unexpected has format. Format should be '{iterations}.{salt}.{hash}'");
            }

            var iterations = Convert.ToInt32(keyParts[0]);
            var salt = Convert.FromBase64String(keyParts[1]);
            var hashKey = Convert.FromBase64String(keyParts[2]);

            var needUpgrade = iterations != Options.Iterations;

            using var algorithm = new Rfc2898DeriveBytes(
                  password,
                  salt,
                  iterations,
                  HashAlgorithmName.SHA512);
            var keyToCheck = algorithm.GetBytes(KeySize);
            var verified = keyToCheck.SequenceEqual(hashKey);

            return (verified, needUpgrade);

        }

        public string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                  password,
                  SaltSize,
                  Options.Iterations,
                  HashAlgorithmName.SHA512);
            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{Options.Iterations}.{salt}.{key}";
        }
    }
}
