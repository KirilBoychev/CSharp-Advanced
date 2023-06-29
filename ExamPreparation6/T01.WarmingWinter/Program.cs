using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.WarmingWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> scarfs = new Queue<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (scarfs.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    int currPrice = hats.Peek() + 1;
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(currPrice);
                }
            }

            int mostExpensive = sets.Max(x => x);
            Console.WriteLine($"The most expensive set is: {mostExpensive}");
            Console.WriteLine(String.Join(' ', sets));
        }
    }
}
