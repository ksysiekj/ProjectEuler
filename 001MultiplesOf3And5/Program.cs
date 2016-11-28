using System;
using System.Linq;

namespace MultiplesOf3And5
{
    // 1. If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    // Find the sum of all the multiples of 3 or 5 below 1000.
    class Program
    {
        private const int Three = 3;
        private const int Five = 5;
        private const int Fifteen = Three * Five;
        private const int Limit = 1000;

        static void Main()
        {
            int sum = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                sum = Run(Limit);
            });


            Console.WriteLine("Sum of 3,5 dividers equals " + sum + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static int Run(int maxValue)
        {
            int sum = Enumerable.Range(1, maxValue - 1)
                //.AsParallel()
                .Where(q => ((q % Three == 0 || q % Five == 0) && q % Fifteen != 0) || q % Fifteen == 0)
                .Sum();

            return sum;
        }
    }
}
