using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TheFightforGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());

            Queue<int> plate1 = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            List<Queue<int>> plates = new List<Queue<int>>();
            plates.Add(plate1);

            Stack<int> org1 = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            List<Stack<int>> orgRow = new List<Stack<int>>();
            orgRow.Add(org1);

            for (int i = 2; i <= wavesOfOrcs; i++)
            {
                orgRow.Add(new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)));

                if (i % 3 == 0)
                {
                    plates.Add(new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)));
                }
            }

            while (plates.Count != 0 && orgRow.Count != 0)
            {
                for (int i = 0; i < plates.Count; i++)
                {
                    if (plates[i].Count == 0)
                    {
                        plates.RemoveAt(i);
                    }
                }
                for (int i = 0; i < orgRow.Count; i++)
                {
                    if (orgRow[i].Count == 0)
                    {
                        orgRow.RemoveAt(i);
                    }
                }

                if (plates.Count == 0 || orgRow.Count == 0)
                {
                    break;
                }
                //Queue<int> currPlateRow = plates[0];
                //Stack<int> currStackRow = orgRow[0];

                while (plates[0].Count > 0 && orgRow[0].Count > 0)
                {
                    int sum = plates[0].Peek() - orgRow[0].Peek();
                    if (sum > 0)
                    {
                        orgRow[0].Pop();
                        if (plates[0].Count == 0 || orgRow[0].Count == 0)
                        {
                            break;
                        }
                        sum -= orgRow[0].Peek();
                        while (sum > 0)
                        {
                            orgRow[0].Pop();
                            if (plates[0].Count == 0 || orgRow[0].Count == 0)
                            {
                                break;
                            }
                            sum -= orgRow[0].Peek();
                        }
                        if (sum == 0)
                        {
                            plates[0].Dequeue();
                            orgRow[0].Pop();
                        }
                        else if (sum < 0)
                        {
                            orgRow[0].Pop();
                            plates[0].Dequeue();
                            orgRow[0].Push(Math.Abs(sum));
                        }
                    }
                    else if (sum == 0)
                    {
                        plates[0].Dequeue();
                        orgRow[0].Pop();
                    }
                    else
                    {
                        orgRow[0].Pop();
                        plates[0].Dequeue();
                        orgRow[0].Push(Math.Abs(sum));
                    }
                }
            }


            if (plates.Count == 0)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            }

            if (plates.Count != 0)
            {
                Console.Write($"Plates left: {string.Join(", ", plates[0])}");
                //foreach (var item in plates)
                //{
                //    if (plates.Count == 1 && plates[0].Count == 1)
                //    {
                //        Console.Write($"{string.Join(", ", item)}");
                //    }
                //    else
                //    {
                //        Console.Write($"{string.Join(", ", item)}, ");
                //    }
                //}
            }
            else if (orgRow.Count != 0)
            {
                Console.Write($"Orcs left: {string.Join(", ", orgRow[0])}");
                //foreach (var item in orgRow)
                //{
                //    if (orgRow.Count == 1 && orgRow.Count == 1)
                //    {
                //        Console.Write($"{string.Join(", ", item)}");
                //    }
                //    else
                //    {
                //        Console.Write($"{string.Join(", ", item)}, ");
                //    }
                //}
            }
        }
    }
}
