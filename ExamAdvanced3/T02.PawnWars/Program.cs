using System;
using System.Linq;

namespace T02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            string[,] matrix = new string[8, 8];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string input = Console.ReadLine();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols].ToString();
                    if (matrix[rows, cols] == "w")
                    {
                        whiteRow = rows;
                        whiteCol = cols;
                    }
                    if (matrix[rows, cols] == "b")
                    {
                        blackCol = cols;
                        blackRow = rows;
                    }
                }
            }

            string[,] matrixNom = new string[8, 8];
            SecondMatrix(matrixNom);

            string final = string.Empty;

            while (true)
            {
                string currWhite = matrix[whiteRow, whiteCol];
                string currBlack = matrix[blackRow, blackCol];

                if (whiteRow < 7)
                {
                    if (whiteRow == blackRow - 1 && whiteCol == blackCol - 1)
                    {
                        whiteRow--;
                        whiteCol--;
                        currWhite = matrixNom[whiteRow, whiteCol];
                        Console.WriteLine($"Game over! White capture on {currWhite}.");
                        break;
                    }
                    whiteRow--;
                    matrix[whiteRow, whiteCol] = "w";
                    currWhite = "-";
                }
                else
                {
                    currWhite = matrixNom[whiteRow, whiteCol];
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {currWhite}.");
                    break;
                }

                if (blackRow > 0)
                {
                    if (whiteRow == blackRow - 1 && whiteCol == blackCol - 1)
                    {
                        blackRow++;
                        blackCol++;
                        currBlack = matrixNom[blackRow, blackCol];
                        Console.WriteLine($"Game over! Black capture on {currBlack}.");
                        break;
                    }
                    blackRow++;
                    matrix[blackRow, blackCol] = "b";
                    currBlack = "-";
                }
                else
                {
                    currBlack = matrixNom[blackRow, blackCol];
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {currBlack}.");

                    break;
                }
            }
        }

        static void SecondMatrix(string[,] matrixNom)
        {
            for (int row = 0; row < matrixNom.GetLength(0); row++)
            {
                string currRow = "abcdefgh";
                for (int col = 0; col < matrixNom.GetLength(1); col++)
                {
                    matrixNom[row, col] = $"{currRow[col]}{matrixNom.GetLength(1) - row}";
                }
            }
        }
    }
}
