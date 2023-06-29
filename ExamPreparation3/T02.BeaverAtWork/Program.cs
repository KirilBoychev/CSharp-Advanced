using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int currRowBeaver = 0;
            int currColBeaver = 0;

            Stack<char> woodBrances = new Stack<char>();

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (matrix[rows, cols] == 'B')
                    {
                        currRowBeaver = rows;
                        currColBeaver = cols;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                int counter1 = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (char.IsLetter(matrix[rows, cols]) && char.IsLower(matrix[rows, cols]))
                        {
                            counter1++;
                        }
                    }
                }
                if (counter1 == 0)
                {
                    break;
                }

                if (command == "up")
                {
                    if (currRowBeaver - 1 < 0)
                    {
                        if (woodBrances.Count > 0)
                        {
                            woodBrances.Pop();
                        }
                    }
                    else
                    {
                        matrix[currRowBeaver, currColBeaver] = '-';
                        if (matrix[currRowBeaver - 1, currColBeaver] == '-')
                        {
                            matrix[currRowBeaver - 1, currColBeaver] = 'B';
                        }
                        else if (char.IsLetter(matrix[currRowBeaver - 1, currColBeaver]) && char.IsLower(matrix[currRowBeaver - 1, currColBeaver]))
                        {
                            woodBrances.Push(matrix[currRowBeaver - 1, currColBeaver]);
                            matrix[currRowBeaver - 1, currColBeaver] = 'B';
                            currRowBeaver--;
                        }
                        else if (matrix[currRowBeaver - 1, currColBeaver] == 'F')
                        {
                            if (currRowBeaver - 1 == 0)
                            {
                                currRowBeaver--;
                                matrix[currRowBeaver, currColBeaver] = '-';
                                currRowBeaver = matrix.GetLength(0) - 1;
                                if (matrix[currRowBeaver - 1, currColBeaver] == '-')
                                {
                                    matrix[currRowBeaver - 1, currColBeaver] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = 0;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }
                            else
                            {
                                currRowBeaver--;
                                currRowBeaver = 0;
                                if (matrix[currRowBeaver - 1, currColBeaver] == '-')
                                {
                                    matrix[currRowBeaver - 1, currColBeaver] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = matrix.GetLength(0) - 1;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }
                            
                        }
                        
                    }
                    
                }
                else if (command == "down")
                {
                    if (currRowBeaver + 1 > matrix.GetLength(0) - 1)
                    {
                        if (woodBrances.Count > 0)
                        {
                            woodBrances.Pop();
                        }
                    }
                    else
                    {
                        matrix[currRowBeaver, currColBeaver] = '-';
                        if (matrix[currRowBeaver + 1, currColBeaver] == '-')
                        {
                            matrix[currRowBeaver + 1, currColBeaver] = 'B';
                        }
                        else if (char.IsLetter(matrix[currRowBeaver + 1, currColBeaver]) && char.IsLower(matrix[currRowBeaver + 1, currColBeaver]))
                        {
                            woodBrances.Push(matrix[currRowBeaver + 1, currColBeaver]);
                            matrix[currRowBeaver + 1, currColBeaver] = 'B';
                            currRowBeaver++;
                        }
                        else if (matrix[currRowBeaver + 1, currColBeaver] == 'F')
                        {
                            if (currRowBeaver + 1 == matrix.GetLength(0) - 1)
                            {
                                currRowBeaver++;
                                matrix[currRowBeaver, currColBeaver] = '-';
                                currRowBeaver = 0;
                                if (matrix[currRowBeaver + 1, currColBeaver] == '-')
                                {
                                    matrix[currRowBeaver + 1, currColBeaver] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = matrix.GetLength(0) - 1;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }
                            else
                            {
                                currRowBeaver++;
                                currRowBeaver = matrix.GetLength(0) - 1;
                                if (matrix[currRowBeaver + 1, currColBeaver] == '-')
                                {
                                    matrix[currRowBeaver + 1, currColBeaver] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = 0;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }

                        }

                    }

                }
                if (command == "right")
                {
                    if (currColBeaver + 1 > matrix.GetLength(0) - 1)
                    {
                        if (woodBrances.Count > 0)
                        {
                            woodBrances.Pop();
                        }
                    }
                    else
                    {
                        matrix[currRowBeaver, currColBeaver] = '-';
                        if (matrix[currRowBeaver, currColBeaver + 1] == '-')
                        {
                            matrix[currRowBeaver, currColBeaver + 1] = 'B';
                        }
                        else if (char.IsLetter(matrix[currRowBeaver, currColBeaver + 1]) && char.IsLower(matrix[currRowBeaver, currColBeaver + 1]))
                        {
                            woodBrances.Push(matrix[currRowBeaver, currColBeaver + 1]);
                            matrix[currRowBeaver, currColBeaver + 1] = 'B';
                            currColBeaver++;
                        }
                        else if (matrix[currRowBeaver, currColBeaver + 1] == 'F')
                        {
                            if (currColBeaver + 1 == matrix.GetLength(0) - 1)
                            {
                                currColBeaver++;
                                matrix[currRowBeaver, currColBeaver] = '-';
                                currColBeaver = 0;
                                if (matrix[currRowBeaver, currColBeaver + 1] == '-')
                                {
                                    matrix[currRowBeaver, currColBeaver + 1] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currColBeaver = matrix.GetLength(0) - 1;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }
                            else
                            {
                                currColBeaver++;
                                currColBeaver = matrix.GetLength(0) - 1;
                                if (matrix[currRowBeaver, currColBeaver + 1] == '-')
                                {
                                    matrix[currRowBeaver, currColBeaver + 1] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = 0;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }

                        }

                    }

                }
                else if (command == "left")
                {
                    if (currColBeaver - 1 < 0)
                    {
                        if (woodBrances.Count > 0)
                        {
                            woodBrances.Pop();
                        }
                    }
                    else
                    {
                        matrix[currRowBeaver, currColBeaver] = '-';
                        if (matrix[currRowBeaver, currColBeaver - 1] == '-')
                        {
                            matrix[currRowBeaver, currColBeaver - 1] = 'B';
                        }
                        else if (char.IsLetter(matrix[currRowBeaver, currColBeaver - 1]) && char.IsLower(matrix[currRowBeaver, currColBeaver - 1]))
                        {
                            woodBrances.Push(matrix[currRowBeaver, currColBeaver - 1]);
                            matrix[currRowBeaver, currColBeaver - 1] = 'B';
                            currColBeaver--;
                        }
                        else if (matrix[currRowBeaver, currColBeaver - 1] == 'F')
                        {
                            if (currColBeaver - 1 == 0)
                            {
                                currColBeaver++;
                                matrix[currRowBeaver, currColBeaver] = '-';
                                currColBeaver = matrix.GetLength(0) - 1;
                                if (matrix[currRowBeaver, currColBeaver - 1] == '-')
                                {
                                    matrix[currRowBeaver, currColBeaver - 1] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currColBeaver = 0;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }
                            else
                            {
                                currColBeaver++;
                                currColBeaver = 0;
                                if (matrix[currRowBeaver, currColBeaver - 1] == '-')
                                {
                                    matrix[currRowBeaver, currColBeaver - 1] = 'B';
                                }
                                else if (matrix[currRowBeaver, currColBeaver] == 'F')
                                {
                                    matrix[currRowBeaver, currColBeaver] = '-';
                                    currRowBeaver = matrix.GetLength(0) - 1;
                                }
                                else if (char.IsLower(matrix[currRowBeaver, currColBeaver]))
                                {
                                    woodBrances.Push(matrix[currRowBeaver, currColBeaver]);
                                }
                                matrix[currRowBeaver, currColBeaver] = 'B';
                            }

                        }

                    }

                }
            }

            int counter = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (char.IsLetter(matrix[rows, cols]) && char.IsLower(matrix[rows, cols]))
                    {
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Stack<char> queue = new Stack<char>(woodBrances);
                Console.WriteLine($"The Beaver successfully collect {woodBrances.Count} wood branches: {string.Join(", ", queue)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {counter} branches left.");
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (cols == matrix.GetLength(1) - 1)
                    {
                        Console.Write($"{matrix[rows, cols]}");
                        break;
                    }
                    Console.Write($"{matrix[rows, cols]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
