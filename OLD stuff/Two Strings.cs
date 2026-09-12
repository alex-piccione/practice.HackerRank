using NUnit.Framework;

namespace HackerRank
{

    public class TwoStrings
    {
        // Complete the twoStrings function below.
        static string AreUnique(string s1, string s2)
        {
            HashSet<char> s1Unique = [.. s1];
            HashSet<char> s2Unique = [.. s2];
            foreach (var c in s1Unique)
            {
                if (s2Unique.Contains(c))
                    return "YES";
            }

            return "NO";
        }

        [TestCase("aaaaanaaa", "rtrtrlsnsdp", ExpectedResult = "YES")]
        public string CheckMagazine_Test(string s1, string s2)
        {
            return AreUnique(s1, s2);
        }
    }
}
