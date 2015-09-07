using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler23
{
    class Program
    {
        static List<int> abundants;
        static List<int> NotSumOfAbundants;

        static void Main(string[] args)
        {
            abundants = new List<int>();
            NotSumOfAbundants = new List<int>();

            FindAbundantNumbersBelowN(28111); //Smallest abundant num is 12, so limit is 28123 - 12

            foreach(int n in Enumerable.Range(1, 28123))
            {
                if (CheckIfNIsSumOfAbundants(n) == false)
                    NotSumOfAbundants.Add(n);
            }
            Console.WriteLine(NotSumOfAbundants.Sum());
            Console.ReadLine();
        }

        private static bool CheckIfNIsSumOfAbundants(int n)
        {
            foreach(int a in abundants)
            {
                if (a > n)
                    return false;
                if (abundants.Contains(n - a))
                    return true;
            }
            return false;
        }

        private static void FindAbundantNumbersBelowN(int n)
        {

            foreach(int i in Enumerable.Range(1, n))
            {
                if(GetSumOfProperDivisors(i) > i )
                {
                    abundants.Add(i);
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
            divisors.Remove(n);
            return divisors.Sum();
        }
    }
}
