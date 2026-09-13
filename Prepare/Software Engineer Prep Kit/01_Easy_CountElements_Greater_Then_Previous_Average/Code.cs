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

        /*
         * Complete the 'countResponseTimeRegressions' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY responseTimes as parameter.
         */

        public static int CountResponseTimeRegressions(List<int> responseTimes)
        {
            return 0;
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
