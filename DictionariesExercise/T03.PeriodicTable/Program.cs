using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }

            set = set.OrderBy(x => x).ToHashSet();

            Console.WriteLine(String.Join(" ", set));
        }
    }
}
