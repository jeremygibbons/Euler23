using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler23
{
    class Program
    {
        static List<int> abundants;

        static int[] integers;

        static void Main(string[] args)
        {
            abundants = new List<int>();
            integers = new int[28124];

            List<int> SumsOfAbundants = new List<int>();

            FindAbundantNumbersBelowN(28111); //Smallest abundant num is 12, so limit is 28123 - 12

            int sum = 0;
            foreach(int n in Enumerable.Range(1, 28123))
            {
                if(integers[n] == 0)
                    sum += n;
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static void FindAbundantNumbersBelowN(int n)
        {

            foreach(int i in Enumerable.Range(1, n))
            {
                if(GetSumOfProperDivisors(i) > 2 * i )
                {
                    abundants.Add(i);
                    foreach(int a in abundants)
                    {
                        if (a + i > 28123)
                            continue;
                        integers[a + i] = 1;
                    }
                }
            }
        }

        private static int GetSumOfProperDivisors(int n)
        {
            int sq = (int)Math.Sqrt(n);
            HashSet<int> divisors = new HashSet<int>();

            for (int i = 1; i <= sq; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }
            return divisors.Sum();
        }
    }
}
