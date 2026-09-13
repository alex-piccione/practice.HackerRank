namespace HackerRank.Certify
{
    internal sealed record Employee(string Company, string FirstName, string LastName, int Age);

    internal class Basic_Employee
    {
        public Dictionary<string, int> GetAverageAgeOfEmployeesPerCompany(List<Employee> employees) => employees.GroupBy(e => e.Company)
                .ToDictionary(g => g.Key, g => (int)g.Average(e => e.Age));

        public Dictionary<string, int> GetCountOfEmployeesPerCompany(List<Employee> employees) => employees.GroupBy(e => e.Company)
                .ToDictionary(g => g.Key, g => g.Count());

        public Dictionary<string, int> GetAgeOfOldestEmployeePerCompany(List<Employee> employees) => employees.GroupBy(e => e.Company)
                .ToDictionary(g => g.Key, g => g.Max(e => e.Age));
    }
}
