using System;
using System.IO;
using System.Numerics;

namespace Lab4Classes
{
    public class Lab1
    {
        public static string RunLab(string input)
        {
            BigInteger N;

            if (!BigInteger.TryParse(input, out N) || N <= 0)
            {
                throw new ArgumentException("Input must be a positive integer.");
            }

            int numberOfOnes = 3;
            int bitPosition = 256;

            BigInteger result = 0;

            while (numberOfOnes > 0 && bitPosition > 0)
            {
                BigInteger combinations = BinomialCoeff(bitPosition - 1, numberOfOnes);

                if (N > combinations)
                {
                    result |= BigInteger.One << (bitPosition - 1);
                    N -= combinations;
                    numberOfOnes--;
                }

                bitPosition--;
            }

            if (numberOfOnes > 0)
            {
                return "Not enough bits to represent a number with 3 bits.";
            }

            return result.ToString();
        }

        static BigInteger BinomialCoeff(int n, int k)
        {
            BigInteger result = 1;

            if (k > n) return 0;

            for (int i = n; i > n - k; i--)
            {
                result *= i;
            }

            for (int i = 1; i <= k; i++)
            {
                result /= i;
            }
            return result;
        }
    }
}
