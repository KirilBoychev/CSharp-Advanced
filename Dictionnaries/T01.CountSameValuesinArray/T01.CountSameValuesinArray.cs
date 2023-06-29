using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        double[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        Dictionary<double, int> dictionary = new Dictionary<double, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (dictionary.ContainsKey(input[i]))
            {
                dictionary[input[i]]++;
            }
            else
            {
                dictionary.Add(input[i], 1);
            }
        }

        foreach (KeyValuePair<double, int> keyValue in dictionary)
        {
            Console.WriteLine($"{keyValue.Key} - {keyValue.Value} times");
        }
    }
}

