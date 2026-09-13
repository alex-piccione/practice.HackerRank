using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit._01_Easy_CountElements_Greater_Then_Previous_Average
{
    class Result
    {
        public static int CountResponseTimeRegressions(List<int> responseTimes)
        {
            int accumulator = 0;
            int counter = 0;

            for (var i = 0; i < responseTimes.Count; i++)
            {
                if (accumulator > 0 && responseTimes[i] > accumulator/i)
                    counter++;
                accumulator += responseTimes[i];
            }

            return counter;
        }

        public static int CountResponseTimeRegressions_Aggregate(List<int> responseTimes) =>
            responseTimes.Aggregate(
                (Sum: 0, Count: 0, Result: 0),
                (acc, val) => (
                    Sum: acc.Sum + val,
                    Count: acc.Count + 1,
                Result: acc.Result + (acc.Sum > 0 && val > acc.Sum / acc.Count ? 1 : 0)),
                acc => acc.Result);
            }

    public class Tests {
        
        [TestCase("01_input.txt", "01_output.txt")]
        [TestCase("02_input.txt", "02_output.txt")]
        [TestCase("03_input.txt", "03_output.txt")]
        public void Test(string inputFile, string outputFile)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory; // bin/Debug/net10.0/
            string testFolder = Path.Combine(dir, "Prepare\\Software Engineer Prep Kit\\01_Easy_CountElements_Greater_Then_Previous_Average\\Tests");
            // Point Console.In to a file (e.g., "testcase_01.txt")
            //using var input = new StreamReader(Path.Combine(testFolder, inputFile));
            var lines = File.ReadAllLines(Path.Combine(testFolder, inputFile));
            var responseTimes = lines.Skip(1).Select(int.Parse).ToList();

            var result = Result.CountResponseTimeRegressions(responseTimes);

            var expectedResult = int.Parse(File.ReadAllText(Path.Combine(testFolder, outputFile)));

            Assert.AreEqual(expectedResult, result);
        }
    }

}
