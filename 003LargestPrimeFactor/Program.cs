using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestPrimeFactor
{
    // 3. The prime factors of 13195 are 5, 7, 13 and 29.
    // What is the largest prime factor of the number 600851475143 ?
    class Program
    {
        private const long Number = 600851475143;

        static void Main()
        {
            long largestPrimeFactor = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                largestPrimeFactor = FindPrimeFactorsNumber(Number).Max();
            });


            Console.WriteLine("Largest prime factor " + string.Join(", ", largestPrimeFactor) + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static IEnumerable<long> FindPrimeFactorsNumber(long number)
        {
            // Print the number of 2s that divide n
            while (number % 2 == 0)
            {
                yield return 2;
                number = number / 2;
            }

            // n must be odd at this point.  So we can skip one element (Note i = i +2)
            for (int i = 3; i <= Math.Sqrt(number); i = i + 2)
            {
                // While i divides n, print i and divide n
                while (number % i == 0)
                {
                    yield return i;
                    number = number / i;
                }
            }

            // This condition is to handle the case whien n is a prime number
            // greater than 2
            if (number > 2)
                yield return number;
        }
    }
}
