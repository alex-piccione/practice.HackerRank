using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit._02_Easy_Find_the_Smallest_Missing_Positive_Integer
{
    internal class Code
    {
        public static int findSmallestMissingPositive(List<int> orderNumbers)
        {
            var foundNumbers = new bool[orderNumbers.Count + 1];
            Array.Fill(foundNumbers, false);
            foundNumbers[0] = true;

            foreach (int n in orderNumbers)
                if (n <= orderNumbers.Count && n > 0)
                    foundNumbers[n] = true;

            var missing = Array.IndexOf(foundNumbers, false);
            if (missing == -1) return orderNumbers.Count + 1; // last found + 1
            return missing;
        }
    }

    public class Tests()
    {
        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { 1 }, 2)]
        [TestCase(new int[] { 3,4,-1, 1 }, 2)]
        [TestCase(new int[] { 1, 2, 4  }, 3)]
        [TestCase(new int[] { 1, 4, 2 }, 3)]
        [TestCase(new int[] { 2, 4, 1 }, 3)]
        public void Test(int[] input, int expectedOutput) =>
            Assert.That(
                Code.findSmallestMissingPositive([.. input]),
                Is.EqualTo(expectedOutput));
    }
}
