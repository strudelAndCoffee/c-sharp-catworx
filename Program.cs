using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
        Console.WriteLine("Would you like to generate badges from existing database records? (Please type 'y' for Yes, 'n' for No): ");
        string response = Console.ReadLine() ?? "";

        if (response == "n" | response == "N" | response == "no" | response == "No" | response == "NO")
        {
            List<Employee> employees = PeopleFetcher.GetEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
        if (response == "y" | response == "Y" | response == "yes" | response == "Yes" | response == "YES")
        {
            List<Employee> employees = await PeopleFetcher.GetFromApi();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
        else
        {
            Console.WriteLine("Error in response. Please restart program.");
        }
    }
  }
}