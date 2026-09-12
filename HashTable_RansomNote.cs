using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class HashTable_RansomNote
    {

        public static string CheckMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int> magazineWords = new Dictionary<string, int>();
            
            int index = 0;

            foreach (var word in note)
                if (magazineWords.ContainsKey(word))
                {
                    if (magazineWords[word] > 1)
                        magazineWords[word] -= 1;
                    else
                        magazineWords.Remove(word);

                    continue;
                }
                else
                {
                    bool found = false;
                    while (index < magazine.Length)
                    {
                        var newWord = magazine[index];
                        if (newWord == word)
                        {
                            found = true;
                            index++;
                            break;
                        }
                        else
                            if (magazineWords.ContainsKey(newWord))
                            magazineWords[newWord] += 1;
                        else
                            magazineWords.Add(newWord, 1);

                        index++;                    
                    }

                    if (!found)
                    {
                        Console.Write("No");
                        return "No";
                    }
                }


            Console.Write("Yes");
            return "Yes";
        }
        
            
       /*
        static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            checkMagazine(magazine, note);
        }*/




        [Test]
        public void CheckMagazine_Test()
        {

            var magazine = new string[] { "two", "times", "three", "is", "not", "four" };
            var note = new string[] { "two", "times", "two", "is", "four" };
                        


            var result =  HashTable_RansomNote.CheckMagazine(magazine, note);

            Assert.AreEqual("No", result);
        }
    
    }
}
