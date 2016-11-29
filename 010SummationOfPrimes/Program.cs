using Euler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _010SummationOfPrimes
{
    class Program
    {
        private const int Limit = 2000000;

        static void Main()
        {
            long sum = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                sum = SumPrimesBelowLimit(Limit);
            });


            Console.WriteLine("Sum of all the primes: " + sum.ToString() + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static long SumPrimesBelowLimit(int limit)
        {
            IEnumerable<long> primes = PrimesUtility.GeneratePrimesBelowUpperLimit(limit);

            return primes.Sum();
        }
    }
}
