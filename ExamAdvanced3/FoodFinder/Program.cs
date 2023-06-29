using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.FoodFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));

            Dictionary<string, int> map = new Dictionary<string, int>()
            { {"pear", 4}, { "flour", 5}, { "pork", 4}, { "olive", 5} };

            int count = vowels.Count;

            while (consonants.Count != 0 && count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();

                foreach (var item in map.Keys)
                {
                    if (item.Contains(currVowel))
                    {
                        map[item]--;
                    }
                    if (item.Contains(currConsonant))
                    {
                        map[item]--;
                    }
                }
                vowels.Enqueue(currVowel);
                count--;
            }

            while(consonants.Count != 0)
            {
                char currConsonant = consonants.Pop();

                foreach (var item in map.Keys)
                {
                    if (item.Contains(currConsonant))
                    {
                        map[item]--;
                    }
                }
            }

            List<string> list = new List<string>();

            int counter = 0;
            foreach (var item in map)
            {
                if (item.Value <= 0)
                {
                    counter++;
                    list.Add(item.Key);
                }
            }

            Console.WriteLine($"Words found: {counter}");
            foreach (var item in list)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

