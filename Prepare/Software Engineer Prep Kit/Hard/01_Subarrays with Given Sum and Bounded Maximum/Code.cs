using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Hard._01_Subarrays_with_Given_Sum_and_Bounded_Maximum
{
    internal class Code
    {
        public static long countSubarraysWithSumAndMaxAtMost(List<int> nums, long k, long M)
        {
            long result = 0;
            int count = nums.Count;

            for(var x=0; x < count; x++)
            {
                long sum = 0;
                for (var y = x; y < count; y++)
                {
                    var current = nums[y];
                    if (current > M)
                        break;

                    sum += current;
                    if (sum == k)
                        result++;
                }
            }

            return result;
        }
    }

    public class Tests
    {
        [TestCase(new []{2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] {5 }, 5, 5, 1)]

        [TestCase(new[] { 1, 2,-1, 1 }, 3, 2, 2)]
        public void Test(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost([.. nums], k, m); 

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
