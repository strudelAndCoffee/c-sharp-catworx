using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
    class Util
    { 
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++) 
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }

        public static void MakeCSV(List<Employee> employees)
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");
                for (int i = 0; i < employees.Count; i++)
                {
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }

        public static void ReadCSV()
        {
            if (Directory.Exists("data"))
            {
                try 
                {
                    using (StreamReader sr = new StreamReader("data/employees.csv"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }

        async public static Task MakeBadges(List<Employee> employees)
        {
            using(HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                    // SKData data = background.Encode();
                    // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
                }
            }
        }
    }
}