using System;
using System.Linq;

namespace T02_Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string input = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }


            int currRow = 0;
            int currCol = 0;

            int sum = 0;
            while (true)
            {
                string command = Console.ReadLine();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'A')
                        {
                            currRow = i;
                            currCol = j;
                        }
                    }
                }

                int previousRow = currRow;
                int previousCol = currCol;

                if (command == "right")
                {
                    currCol++;
                }
                else if (command == "left")
                {
                    currCol--;
                }
                else if (command == "down")
                {
                    currRow++;
                }
                else if (command == "up")
                {
                    currRow--;
                }

                if (currRow < 0 || currRow > matrix.GetLength(0) - 1 || currCol < 0 || currCol > matrix.GetLength(1) - 1)
                {
                    matrix[previousRow, previousCol] = '-';
                    break;
                }

                matrix[previousRow, previousCol] = '-';

                if (char.IsDigit(matrix[currRow, currCol]))
                {
                    sum += matrix[currRow, currCol] - '0';
                    matrix[currRow, currCol] = 'A';
                    if (sum >= 65)
                    {
                        break;
                    }
                }

                if (matrix[currRow, currCol] == 'M')
                {
                    matrix[currRow, currCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'M')
                            {
                                matrix[row, col] = 'A';
                            }
                        }
                    }
                }
            }

            if (sum < 65)
            {
                Console.WriteLine($"I do not need more swords!");
            }
            else
            {
                Console.WriteLine($"Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {sum} gold coins.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
