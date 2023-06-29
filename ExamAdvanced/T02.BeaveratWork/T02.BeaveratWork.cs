using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] everyRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
                matrix[row, col] = everyRow[col];
        }

        List<int> collect = new List<int>();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "end")
        {
            bool flag = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (flag == true)
                    break;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (flag == true)
                        break;
                    if (matrix[row, col] == 'B')
                    {
                        if ((row == 0 && command == "up") || (row == matrix.GetLength(0) - 1 && command == "down")
                            || (col == 0 && command == "left") || (col == matrix.GetLength(1) - 1 && command == "right"))
                        {
                            if (collect != null)
                            {
                                collect.RemoveAt(collect.Count - 1);
                            }
                            break;
                        }
                        switch (command)
                        {
                            case "up":
                                {
                                    if (char.IsLetter(matrix[row - 1, col]) && char.IsLower(matrix[row - 1, col]))
                                    {
                                        collect.Add(matrix[row - 1, col]);
                                        matrix[row - 1, col] = matrix[row, col];
                                        matrix[row, col] = '-';
                                        flag = true;
                                        break;
                                    }
                                    else if (matrix[row - 1, col] == '-')
                                    {
                                        matrix[row - 1, col] = matrix[row, col];
                                        matrix[row, col] = '-';
                                        flag = true;
                                        break;
                                    }
                                    else if (matrix[row - 1, col] == 'F')
                                    {
                                        matrix[matrix.GetLength(0) - 1, col] = matrix[row, col];
                                        matrix[row - 1, col] = '-';
                                        matrix[row, col] = '-';
                                        flag = true;
                                        break;
                                    }
                                }
                                break;
                            case "down":
                                if (char.IsLetter(matrix[row + 1, col]) && char.IsLower(matrix[row + 1, col]))
                                {
                                    collect.Add(matrix[row + 1, col]);
                                    matrix[row + 1, col] = matrix[row, col];
                                    matrix[row, col] = '-';
                                    flag = true;
                                    break;
                                }
                                else if (matrix[row + 1, col] == '-')
                                {
                                    matrix[row + 1, col] = matrix[row, col];
                                    matrix[row, col] = '-';
                                    flag = true;
                                    break;
                                }
                                else if (matrix[row + 1, col] == 'F')
                                {
                                    matrix[matrix.GetLength(0) - 1, col] = matrix[row, col];
                                    matrix[row + 1, col] = '-';
                                    matrix[row, col] = '-';
                                    flag = true;
                                    break;
                                }
                                break;
                            case "right":

                                break;
                            case "left":

                                break;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

