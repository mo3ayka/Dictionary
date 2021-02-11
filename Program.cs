using System;
using System.Collections.Generic;
using System.IO;

namespace _30Days
{
    public class Solution
    {

        public static SortedDictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var sortDictionary = new SortedDictionary<string, int>();
            for (int i = 0; i < employees.Count; i++)
            {
                int sum = 0;
                int count = 0;
                if (sortDictionary.ContainsKey(employees[i].Company) == false)
                {
                    for (int n = 0; n < employees.Count; n++)
                        if (employees[i].Company == employees[n].Company)
                        {
                            sum += employees[n].Age;
                            count++;
                        }
                    sortDictionary.Add(employees[i].Company, Convert.ToInt32((double)sum / count));
                }
            }
            return sortDictionary;
        }

        public static SortedDictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var sortDictionary = new SortedDictionary<string, int>();
            for (int i = 0; i < employees.Count; i++)
            {
                int count = 0;
                if (sortDictionary.ContainsKey(employees[i].Company) == false)
                {
                    for (int n = 0; n < employees.Count; n++)
                        if (employees[i].Company == employees[n].Company)
                            count++;
                    sortDictionary.Add(employees[i].Company, count);
                }
            }
            return sortDictionary;
        }

        public static SortedDictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var sortDictionary = new SortedDictionary<string, Employee>();
            for (int i = 0; i < employees.Count; i++)
            {
                int max = employees[i].Age;
                int g = i;
                if (sortDictionary.ContainsKey(employees[i].Company) == false)
                {
                    for (int n = 0; n < employees.Count; n++)
                    {
                        if (employees[i].Company == employees[n].Company)
                            if (employees[n].Age > max)
                            {
                                max = employees[n].Age;
                                g = n;
                            }
                    }
                    sortDictionary.Add(employees[g].Company, employees[g]);
                }
            }
            return sortDictionary;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
