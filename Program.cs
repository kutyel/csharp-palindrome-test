using System;
using System.IO;
using System.Linq;

/*
The previous solution will not work because it will cause an "IndexOutOfBounds"
exception due to the second argument to the "Substring" method.
Besides, the implemented algorithm is case sensitive so if the words in the input file
are uppercase and lowercase it will not detect the palidromes correctly, for example: "Anna".
*/

namespace Palindrome
{
    public class Program
    {
        public static void Main()
        {
            int c = 0;
            string[] words = File.ReadAllLines("UKACD17.TXT");
            // By turning this array into a List, we could easily work with Linq and
            // use queries to operate over entities of the database instead of a static file.
            words.ToList().ForEach(word =>
            {
                // Also, by adding conditionals inside this block of code it would be easy
                // to check for other predicates besides being a palindrome.
                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                    c++;
                }
            });
            Console.WriteLine("Found {0} palindromes.", c);
            Console.ReadLine();
        }

        private static string Reverse(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        private static bool IsPalindrome(string s) => s.ToLower() == Reverse(s.ToLower());
    }
}
