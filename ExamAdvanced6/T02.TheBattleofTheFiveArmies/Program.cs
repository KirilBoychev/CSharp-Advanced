using System;
using System.Linq;

namespace T02.TheBattleofTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int m = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                m = input.Length;
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            int counter = 0;

            int currRow = 0;
            int currCol = 0;

            int rowMordor = 0;
            int colMordor = 0;

            while (armor > 0)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string com = command[0];
                int rowOrg = int.Parse(command[1]);
                int colOrg = int.Parse(command[2]);

                for (int rows = 0; rows < n; rows++)
                    for (int cols = 0; cols < m; cols++)
                    {
                        if (matrix[rows][cols] == 'A')
                        {
                            currRow = rows;
                            currCol = cols;
                        }
                        if (matrix[rows][cols] == 'M')
                        {
                            rowMordor = rows;
                            colMordor = cols;
                        }
                        if (rows == rowOrg && cols == colOrg)
                        {
                            matrix[rows][cols] = 'O';
                        }
                    }

            if (com == "up")
            {
                if (currRow > 0)
                {
                    currRow--;
                    matrix[currRow][currCol] = 'A';
                    matrix[currRow + 1][currCol] = '-';
                }
            }
            else if (com == "down")
            {
                if (currRow < n - 1)
                {
                    currRow++;
                    matrix[currRow][currCol] = 'A';
                    matrix[currRow - 1][currCol] = '-';
                }
            }
            else if (com == "left")
            {
                if (currCol > 0)
                {
                    currCol--;
                    matrix[currRow][currCol] = 'A';
                    matrix[currRow][currCol + 1] = '-';
                }
            }
            else if (com == "right")
            {
                if (currCol < m -1)
                {
                    currCol++;
                    matrix[currRow][currCol] = 'A';
                    matrix[currRow][currCol - 1] = '-';
                }
            }
            armor--;

            if (currRow == rowOrg && currCol == colOrg)
            {
                armor -= 2;
            }

            if (currCol == colMordor && currRow == rowMordor)
            {
                matrix[currRow][currCol] = '-';
                counter++;
                break;
            }

            if (armor <= 0)
            {
                matrix[currRow][currCol] = 'X';
            }
        }

            if (counter == 1)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
            }

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < m; cols++)
                {
                    Console.Write(String.Join("", matrix[rows][cols]));
                }
                Console.WriteLine();
            }
        }
    }
}
