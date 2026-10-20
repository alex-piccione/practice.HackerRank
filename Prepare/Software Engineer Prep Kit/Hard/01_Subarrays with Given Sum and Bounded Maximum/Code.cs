using NUnit.Framework;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Hard._01_Subarrays_with_Given_Sum_and_Bounded_Maximum
{
    internal class Code
    {
        // Too slow
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

        // Too slow
        public static long countSubarraysWithSumAndMaxAtMost(List<int> nums, long k, long M)
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

        public static long countSubarraysWithSumAndMaxAtMost_Span(List<int> nums, long k, long M)
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

                if (x == array.Length - 1)
                    result += processSpan(array[spanStart..], k);
            }

            return result;
        }



        public static long countSubarraysWithSumAndMaxAtMost_Slice(List<int> nums, long k, long M)
        {
            //long result = 0;

            var results = new ConcurrentBag<int>();

            void processSlice(int start, int end)
            {
                if (start == end)
                {
                    results.Add(nums[start] == k ? 1 : 0);
                }
                else
                {
                    int result = 0;

                    for (var x = start; x <= end; x++)
                    {
                        int sum = 0;
                        for (var y = x; y <= end; y++)
                        {
                            var current = nums[y];

                            sum += current;
                            if (sum == k)
                                result++;
                        }
                    }

                    results.Add(result);
                }
            }

            int spanStart = 0;
            var tasks = new List<Task>();
            for (var x = 0; x < nums.Count; x++)
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
                        //result += tasks.Add( ;
                        int start = spanStart;
                        int end = x-1;
                        tasks.Add(Task.Run(() => processSlice(start, end)));
                        spanStart = x + 1;
                    }
                }

                if (x == nums.Count - 1)
                    tasks.Add(Task.Run(() => processSlice(spanStart, nums.Count - 1)));
                    //result += await processSlice(spanStart, nums.Count - 1);    
            }

            Task.WaitAll(tasks.ToArray());

            return results.Sum();
        }

        static long CountSegment(List<int> nums, int start, int endExclusive, long k)
        {
            long result = 0, sum = 0;
            //var seen = new Dictionary<long, int> { [0] = 1 };
            var seen = new Dictionary<long, int> { { 0L, 1 } };

            for (int i = start; i < endExclusive; i++)
            {
                sum += nums[i];
                if (seen.TryGetValue(sum - k, out var c)) result += c;
                seen[sum] = seen.GetValueOrDefault(sum) + 1;
            }
            return result;
        }

        public static long countSubarraysWithSumAndMaxAtMost_Sliding(List<int> nums, long k, long M)
        {
            var tasks = new List<Task<long>>();
            int start = 0;

            for (int i = 0; i <= nums.Count; i++)
            {
                if (i == nums.Count || nums[i] > M)          // barrier or end of list
                {
                    if (i > start)
                    {
                        int s = start, e = i;                // copies, so the lambda doesn't see later changes
                        tasks.Add(Task.Run(() => CountSegment(nums, s, e, k)));
                    }
                    start = i + 1;
                }
            }

            Task.WaitAll(tasks.ToArray());

            long total = 0;
            foreach (var t in tasks) total += t.Result;
            return total;
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

        [TestCase(new[] { 2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] { 5 }, 5, 5, 1)]
        [TestCase(new[] { 1, 2, -1, 1 }, 3, 2, 2)]
        public void Test_Span(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost_Span([.. nums], k, m);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { 2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] { 5 }, 5, 5, 1)]
        [TestCase(new[] { 1, 2, -1, 1 }, 3, 2, 2)]
        public void Test_Slice(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost_Slice([.. nums], k, m);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { 2, -1, 2, 1, -2, 3 }, 3, 2, 2)]
        [TestCase(new[] { 5 }, 5, 5, 1)]
        [TestCase(new[] { 1, 2, -1, 1 }, 3, 2, 2)]
        public void Test_Sliding(int[] nums, long k, long m, long expectedResult)
        {
            var result = Code.countSubarraysWithSumAndMaxAtMost_Sliding([.. nums], k, m);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}


