using NUnit.Framework;

namespace HackerRank.SkyScanner
{
    public class Solution
    {
        public static void OutputCommonManager(int numberOfEmployees)
        {
            string selectedEmployee_1 = Console.ReadLine() ?? "";
            string selectedEmployee_2 = Console.ReadLine() ?? "";

            var relations = new List<Relation>(numberOfEmployees-1);

            var line = Console.ReadLine();  // the first line contains the top manager in the hierarchy
            while (!string.IsNullOrEmpty(line))
            {
                var employees = line.Split(' ');
                relations.Add(new Relation { Manager = employees[0], Employee = employees[1] });
                line = Console.ReadLine();
            }

            var managersOfEmployee_1 = GetManagers(selectedEmployee_1, relations);
            var managersOfEmployee_2 = GetManagers(selectedEmployee_2, relations);

            if(selectedEmployee_1 == managersOfEmployee_2[0])
                Console.WriteLine(selectedEmployee_1);

            foreach (var managerOf_1 in managersOfEmployee_1)
            {
                managersOfEmployee_2.Contains(managerOf_1);
                    Console.WriteLine(managerOf_1);
            }

            // no common manager !
        }


        private static List<string> GetManagers(string employee, List<Relation> relations)
        {
            var managers = new List<string>(relations.Count - 1);

            var currentManager = GetManager(employee, relations);

            while (currentManager != null)
            {
                managers.Add(currentManager);
                currentManager = GetManager(currentManager, relations);
            }

            return managers;
        }

        private static string? GetManager(string employee, List<Relation> relations)
            => relations.FirstOrDefault(r => r.Employee == employee)?.Manager;


        // EmployeeX manage EmployeeY
        private class Relation
        {
            public required string Manager { get; set; }
            public required string Employee { get; set; }
        }
    }
}