using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 }
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int sum = steel.Peek() + carbon.Peek();
                if (sum == 70)
                {
                    dict["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 80)
                {
                    dict["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 90)
                {
                    dict["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 110)
                {
                    dict["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 150)
                {
                    dict["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    int currCarbon = carbon.Pop() + 5;
                    carbon.Push(currCarbon);
                }
            }

            int sum1 = 0;
            foreach (var item in dict)
            {
                if (item.Value != 0)
                {
                    sum1 += item.Value;
                }
            }

            if (sum1 != 0)
            {
                Console.WriteLine($"You have forged {sum1} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine($"Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
