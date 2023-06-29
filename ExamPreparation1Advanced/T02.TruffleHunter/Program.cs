using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] pond = new char[n, n];

            int rowBeaver = 0;
            int colBeaver = 0;

            int counter = 0;

            Stack<char> woodBranches = new Stack<char>();

            for (int rows = 0; rows < pond.GetLength(0); rows++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int cols = 0; cols < pond.GetLength(1); cols++)
                {
                    pond[rows, cols] = input[cols];
                    if (pond[rows,cols] == 'B')
                    {
                        rowBeaver = rows;
                        colBeaver = cols;
                    }
                    if (char.IsLower(pond[rows, cols]))
                    {
                        counter++;
                    }
                }
            }

            string command = string.Empty;
            while((command = Console.ReadLine()) != "end")
            {
                char currOne;
                int currPosition = pond[rowBeaver, colBeaver];
                if (command == "up")
                {
                    if (rowBeaver != 0)
                    {
                        if (char.IsLower(pond[rowBeaver - 1, colBeaver]))
                        {
                            woodBranches.Push(pond[rowBeaver - 1, colBeaver]);
                        }
                        else if (pond[rowBeaver - 1, colBeaver] == 'F')
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            rowBeaver--;
                            currOne = pond[rowBeaver, colBeaver];
                            if (rowBeaver == 0)
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                rowBeaver = pond.GetLength(0) - 1;
                            }
                            else
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                rowBeaver = 0;
                            }
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                        else
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            rowBeaver--;
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                    }
                    else
                    {
                        if (woodBranches.Count != 0)
                        {
                            woodBranches.Pop();
                        }
                    }
                }
                else if (command == "down")
                {
                    if (rowBeaver != pond.GetLength(0) - 1)
                    {
                        if (char.IsLower(pond[rowBeaver + 1, colBeaver]))
                        {
                            woodBranches.Push(pond[rowBeaver + 1, colBeaver]);
                        }
                        else if (pond[rowBeaver + 1, colBeaver] == 'F')
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            rowBeaver++;
                            currOne = pond[rowBeaver, colBeaver];
                            if (rowBeaver == pond.GetLength(0) - 1)
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                rowBeaver = 0;
                            }
                            else
                            {
                                pond[rowBeaver, colBeaver] = '-'; 
                                rowBeaver = pond.GetLength(0) - 1;
                            }
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                        else
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            rowBeaver++;
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                    }
                    else
                    {
                        if (woodBranches.Count != 0)
                        {
                            woodBranches.Pop();
                        }
                    }
                }
                else if (command == "left")
                {
                    if (colBeaver != 0)
                    {
                        if (char.IsLower(pond[rowBeaver, colBeaver - 1]))
                        {
                            woodBranches.Push(pond[rowBeaver, colBeaver - 1]);
                        }
                        else if (pond[rowBeaver, colBeaver - 1] == 'F')
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            colBeaver--;
                            currOne = pond[rowBeaver, colBeaver];
                            if (colBeaver == 0)
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                colBeaver = pond.GetLength(1) - 1;
                            }
                            else
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                colBeaver = 0;
                            }
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                        else
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            colBeaver--;
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                    }
                    else
                    {
                        if (woodBranches.Count != 0)
                        {
                            woodBranches.Pop();
                        }
                    }
                }
                else if (command == "right")
                {
                    if (colBeaver != pond.GetLength(1) - 1)
                    {
                        if (char.IsLower(pond[rowBeaver, colBeaver + 1]))
                        {
                            woodBranches.Push(pond[rowBeaver, colBeaver + 1]);
                        }
                        else if (pond[rowBeaver, colBeaver - 1] == 'F')
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            colBeaver++;
                            currOne = pond[rowBeaver, colBeaver];
                            if (colBeaver == pond.GetLength(1) - 1)
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                colBeaver = 0;
                            }
                            else
                            {
                                pond[rowBeaver, colBeaver] = '-';
                                colBeaver = pond.GetLength(1) - 1;
                            }
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                        else
                        {
                            pond[rowBeaver, colBeaver] = '-';
                            colBeaver++;
                            currOne = pond[rowBeaver, colBeaver] = 'B';
                        }
                    }
                    else
                    {
                        if (woodBranches.Count != 0)
                        {
                            woodBranches.Pop();
                        }
                    }
                }
            }

            if (counter == woodBranches.Count)
            {
                woodBranches.Reverse();
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: {string.Join(", ", woodBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {counter - woodBranches.Count} branches left");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
