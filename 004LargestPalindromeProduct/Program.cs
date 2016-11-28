using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestPalindromeProduct
{

    // 4. A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    // Find the largest palindrome made from the product of two 3-digit numbers.
    class Program
    {
        static void Main()
        {

            int maxPalidrom = 0;

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                maxPalidrom = Run().Max();
            });


            Console.WriteLine("Largest palidrom " + maxPalidrom + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static IEnumerable<int> Run()
        {
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    int result = i * j;
                    if (IsPalidrome2(result))
                    {
                        yield return result;
                    }
                }
            }
        }

        private static bool IsPalidrome(int number)
        {
            char[] chars = number.ToString().ToArray();
            int length = chars.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (chars[i] != chars[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPalidrome2(int number)
        {
            int n = number;
            int rev = 0;
            while (number > 0)
            {
                int dig = number % 10;
                rev = rev * 10 + dig;
                number = number / 10;
            }

            return n == rev;
        }
    }
}
