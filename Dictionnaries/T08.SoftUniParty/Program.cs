using System;
using System.Collections.Generic;

namespace T08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vip = new List<string>();
            List<string> regular = new List<string>();

            string command = string.Empty;
            while((command = Console.ReadLine()) != "PARTY")
            {
                if (command.Length == 8)
                {
                    if (char.IsDigit(command[0]))
                    {
                        vip.Add(command);
                    }
                    else
                    {
                        regular.Add(command);
                    }
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(command[0]))
                {
                    if (vip.Contains(command))
                    {
                        vip.Remove(command);
                    }
                }
                else
                {
                    if (regular.Contains(command))
                    {
                        regular.Remove(command);
                    }
                }
            }

            int counter = vip.Count + regular.Count;
            Console.WriteLine(counter);

            if (vip.Count == 0 && regular.Count != 0)
            {
                foreach (var item in regular)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else if (vip.Count != 0 && regular.Count == 0)
            {
                foreach (var item in vip)
                {
                    Console.WriteLine(item);
                }
            }
            else if (vip.Count != 0 && regular.Count != 0)
            {
                foreach (var item in vip)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in regular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
