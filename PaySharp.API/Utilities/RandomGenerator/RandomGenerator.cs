using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PaySharp.API.Utilities.RandomGenerator
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly IConfiguration config;

        public RandomGenerator(IConfiguration config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public string GenerateNumber(int min, int max, int amount)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException("", config.GetSection("GlobalConstants:MIN_MAX").Value);
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("", config.GetSection("GlobalConstants:AMOUNT_NEGATIVE").Value);
            }
            if (min == max)
            {
                return min.ToString();
            }
            using (var rng = new RNGCryptoServiceProvider())
            {
                var number = new StringBuilder();
                var data = new byte[16];
                for (int i = 0; i < amount; i++)
                {
                    rng.GetBytes(data);

                    var generatedNumber = Math.Abs(BitConverter.ToUInt16(data, startIndex: 0));

                    int diff = max - min;
                    int mod = generatedNumber % diff;
                    int normalizedValue = min + mod;
                    number.Append(normalizedValue.ToString());
                }
                return number.ToString();
            }
        }
    }
}
