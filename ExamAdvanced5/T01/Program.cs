using System;
using System.Collections.Generic;
using System.Linq;

namespace T01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> dict = new Dictionary<string, int>()
            { { "Dipping sauce", 0 }, { "Green salad", 0 }, { "Chocolate cake", 0 }, { "Lobster", 0 }};

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }

                long sum = ingredients.Peek() * freshness.Peek();

                if (sum == 150)
                {
                    dict["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (sum == 250)
                {
                    dict["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (sum == 300)
                {
                    dict["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (sum == 400)
                {
                    dict["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    int currValue = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(currValue);
                }
            }

            int counter = 0;
            foreach (var item in dict)
            {
                if (item.Value != 0)
                {
                    counter++;
                }
            }
            if (counter == 4)
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                long sum1 = 0;
                List<int> list= new List<int>(ingredients);
                for (int i = 0; i < list.Count; i++)
                {
                    sum1 += list[i];

                }
                Console.WriteLine($"Ingredients left: {sum1}");
            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
