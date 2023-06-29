using System;
using System.Collections.Generic;

namespace T01.UnigueUsername
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }

            Console.WriteLine(String.Join(Environment.NewLine, set));
        }
    }
}
