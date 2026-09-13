namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Medium._01_Merge_And_Sort
{
    internal class Code
    {
        public static List<List<int>> mergeHighDefinitionIntervals(List<List<int>> intervals)
        {
            var result = new List<List<int>>();

            if (intervals.Count > 0)
            {
                intervals = intervals.OrderBy(i => i[0]).ToList();

                var current = intervals[0];

                foreach (var interval in intervals.Skip(1))
                {

                    if (interval[0] > current[1])
                    {
                        result.Add(current);
                        current = interval;
                    }
                    else
                    {
                        if (interval[1] > current[1])
                            current[1] = interval[1];
                    }
                }
                result.Add(current);
            }

            return result;
        }
    }
}
