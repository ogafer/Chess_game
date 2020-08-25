using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessGame
{
    class GameWindow
    {
        public static void printBoardGame(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i, j) + " ");
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
