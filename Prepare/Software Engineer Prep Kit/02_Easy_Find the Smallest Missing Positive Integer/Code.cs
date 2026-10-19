using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit._02_Easy_Find_the_Smallest_Missing_Positive_Integer
{
    internal class Code
    {
        public static int findSmallestMissingPositive(List<int> orderNumbers)
        {
            int result = 0;

            

            return result;
        }
    }

    public class Tests()
    {
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 1 }, 2)]

        public void Test(int[] input, int expectedOutput) =>
            Assert.That(
                Code.findSmallestMissingPositive([.. input]),
                Is.EqualTo(expectedOutput));
    }
}
