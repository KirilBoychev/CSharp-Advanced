using System;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int black = 0;
            int white = 0;
            int summer = 0;
            int boarCollection = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    matrix[rows, cols] = input[cols];
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commandArr = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string commandName = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int col = int.Parse(commandArr[2]);

                if (commandName == "Collect")
                {
                    if (row > -1 && row < matrix.GetLength(0) && col > -1 && col < matrix.GetLength(1))
                    {
                        if (matrix[row,col] == 'B')
                        {
                            black++;
                        }
                        else if (matrix[row, col] == 'W')
                        {
                            white++;
                        }
                        else if (matrix[row, col] == 'S')
                        {
                            summer++;
                        }
                        matrix[row, col] = '-';

                    }
                }
                else if (commandName == "Wild_Boar")
                {
                    char currCell = matrix[row, col];
                    string direction = commandArr[3];
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (matrix[i,col] != '-')
                            {
                                boarCollection++;
                                matrix[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                        {
                            if (matrix[i, col] != '-')
                            {
                                boarCollection++;
                                matrix[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (matrix[row, i] != '-')
                            {
                                boarCollection++;
                                matrix[row, i] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i += 2)
                        {
                            if (matrix[row, i] != '-')
                            {
                                boarCollection++;
                                matrix[row, i] = '-';
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarCollection} truffles.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
