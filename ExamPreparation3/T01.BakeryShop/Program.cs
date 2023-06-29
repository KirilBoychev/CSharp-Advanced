using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>
            (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>
            (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, int> map = new Dictionary<string, int>()
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (water.Count > 0 && flour.Count != 0)
            {
                double sum = (water.Peek() * 100.0) / (water.Peek() + flour.Peek());
                
                if (sum == 50)
                {
                    map["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (sum == 40)
                {
                    map["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (sum == 30)
                {
                    map["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (sum == 20)
                {
                    map["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double currFlour = (double)(flour.Pop() - water.Dequeue());
                    map["Croissant"]++;
                    flour.Push(currFlour);
                }
            }

            foreach (var item in map.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
