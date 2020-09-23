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
                    try
                    {
                        Console.Clear();
                        GameWindow.PrintChessMatch(chessMatch);


                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = GameWindow.ReadChessPosition().ToPosition();
                        chessMatch.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = chessMatch.Board.piece(origin).PossibleMovements();
                        Console.Clear();
                        GameWindow.PrintBoardGame(chessMatch.Board, possiblePositions);

                        Console.Write("Destination: ");
                        Position destination = GameWindow.ReadChessPosition().ToPosition();
                        chessMatch.ValidateDestinationPosition(origin, destination);
                        chessMatch.MakeTheMovement(origin, destination);
                    }
                    catch(BoardExceptions ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
