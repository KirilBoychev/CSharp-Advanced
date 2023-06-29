using System;
using System.Linq;

namespace T02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] inputArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                jagged[row] = new char[inputArr.Length];
                for (int col = 0; col < inputArr.Length; col++)
                {
                    jagged[row][col] = inputArr[col];
                }

            }

            int counterMe = 0;
            int counterOpponent = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commandArr = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string input = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int col = int.Parse(commandArr[2]);

                if (input == "Find")
                {
                    if (row > -1 && row < jagged.Length && col > -1 && col < jagged[row].Length)
                    {
                        if (jagged[row][col] == 'T')
                        {
                            counterMe++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (input == "Opponent")
                {
                    string direction = commandArr[3];
                    if (row > -1 && row < jagged.Length && col > -1 && col < jagged[row].Length)
                    {
                        if (jagged[row][col] == 'T')
                        {
                            counterOpponent++;
                            jagged[row][col] = '-';
                            if (direction == "up")
                            {
                                if (col > -1)
                                {
                                    for (int i = 1; i <= Math.Min(3, row); i++)
                                    {
                                        if (jagged[row - i][col] == 'T')
                                        {
                                            counterOpponent++;
                                            jagged[row - i][col] = '-';
                                        }
                                    }
                                }
                            }
                            else if (direction == "down")
                            {
                                if (col < jagged.Length - 1)
                                {
                                    for (int i = 1; i <= Math.Min(3, jagged.Length - 1 - row); i++)
                                    {
                                        if (jagged[row + i][col] == 'T')
                                        {
                                            counterOpponent++;
                                            jagged[row + i][col] = '-';
                                        }
                                    }
                                }
                            }
                            else if (direction == "left")
                            {
                                if (col > -1)
                                {
                                    for (int i = 1; i <= Math.Min(3, col); i++)
                                    {
                                        if (jagged[row][col - i] == 'T')
                                        {
                                            counterOpponent++;
                                            jagged[row][col - i] = '-';
                                        }
                                    }
                                }
                            }
                            else if (direction == "right")
                            {
                                if (col < jagged[row].Length)
                                {
                                    for (int i = 1; i <= Math.Min(3, jagged[row].Length - 1 - col); i++)
                                    {
                                        if (jagged[row][col + i] == 'T')
                                        {
                                            counterOpponent++;
                                            jagged[row][col + i] = '-';
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write("{0} ", jagged[row][col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {counterMe}");
            Console.WriteLine($"Opponent's tokens: {counterOpponent}");
        }
    }
}
