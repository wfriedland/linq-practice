using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice
{
    class Program
    {

        //
        // A set of distinct elements are generated
        //
        static void DistinctExample()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 , 5,5,5,5,5,2, 2, 2, 2, 2, 2, 2, 2, 2, 2};

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Distinct members of the array: (Distinct)");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }

        // 
        // Groups are created for every letter that starts an element in a set
        // Please note that A and a are two seperate sets
        //
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

        // 
        //  A set of elements in setA and not in setB is created
        //
        static void ExceptExample()
        {
            int[] numbersA = { 0, 1, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("Numbers in first array but not second array: (Except)");
            foreach (var n in aOnlyNumbers)
            {
                Console.WriteLine(n);
            }
        }

        //
        // A set of intersecting elements of two sets are created
        //
        static void IntersectExample()
        {
            int[] numbersA = { 0, 1, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> abNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Numbers in both first and second array: (Intersect)");
            foreach (var n in abNumbers)
            {
                Console.WriteLine(n);
            }

        }

        //
        // The union of two set are created
        //
        static void unionExample()
        {
            int[] numbersA = { 0, 1, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> abNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Numbers in first array or second array (Union):");
            foreach (var n in abNumbers)
            {
                Console.WriteLine(n);
            }
        }

        //
        // The set of numbers less than 5 is sorted in descending order
        //
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

        //
        // Created mini dictionary that contains a string label, and a boolean value.
        //
        static void miniDictionary()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens =
                from n in numbers
                select new { Digit = strings[n], Even = (n % 2 == 0) };

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine("The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
            }
        }

        //
        // This function uses the anonymous function syntax. I am not sure if that is the term use
        // by the public, but it is not the sql like syntax that I am so used to.
        //
        static void inPlace()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
            }
        }


        static void Main(string[] args)
        {
            GroupByFirstLetter();
            DistinctExample();
            ExceptExample();
            unionExample();
            IntersectExample();
            lessThan();
            miniDictionary();
            inPlace();


        }
    }
}
