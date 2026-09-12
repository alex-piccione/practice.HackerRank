using NUnit.Framework;

namespace HackerRank.OLD_stuff
{
    internal class Coding_Mock_Interview_26_9
    {
        /*
         Given two strings, str1, and str2, where str1 contains exactly one character more than str2, find the indices of the characters in str1 that can be removed to make str1 equal to str2. Return the array of indices in increasing order. If it is not possible, return the array \[-1\]. 

**Note:** Use 0-based indexing.

**Example**

str1 = "abdgggda"

str2 = "abdggda"

Any "g" character at positions 3, 4, or 5 can be deleted to obtain str2. Return \[3, 4, 5\].
         */


        /*
 * Complete the 'getRemovableIndices' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts following parameters:
 *  1. STRING str1
 *  2. STRING str2
 */

        public static List<int> GetRemovableIndices_1(string str1, string str2)
        {
            List<int> result = new List<int>(str2.Length);

            var lastIndex = str1.Length - 1;
            for (var i = 0; i <= lastIndex; i++)
            {
                if (str1[0..i] + str1[(i + 1)..] == str2)
                    result.Add(i);
            }

            return result.Count == 0 ? [-1] : result;
        }

        public static List<int> GetRemovableIndices(string str1, string str2)
        {
            var result = new List<int>(str2.Length);

            var span1 = str1.AsSpan();
            var span2 = str2.AsSpan();
            for (var i = 0; i < str1.Length-1; i++)
            {
                if (span1[0..i].SequenceEqual(span2[0..i]) && span1[(i + 1)..].SequenceEqual(span2[i..]))
                    result.Add(i);
            }

            return result.Count == 0 ? [-1] : result;
        }

        // Two-pointer technique... to get a O(n) solution
    }


    public class Tests
    {
        [TestCase("aabbb", "aabb", new int[] { 2, 3 })]
        [TestCase("mmgghh", "mfggh", new int[] { -1 })]
        public void Test(string str1, string str2, int[] indexes)
        {
            var result = Coding_Mock_Interview_26.GetRemovableIndices(str1, str2);

            Assert.AreEqual(indexes, result);
        }
    }
}
