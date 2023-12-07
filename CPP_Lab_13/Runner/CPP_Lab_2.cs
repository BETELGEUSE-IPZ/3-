using System;
using System.IO;
using System.Linq;

namespace Lab4Classes
{
    public class Lab2
    {
        public static string RunLab(string input)
        {
            File.WriteAllText("INPUT2.TXT", input);

            using (StreamReader sr = new StreamReader("INPUT2.TXT"))
            {
                var nm = sr.ReadLine()?.Split().Select(s =>
                {
                    if (!int.TryParse(s, out int result))
                    {
                        throw new FormatException("Could not convert string to number.");
                    }
                    return result;
                }).ToArray();

                if (nm == null || nm.Length < 2)
                {
                    throw new InvalidDataException("Incorrect input data in the first line.");
                }

                int n = nm[0];
                int m = nm[1];

                var suppliers = new (int, int)[m];

                for (int i = 0; i < m; i++)
                {
                    var ab = sr.ReadLine()?.Split().Select(s =>
                    {
                        if (!int.TryParse(s, out int result))
                        {
                            throw new FormatException("Could not convert string to number.");
                        }

                        return result;
                    }).ToArray();

                    if (ab == null || ab.Length < 2)
                    {
                        throw new InvalidDataException($"Incorrect input data in the string {i + 2}.");
                    }

                    suppliers[i] = (ab[0], ab[1]);
                }

                suppliers = suppliers.OrderBy(x => x.Item1 == 0 ? double.MaxValue : (double)x.Item2 / x.Item1).ToArray();

                long[] dp = new long[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    dp[i] = long.MaxValue;
                }

                foreach (var supplier in suppliers)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (dp[j] == long.MaxValue) continue;
                        int needPairs = Math.Min(supplier.Item1, n - j);
                        dp[j + needPairs] = Math.Min(dp[j + needPairs], dp[j] + supplier.Item2);
                    }
                }

                return $"{(dp[n] == long.MaxValue ? -1 : dp[n])}";
            }
        }
    }
}
