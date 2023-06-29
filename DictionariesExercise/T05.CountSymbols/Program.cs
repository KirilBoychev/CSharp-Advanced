using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    dict[input[i]]++;
                }
                else
                {
                    dict.Add(input[i], 1);
                }
            }

            //dict.OrderBy(x => x);

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
