using System;
using System.Collections.Generic;
using System.IO;

namespace _30Days
{
    public class Solution
    {

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var person = new Dictionary<string, int>(employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                int sum = 0;
                int count = 0;
                if(person.ContainsKey(employees[i].Company)==false)
                {
                    for (int n = 0; n < employees.Count; n++)
                        if (employees[i].Company == employees[n].Company)
                        {
                            sum += employees[n].Age;
                            count++;
                        }
                    person.Add(employees[i].Company, Convert.ToInt32((double)sum / count));
                }
            }
            var sortedDict = new SortedDictionary<string, int>(person);
            var person2 = new Dictionary<string, int>(employees.Count);
            foreach (var kvp in sortedDict)
                person2.Add(kvp.Key, kvp.Value);
            return person2;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> person = new Dictionary<string, int>(employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                int count = 0;
                if (person.ContainsKey(employees[i].Company) == false)
                {
                    for (int n = 0; n < employees.Count; n++)
                        if (employees[i].Company == employees[n].Company)
                            count++;
                    person.Add(employees[i].Company, count);
                }
            }
            var sortedDict = new SortedDictionary<string, int>(person);
            var person2 = new Dictionary<string, int>(employees.Count);
            foreach (var kvp in sortedDict)
                person2.Add(kvp.Key, kvp.Value);
            return person2;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> person = new Dictionary<string, Employee>(employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                int max = employees[i].Age;
                int g = i;
                if (person.ContainsKey(employees[i].Company) == false)
                {
                    for (int n = 0; n < employees.Count; n++)
                    {
                        if (employees[i].Company == employees[n].Company)
                            if (employees[n].Age>max)
                            {
                                max = employees[n].Age;
                                g = n;
                            }
                    }
                    person.Add(employees[g].Company, employees[g]);
                }
            }
            var sortedDict = new SortedDictionary<string, Employee>(person);
            var person2 = new Dictionary<string, Employee>(employees.Count);
            foreach (var kvp in sortedDict)
                person2.Add(kvp.Key, kvp.Value);
            return person2;
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
