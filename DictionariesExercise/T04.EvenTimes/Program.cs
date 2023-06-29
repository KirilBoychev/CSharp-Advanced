using System;
using System.Collections.Generic;

namespace T04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<int> set = new HashSet<int>();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (set.Contains(currNum))
                {
                    if (dict.ContainsKey(currNum))
                    {
                        dict[currNum]++;
                    }
                    else
                    {
                        dict[currNum] = 2;
                    }
                }
                else
                {
                    set.Add(currNum);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
