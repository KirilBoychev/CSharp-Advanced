using System;
using System.Collections.Generic;

namespace T02.AvarageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string commandName = input[0];
                decimal currentGrade = decimal.Parse(input[1]);

                if (dict.ContainsKey(commandName))
                {
                    dict[commandName].Add((decimal)currentGrade);
                }
                else
                {
                    dict.Add(commandName, new List<decimal>());
                    dict[commandName].Add((decimal)currentGrade);
                }
            }

            foreach (KeyValuePair<string, List<decimal>> keyValue in dict)
            {
                decimal avarage = 0.00m;
                decimal counter = 0.00m;
                foreach (var value in keyValue.Value)
                {
                    avarage += (decimal)value;
                    counter++;
                }
                avarage /= (decimal)counter;

                Console.WriteLine($"{keyValue.Key} -> {string.Join(" ", keyValue.Value)} (avg: {(decimal)avarage:f2})");
            }
        }
    }
}
