using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Hard._01_Subarrays_with_Given_Sum_and_Bounded_Maximum
{
    internal class Code
    {
        // Too slow - O(n^2)
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

        // Use a Dictionary to store the previous parts sum accumulators from the position 0 to the current one.
        // That allows to quickly check if there is a previous subarray that the sum matches the target value.
        // Since the values can also be negative it is possible there are multiple valid subarrays (so a simple HashSet is not enough).
        public static long countSubarraysWithSumAndMaxAtMost(List<int> nums, long k, long M)
        {
            long result = 0; // count of subarrays

            var numsSpan = nums.ToArray().AsSpan();

            int start = 0;
            for (var i=0; i < nums.Count; i++)
            {
                var value = nums[i];
                if (value > M)
                {
                    result += CountSubarrays(numsSpan[start..i], k);
                    start = i + 1;
                    continue;
                }
            }

            if (start < nums.Count)
                result += CountSubarrays(numsSpan[start..], k);

            return result;
        }

        internal static long CountSubarrays(ReadOnlySpan<int> nums, long k)
        {
            long result = 0; // count of subarrays
            int accumulator = 0;

            var partialSums = new Dictionary<long, int> { [0] = 1 };

            foreach (var x in nums)
            {
                accumulator += x;

                var match = accumulator - k;
                if (partialSums.TryGetValue(match, out int matchValue))
                    result += matchValue;

                if (partialSums.TryGetValue(accumulator, out int value))
                    partialSums[accumulator] = value + 1;
                else
                    partialSums.Add(accumulator, 1);
            }

            return result;
        }
    }

    public class Tests
    {
        [TestCase(new[] { 1, 1, 1, 1 }, 3, 2, 2)]
        [TestCase(new[] { 1, 3, 1, 1, 1 }, 3, 2, 1)]
        [TestCase(new[] { 2, 1, -1, 1 }, 3, 2, 2)]
        [TestCase(new[] { 2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] { 5 }, 5, 5, 1)]
        [TestCase(new[] { 5, 5 }, 5, 5, 2)]
        [TestCase(new[] { 1, 2, -1, 1 }, 3, 2, 2)]
        [TestCase(new[] { 1 }, 1, 1, 1)]
        [TestCase(new[] { 1, 2 }, 2, 1, 0)]
        [TestCase(new[] { 1, 2 }, 2, 2, 1)]
        [TestCase(new[] { 3, 2 }, 5, 3, 1)]
        [TestCase(new[] { -1, -1 }, -1, -1, 2)]
        [TestCase(new[] { -1, -1 }, -2, -1, 1)]
        [TestCase(new[] { 0, 0, 0 }, 0, 0, 6)]
        public void Test(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost([.. nums], k, m);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}


