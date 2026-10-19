using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Hard._01_Subarrays_with_Given_Sum_and_Bounded_Maximum
{
    internal class Code
    {

        public static long countSubarraysWithSumAndMaxAtMost(List<int> nums, long k, long M)
        {
            return 0L;

        }
    }

    public class Tests
    {
        [TestCase(new []{2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        public void Test(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost(nums.ToList(), k, m); 

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
