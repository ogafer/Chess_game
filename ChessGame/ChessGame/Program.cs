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
                ChessMatch chessMatch = new ChessMatch();

                while(!chessMatch.Finished)
                {
                    Console.Clear();
                    GameWindow.printBoardGame(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = GameWindow.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = GameWindow.ReadChessPosition().ToPosition();

                    chessMatch.ExecuteMovement(origin, destination);
                }

            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
