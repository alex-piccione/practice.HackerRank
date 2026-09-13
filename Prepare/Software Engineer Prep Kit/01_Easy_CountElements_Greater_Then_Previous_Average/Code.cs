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

    class Solution
    {
        public static void Main(string[] args)
        {
            int responseTimesCount = Convert.ToInt32(Console.ReadLine()??"".Trim());

            List<int> responseTimes = new List<int>();

            for (int i = 0; i < responseTimesCount; i++)
            {
                int responseTimesItem = Convert.ToInt32(Console.ReadLine()??"".Trim());
                responseTimes.Add(responseTimesItem);
            }

            int result = Result.CountResponseTimeRegressions(responseTimes);

            Console.WriteLine(result);
        }
    }

}
