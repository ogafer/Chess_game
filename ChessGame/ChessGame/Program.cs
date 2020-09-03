using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8); //creating the board

                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Black), new Position(1, 7));
                board.PutPiece(new King(board, Color.Black), new Position(1, 1));

                board.PutPiece(new Tower(board, Color.White), new Position(3, 5));
                board.PutPiece(new King(board, Color.White), new Position(2, 2));

                GameWindow.printBoardGame(board);

                Console.ReadLine();
            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
