using Euler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _00710001stPrime
{
    //7. By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    //What is the 10 001st prime number?
    class Program
    {
        private static int limit = 10001;

        static void Main()
        {
            List<int> primeMax = new List<int>();

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                primeMax = PrimesUtility.GenerateSpecificNumberOfPrimes(limit);
            });


            Console.WriteLine("10 001st prime: " + primeMax.Last() + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }


    }
}
