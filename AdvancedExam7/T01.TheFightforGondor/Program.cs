using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TheFightforGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());
            var plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var orcsToPrint = new Queue<int>();
            for (int i = 1; i <= waves; i++)
            {
                var newWaveOrcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                var curPlate = plates.Peek();
                if (i % 3 == 0)
                {
                    string input = Console.ReadLine();
                    int plateToAdd = int.Parse(input);
                    plates.Enqueue(plateToAdd);
                }
                while (newWaveOrcs.Count != 0 && plates.Count != 0)
                {
                    var curOrc = newWaveOrcs.Peek();
                    if (curPlate - curOrc > 0)
                    {
                        curPlate -= curOrc;
                        newWaveOrcs.Pop();  
                    }
                    else if (curOrc > curPlate)
                    {
                        int orcToPrint = Math.Abs(curPlate - curOrc);
                        orcsToPrint.Enqueue(orcToPrint);
                        newWaveOrcs.Pop();
                        plates.Dequeue();
                        if (plates.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            curPlate = plates.Peek();
                        }
                    }
                    else
                    {
                        plates.Dequeue();
                        newWaveOrcs.Pop();
                    }
                }
                if (newWaveOrcs.Count > 0 && plates.Count == 0)
                {
                    for (int j = 0; j < newWaveOrcs.Count; j++)
                    {
                        orcsToPrint.Enqueue(newWaveOrcs.Pop());
                    }
                    break;
                }

            }

            if (plates.Count <= 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsToPrint)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
        //int waves = int.Parse(Console.ReadLine());

        //Queue<int> pl = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

        //Queue<Queue<int>> plate = new Queue<Queue<int>>();
        //plate.Enqueue(pl);

        //Queue<Stack<int>> org = new Queue<Stack<int>>();
        //for (int i = 1; i <= waves; i++)
        //{
        //    org.Enqueue((Stack<int>)Console.ReadLine().Split().Select(int.Parse));
        //    if (i % 3 == 0)
        //    {
        //        plate.Enqueue((Queue<int>)Console.ReadLine().Split().Select(int.Parse));
        //        break;
        //    }
        //}

        //int sum = 0;

        //while (org.Count != 0 && plate.Count != 0)
        //{
        //    Queue<int> currQueue = plate.Dequeue();
        //    Stack<int> currStack = org.Dequeue();
        //    if (currQueue.Count == 0)
        //    {

        //    }
        //    else if (currStack.Count == 0)
        //    {

        //    }
        //    else
        //    {
        //        sum = currQueue.Peek() - currStack.Peek();
        //    }
        //}
    }
}
