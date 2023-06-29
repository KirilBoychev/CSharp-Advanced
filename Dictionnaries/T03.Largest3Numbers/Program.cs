using System;
using System.Linq;

namespace T03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();

            if (list.Length < 3)
            {
                Console.WriteLine(String.Join(" ", list));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{list[i]} ");
                }
            }
        }
    }
}
