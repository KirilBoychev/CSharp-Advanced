using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = arr[0];
                List<string> list = arr[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                foreach (string item in list)
                {
                    if (!dict[color].ContainsKey(item))
                    {
                        dict[color].Add(item, 0);
                    }

                    dict[color][item]++;
                }
            }

            string[] lastOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string colour = lastOne[0];
            string clothe = lastOne[1];


            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");

                Dictionary<string, int> clothesLine = color.Value;

                foreach (var item in clothesLine)
                {
                    string output = $"* {item.Key} - {item.Value}";

                    if (colour == color.Key && clothe == item.Key)
                    {
                        output += " (found!)";
                    }

                    Console.WriteLine(output);
                }
            }
        }
    }
}
