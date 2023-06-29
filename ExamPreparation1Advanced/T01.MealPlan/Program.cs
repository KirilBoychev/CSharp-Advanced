using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> caloriesPerDay = new Stack<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            //List<int> calories = new List<int>();
            //Dictionary<string, int> dict = new Dictionary<string, int>()
            //{ {"salad", 350}, {"soup", 490}, {"pasta", 680}, {"steak", 790} };

            int sum = 0;
            int counter = meals.Count;

            while (meals.Count != 0 && caloriesPerDay.Count != 0)
            {
                int currCaloriesMeal = 0;

                if (meals.Peek() == "salad")
                {
                    currCaloriesMeal = 350;
                }
                else if (meals.Peek() == "soup")
                {
                    currCaloriesMeal = 490;
                }
                else if (meals.Peek() == "pasta")
                {
                    currCaloriesMeal = 680;
                }
                else if (meals.Peek() == "steak")
                {
                    currCaloriesMeal = 790;
                }

                sum = caloriesPerDay.Peek() - currCaloriesMeal;

                if (sum > 0)
                {
                    //dict[meals.Dequeue()]++;
                    caloriesPerDay.Pop();
                    caloriesPerDay.Push(sum);
                    meals.Dequeue();
                }
                else if (sum == 0)
                {
                    //dict[meals.Dequeue()]++;
                    meals.Dequeue();
                    caloriesPerDay.Pop();
                }
                else
                {
                    int currOne = 0;
                    while (sum < 0)
                    {
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            break;
                        }
                        currOne = Math.Abs(sum);
                        sum = caloriesPerDay.Peek() - sum;
                        
                    }
                    if (caloriesPerDay.Count == 0)
                    {
                        meals.Dequeue();
                        break;
                    }
                    int popOne = caloriesPerDay.Pop();
                    caloriesPerDay.Push(popOne - currOne);
                    meals.Dequeue();
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {counter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {counter - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
