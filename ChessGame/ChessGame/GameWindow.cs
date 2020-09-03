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
                Console.Write(8 - i + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("    A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
                Console.Write(piece);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
