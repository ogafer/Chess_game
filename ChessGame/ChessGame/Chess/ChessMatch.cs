using System;
using board;
namespace Chess
{
    class ChessMatch
    {
        #region Attributes
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }
        #endregion

        #region Constructor
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            InsertPieces();
            Finished = false;
        }

        #endregion

        #region Methods

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePart(origin);
            piece.AddMovementQuantity();
            Piece capturePiece = Board.RemovePart(destination);
            Board.PutPiece(piece, destination);
        }

        private void InsertPieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new BoardPosition('c', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new BoardPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new BoardPosition('d', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new BoardPosition('e', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new BoardPosition('e', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new BoardPosition('d', 1).ToPosition());

            Board.PutPiece(new Tower(Board, Color.Black), new BoardPosition('c', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new BoardPosition('c', 8).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new BoardPosition('d', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new BoardPosition('e', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new BoardPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new BoardPosition('d', 8).ToPosition());
        }
        #endregion


    }
}
