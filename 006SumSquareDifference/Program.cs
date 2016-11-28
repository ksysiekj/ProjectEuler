using System;

namespace _006SumSquareDifference
{
    //6. The sum of the squares of the first ten natural numbers is,
    //12 + 22 + ... + 102 = 385
    //The square of the sum of the first ten natural numbers is,
    //(1 + 2 + ... + 10)2 = 552 = 3025
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    class Program
    {
        private static int Limit = 100;

        static void Main()
        {
            long sumSquareDifference = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                sumSquareDifference = Run(Limit);
            });


            Console.WriteLine("Sum square difference " + sumSquareDifference + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static long Run(int limit)
        {
            return (limit - 1) * limit * (limit + 1) * (3 * limit + 2) / 12;
        }
    }
}
