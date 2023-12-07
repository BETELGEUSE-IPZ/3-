using System;

namespace Lab4Classes
{
    public static class Runner
    {
        public static string RunLab(int labNumber, string input)
        {
            switch (labNumber)
            {
                case 1:
                    return Lab1.RunLab(input);
                case 2:
                    return Lab2.RunLab(input);
                case 3:
                    return Lab3.RunLab(input);
                default:
                    throw new ArgumentException("Invalid lab number.");
            }
        }
    }

}