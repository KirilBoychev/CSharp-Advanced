using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01.BlackSmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> dict = new Dictionary<string, int>()
            { {"Gladius", 0 }, {"Shamshir", 0 }, { "Katana", 0}, { "Sabre", 0 }, { "Broadsword", 0} };

            while (steel.Count != 0 && carbon.Count != 0)
            {
                int sum = steel.Peek() + carbon.Peek();

                if (sum == 70)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    dict["Gladius"]++;
                }
                else if (sum == 80)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    dict["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    dict["Katana"]++;
                }
                else if (sum == 110)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    dict["Sabre"]++;
                }
                else if (sum == 150)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    dict["Broadsword"]++;
                }
                else
                {
                    steel.Dequeue();
                    int currOne = carbon.Peek() + 5;
                    carbon.Pop();
                    carbon.Push(currOne);
                }
            }

            int counter = 0;
            foreach (var item in dict)
            {
                counter += item.Value;
            }
            if (counter == 0)
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {counter} swords.");
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
                Console.WriteLine($"Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            //dict.OrderBy(x => x.Key);

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
