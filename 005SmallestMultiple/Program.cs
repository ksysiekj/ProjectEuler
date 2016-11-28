using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _005SmallestMultiple
{
    // 5. 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    class Program
    {
        static void Main()
        {
            long smallestMultiple = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                smallestMultiple = Run(20);
            });


            Console.WriteLine("Smallest multiple " + smallestMultiple + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        static IEnumerable<int> GeneratePrimes(int limit)
        {
            if (limit < 2) yield break;
            yield return 2; if (limit < 3u) yield break;
            var BFLMT = (limit - 3u) / 2u;
            var SQRTLMT = ((int)(Math.Sqrt((double)limit)) - 3u) / 2u;
            var buf = new BitArray((int)BFLMT + 1, true);
            for (var i = 0u; i <= BFLMT; ++i) if (buf[(int)i])
                {
                    int p = (int)(3u + i + i); if (i <= SQRTLMT)
                    {
                        for (var j = (p * p - 3u) / 2u; j <= BFLMT; j += p)
                            buf[(int)j] = false;
                    }
                    yield return p;
                }
        }

        private static long Run(int limit)
        {
            IList<int> primes = GeneratePrimes(limit).ToList();
            IList<int> resultNumbers = new List<int>();
            IList<int> notPrimesFiltered = Enumerable.Range(2, limit - 1).ToList();
            int primesCount = primes.Count;
            for (int i = 0; i < primesCount; i++)
            {
                int prime = primes[i];
                while (notPrimesFiltered.Any(q => q % prime == 0))
                {
                    resultNumbers.Add(prime);
                    notPrimesFiltered = FilterOutNumbers(notPrimesFiltered, prime);
                }
                if (!notPrimesFiltered.Any())
                {
                    break;
                }
            }

            long result = 1;

            foreach (int prime in resultNumbers)
            {
                result *= prime;
            }

            return result;
        }

        private static IList<int> FilterOutNumbers(IList<int> notPrimesFiltered, int prime)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < notPrimesFiltered.Count; i++)
            {
                int number = notPrimesFiltered[i];

                if (number % prime != 0 && !result.Any(q => q == number))
                {
                    result.Add(number);
                    continue;
                }

                number /= prime;
                if (number != 1 && !result.Any(q => q == number))
                {
                    result.Add(number);
                }
            }

            return result;
        }


    }
}
