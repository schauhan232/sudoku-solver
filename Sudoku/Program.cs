using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] puzzleBoard = new int[,]
            {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}

            };

            int puzzleSize = puzzleBoard.GetLength(0);

            if (SolveSudoku(puzzleBoard))
            {
                PrintSolution(puzzleBoard, puzzleSize); // print solution
            }

            Console.ReadKey();
        }

        public static bool isValid(
            int[,] board,
            int row,
            int col,
            int num)
        {
            var isUsed = UsedInRow(board, row, num)
                || UsedInColumn(board, col, num)
                || UsedInBox(board, (row / 3) * 3, (col / 3) * 3, num);
            return !isUsed;
        }

        public static bool CheckIsUnAssignedLocationExsits(int[,] puzzleBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    return puzzleBoard[row, col] == 0;
                }
            }

            return false;
        }

        public static bool SolveSudoku(int[,] puzzleBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (puzzleBoard[row, col] == 0)
                    {
                        for (int number = 1; number <= 9; number++)
                        {
                            if (isValid(puzzleBoard, row, col, number))
                            {
                                puzzleBoard[row, col] = number;

                                if (SolveSudoku(puzzleBoard))
                                {
                                    return true;
                                }

                                puzzleBoard[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool UsedInRow(
            int[,] puzzleBoard, 
            int row, 
            int number)
        {
            for (int column = 0; column < 9; column++)
            {
                if (puzzleBoard[row, column] == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UsedInColumn(
            int[,] puzzleBoard, 
            int col, 
            int number)
        {
            for (int row = 0; row < 9; row++)
            {
                if (puzzleBoard[row, col] == number)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool UsedInBox(
            int[,] puzzleBoard, 
            int boxStartRow, 
            int boxStartColumn, 
            int number)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    return puzzleBoard[i + boxStartRow, j + boxStartColumn] == number;
                }
            }
            return false;
        }

        public static void PrintSolution(int[,] board, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    Console.Write(board[row, column]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}