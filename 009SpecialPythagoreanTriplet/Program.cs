using System;

namespace _009SpecialPythagoreanTriplet
{
    // 9.   A Pythagorean triplet is a set of three natural numbers, a < b<c, for which,
    // a2 + b2 = c2
    // For example, 32 + 42 = 9 + 16 = 25 = 52.
    // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    // Find the product abc.
    class Program
    {
        static void Main()
        {
            Triangle triangle = new Triangle();

            double totalMiliSeconds = Euler.Common.MeasureTool.MeasureTotalMiliSeconds(() =>
            {
                triangle = FindTriangle();
            });


            Console.WriteLine("Found triangle: "
                + triangle.ToString() + ". Calculated in " + totalMiliSeconds + " ms");

            Console.Read();
        }

        private static Triangle FindTriangle()
        {
            int c = 1;
            for (int i = 1; i < 1000; i++)
            {
                for (int j = i + 2; j < 1000; j++)
                {
                    c = 1000 - i - j;
                    if (1000 * (500 - c) == i * j)
                    {
                        return new Triangle { A = i, B = j, C = c };
                    }
                }
            }

            throw new ArgumentException("unable to solve the puzzle");
        }
    }

    struct Triangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override string ToString()
        {
            return $"a={A}, b={B}, b={C}";
        }
    }
}
