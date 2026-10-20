using NUnit.Framework;
using System.Runtime.InteropServices;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Hard._01_Subarrays_with_Given_Sum_and_Bounded_Maximum
{
    internal class Code
    {
        public static long countSubarraysWithSumAndMaxAtMost_slow(List<int> nums, long k, long M)
        {
            long result = 0;
            int count = nums.Count;

            for (var x = 0; x < count; x++)
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

        internal static int processSpan(ReadOnlySpan<int> nums, long k)
        {
            if (nums.Length == 1) return nums[0] == k ? 1 : 0;

            int result = 0;

            for (var x = 0; x < nums.Length; x++)
            {
                int sum = 0;
                for (var y = x; y < nums.Length; y++)
                {
                    var current = nums[y];

                    sum += current;
                    if (sum == k)
                        result++;
                }
            }

            return result;
        }

        public static long countSubarraysWithSumAndMaxAtMost(List<int> nums, long k, long M)
        {
            long result = 0;

            var array = CollectionsMarshal.AsSpan(nums);

            int spanStart = 0;
            for (var x = 0; x < array.Length; x++)
            {
                if (nums[x] > M)
                {
                    if (x == spanStart)
                    {
                        spanStart++;
                        continue;
                    }

                    if (spanStart <= (x - 1))
                    {
                        result += processSpan(array[spanStart..x], k);
                        spanStart = x + 1;
                    }
                }

                if (x == array.Length-1)
                    result += processSpan(array[spanStart..], k);
            }

            return result;
        }


        public static long countSubarraysWithSumAndMaxAtMost_2(List<int> nums, long k, long M)
        {
            long result = 0;

            int sum;
            for (var x = 0; x < nums.Count; x++)
            {
                if (nums[x] > M)
                    continue;

                if (nums[x] == k)
                    result++;

                sum = nums[x];
                for (var y = x + 1; y < nums.Count; y++)
                {
                    if (nums[y] > M)
                        break;

                    sum += nums[y];
                    if (sum == k)
                        result++;

                    //if (sum > M)
                    //  continue;
                }
            }

            return result;
        }
    }

    public class Tests
    {
        [TestCase(new[] { 2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] { 5 }, 5, 5, 1)]
        [TestCase(new[] { 1, 2, -1, 1 }, 3, 2, 2)]
        public void Test(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost([.. nums], k, m);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}


