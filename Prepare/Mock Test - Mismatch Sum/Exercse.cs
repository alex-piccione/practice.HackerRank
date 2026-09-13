using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Prepare.Mock_Test___Mismatch_Sum
{
    class Result
    {
        /*
         * Complete the 'countDifferences' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. STRING str1
         *  2. STRING str2
         */

        /* This solutin psed 10 tests i HackerRank butfailed the remanig 6 or 7 fr timeout */
        public static long CountDifferences_1(string str1, string str2)
        {
            int len = str1.Length;
            var s1 = str1.AsSpan();
            var s2 = str2.AsSpan();
            var counter = 0;

            for (var i = 0; i <= str2.Length - len; i++)
            {
                var sub = s2[i..(i + len)];
                for (var y = 0; y < len; y++)
                    if (sub[y] != s1[y])
                        counter++;
            }

            return counter;
        }

        public static long CountDifferences(string str1, string str2)
        {
            /*
              I can compare The goal is to compare the str1 over the subs of str2, that is sliding a number of characters in str2 and compare the string with str1.
 Instead of compare the whole str1 over the sub in str2... I can compare just each character in str1 with each character is str2.
 The total amount of comparison is the same, but I know that there are only "0" and "1" in str1, so I can just compare them and multiply the found diff for the numbre of that character in str1 !
            */
            return 0;
        }
    }
}
