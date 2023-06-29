using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> waterQuantity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();
            List<decimal> flourQuantity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();


            Queue<decimal> queue = new Queue<decimal>();
            Stack<decimal> stack = new Stack<decimal>();

            Dictionary<string, decimal> everyProduct = new Dictionary<string, decimal>();

            for (int i = 0; i < waterQuantity.Count; i++)
            {
                queue.Enqueue(waterQuantity[i]);
            }
            for (int i = 0; i < flourQuantity.Count; i++)
            {
                stack.Push(flourQuantity[i]);
            }
            //Dictionary<string, double> remained = new Dictionary<string, double>();

            while (stack.Count > 0 && queue.Count > 0)
            {
                decimal water = queue.Peek();
                decimal flour = stack.Peek();

                string product = string.Empty;

                if ((decimal)(water / (water + flour)) == (decimal)0.5m)
                {
                    product = "Croissant";
                    stack.Pop();
                    queue.Dequeue();
                    if (everyProduct.ContainsKey(product))
                    {
                        everyProduct[product]++;
                    }
                    else
                    {
                        everyProduct.Add(product, 1);
                    }
                }
                else if ((decimal)(water / (water + flour)) == (decimal)0.4m)
                {
                    product = "Muffin";
                    stack.Pop();
                    queue.Dequeue();
                    if (everyProduct.ContainsKey(product))
                    {
                        everyProduct[product]++;
                    }
                    else
                    {
                        everyProduct.Add(product, 1);
                    }
                }
                else if ((decimal)(water / (water + flour)) == (decimal)0.3m)
                {
                    product = "Baguette";
                    stack.Pop();
                    queue.Dequeue();
                    if (everyProduct.ContainsKey(product))
                    {
                        everyProduct[product]++;
                    }
                    else
                    {
                        everyProduct.Add(product, 1);
                    }
                }
                else if ((decimal)(water / (water + flour)) == (decimal)0.2m)
                {
                    product = "Bagel";
                    stack.Pop();
                    queue.Dequeue();
                    if (everyProduct.ContainsKey(product))
                    {
                        everyProduct[product]++;
                    }
                    else
                    {
                        everyProduct.Add(product, 1);
                    }
                }
                else
                {
                    decimal currOne = stack.Peek() - queue.Peek();
                    product = "Croissant";
                    queue.Dequeue();
                    stack.Pop();
                    stack.Push(currOne);
                    if (everyProduct.ContainsKey(product))
                    {
                        everyProduct[product]++;
                    }
                    else
                    {
                        everyProduct.Add(product, 1);
                    }
                }
            }

            everyProduct.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in everyProduct.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", queue)}");
            }

            if (stack.Count == 0)
            {
                Console.WriteLine($"Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", stack)}");
            }
        }
    }
}
