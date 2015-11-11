using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice
{
    class Program
    {

        static void DistinctExample()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 , 5,5,5,5,5,2, 2, 2, 2, 2, 2, 2, 2, 2, 2};

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Distinct members of the factorsOf300 array:");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }
        static void GroupByFirstLetter()
        {
            string[] words = { "Apple", "application", "peach", "banana", "apple", "shirt" };

            var wGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(">>>"+w);
                }
            }
        }

        static void ExceptExample()
        {
            int[] numbersA = { 0, 1, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("Numbers in first array but not second array:");
            foreach (var n in aOnlyNumbers)
            {
                Console.WriteLine(n);
            }
        }

        static void unionExample()
        {
            int[] numbersA = { 0, 1, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> abNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Numbers in first array and second array:");
            foreach (var n in abNumbers)
            {
                Console.WriteLine(n);
            }
        }

        static void lessThan()
        {
            int[] numbers = {-1, -33, -4, 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lt5 =
                from n in numbers
                where n < 5
                orderby n descending
                select n;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lt5)
            {
                Console.WriteLine(x);
            }
        }


        static void Main(string[] args)
        {
            GroupByFirstLetter();
            DistinctExample();
            ExceptExample();
            unionExample();
            lessThan();


        }
    }
}
