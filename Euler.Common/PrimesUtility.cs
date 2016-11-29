using System;
using System.Collections;
using System.Collections.Generic;

namespace Euler.Common
{
    public static class PrimesUtility
    {
        public static IEnumerable<long> GeneratePrimesBelowUpperLimit(int limit)
        {
            if (limit < 2) yield break;
            yield return 2;
            if (limit < 3u) yield break;
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

        public static List<int> GenerateSpecificNumberOfPrimes(int cnt)
        {
            List<int> primes = new List<int> { 2 };
            int nextPrime = 3;
            while (primes.Count <= cnt)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }
    }
}
