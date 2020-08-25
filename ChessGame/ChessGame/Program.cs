using System;
using Board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position;
            position = new Position(3, 4);

            Console.WriteLine("Position: " + position);
            Console.ReadLine();
        }
    }
}
