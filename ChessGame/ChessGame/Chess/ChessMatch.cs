using System;
using board;
namespace Chess
{
    class ChessMatch
    {
        #region Attributes
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void MakeTheMovement(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if(Board.piece(position) == null)
            {
                throw new BoardExceptions("Doesn't exist a piece in the origin selected!");
            }
            if(CurrentPlayer != Board.piece(position).Color)
            {
                throw new BoardExceptions("The selected piece is not yours!");
            }
            if(!Board.piece(position).ExistPossibleMovements())
            {
                throw new BoardExceptions("There is no possible movements for the selected piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if(!Board.piece(origin).PieceCanMoveToPosition(destination))
            {
                throw new BoardExceptions("Destination position not valid!");
            }
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
