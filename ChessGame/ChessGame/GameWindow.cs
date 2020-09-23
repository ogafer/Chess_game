using System;
using System.Collections.Generic;
using System.Text;
using board;
using Chess;

namespace ChessGame
{
    class GameWindow
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            GameWindow.PrintBoardGame(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessMatch.Turn);
            Console.WriteLine("Waiting for: " + chessMatch.CurrentPlayer);
        }

        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintPiecesGroup(chessMatch.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintPiecesGroup(chessMatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintPiecesGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece x in group)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }


        public static void PrintBoardGame(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("    A B C D E F G H");
        }

        public static void PrintBoardGame(Board board, bool[,] possiblePositions)
        {
            ConsoleColor actualBackground = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i,j])
                    {
                        Console.BackgroundColor = changeBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = actualBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = actualBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("    A B C D E F G H");
            Console.BackgroundColor = actualBackground;
        }

        public static BoardPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new BoardPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
