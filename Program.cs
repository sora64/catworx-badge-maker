using System;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            List<Employee> employees = PeopleFetcher.GetEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}