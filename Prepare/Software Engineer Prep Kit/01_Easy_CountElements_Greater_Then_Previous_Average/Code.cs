using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit._01_Easy_CountElements_Greater_Then_Previous_Average
{
    class Result
    {
        public static int CountResponseTimeRegressions(List<int> responseTimes)
        {
            if (responseTimes.Count < 2) return 0;

            int accumulator = responseTimes[0];
            int counter = 0;
            for (var i = 1; i < responseTimes.Count - 1; i++)
            {
                var avg = (accumulator + responseTimes[i]) / i;
                if (responseTimes[i] > avg)
                    counter++;
            }

            return counter;
        }
    }

    public class Tests {
        [TestCase("01_input.txt", "01_output.txt")]
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
