using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> capacityOfHuman = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> list = new List<int>();

            while (capacityOfHuman.Count > 0 && plates.Count > 0)
            {
                int guest = capacityOfHuman.Peek();
                int plate = plates.Peek();
                int sum = plates.Peek() - capacityOfHuman.Peek();
                if (sum > 0)
                {
                    capacityOfHuman.Dequeue();
                    list.Add(sum);
                    plates.Pop();
                }
                else if (sum == 0)
                {
                    capacityOfHuman.Dequeue();
                    plates.Pop();
                }
                else
                {
                    capacityOfHuman.Dequeue();
                    plates.Pop();
                    capacityOfHuman = new Queue<int>(capacityOfHuman.Reverse());
                    capacityOfHuman.Enqueue(guest - plate);
                    capacityOfHuman = new Queue<int>(capacityOfHuman.Reverse());
                }
            }

            if (capacityOfHuman.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", capacityOfHuman)}");
            }

            int sum3 = 0;
            foreach (var plate in list)
                sum3 += plate;
            Console.WriteLine($"Wasted grams of food: {sum3}");
        }
    }
}
