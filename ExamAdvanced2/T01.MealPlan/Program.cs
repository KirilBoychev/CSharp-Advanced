using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int[] caloriesPerDay = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            const int saladCalories = 350;
            const int soupCalories = 490;
            const int pastaCalories = 680;
            const int steakCalories = 790;

            Queue<string> queueMeals = new Queue<string>();
            Stack<int> stackCalories = new Stack<int>();

            int counter = meals.Length;
            int sum = 0;
            for (int i = 0; i < meals.Length; i++)
            {
                queueMeals.Enqueue(meals[i]);
            }

            for (int i = 0; i < caloriesPerDay.Length; i++)
            {
                stackCalories.Push(caloriesPerDay[i]);
            }

            while (queueMeals.Count > 0 && stackCalories.Count > 0)
            {
                string currMeal = queueMeals.Peek();
                int currCalories = stackCalories.Peek();

                if (currMeal != "salad")
                {
                    sum = currCalories - saladCalories;
                }
                else if (currMeal == "soup")
                {
                    sum = currCalories - soupCalories;
                }
                else if (currMeal == "pasta")
                {
                    sum = currCalories - pastaCalories;
                }
                else if (currMeal == "steak")
                {
                    sum = currCalories - steakCalories;
                }

                if (sum > 0)
                {
                    queueMeals.Dequeue();
                    sum = 0;
                }
                else if (sum == 0)
                {
                    queueMeals.Dequeue();
                    stackCalories.Pop();
                    sum = 0;
                }
                else if (sum < 0)
                {
                    
                }
            }

            if (queueMeals.Count == 0)
            {
                Console.WriteLine($"John had {counter} meals.");
                while (stackCalories.Count > 0)
                {
                    Console.WriteLine($"For the next few days, he can eat {stackCalories.Pop()} calories.");
                }
            }

            if (stackCalories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {counter - queueMeals.Count} meals.");
                while (queueMeals.Count > 0)
                {
                    Console.WriteLine($"Meals left: {queueMeals.Dequeue()}.");
                }
            }
        }
    }
}
