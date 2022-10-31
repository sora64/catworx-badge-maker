using System;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.Write("Would you like to use random employee data or your own? Answer 'Random' or 'Own' (nothing to exit): ");
            string answer = Console.ReadLine() ?? "";
            string finalAnswer = answer.ToLower();
            List<Employee> employees;
            if (finalAnswer == "random")
            {
                employees = await PeopleFetcher.GetFromApi();
                await DoTheRest(employees);
            }
            else if (finalAnswer == "own")
            {
                employees = PeopleFetcher.GetEmployees();
                await DoTheRest(employees);
            }
        }

        async static Task DoTheRest(List<Employee> employees)
        {
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}