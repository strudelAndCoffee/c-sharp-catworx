﻿using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static List<string> GetEmployees()
    {
        List<string> employees = new List<string>();
        while (true)
        {
            Console.WriteLine("Please enter a name: (leave empty to exit): ");
            // null coalescing operator ??: if input is null, replace with empty string ""
            string input = Console.ReadLine() ?? "";
            if (input == "")
            {
                break;
            }

            Employee currentEmployee = new Employee(input, "Smith");
            employees.Add(currentEmployee.GetFullName());
        }
        return employees;
    }
    static void PrintEmplayees(List<string> employees)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine(employees[i]);
        }
    }
    static void Main(string[] args)
    {
        List<string> employees = GetEmployees();
        PrintEmplayees(employees);
    }
  }
}