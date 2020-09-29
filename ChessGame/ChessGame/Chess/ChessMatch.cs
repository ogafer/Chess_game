using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;
        public bool Check { get; private set; }
        #endregion

        #region Constructor
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            pieces = new HashSet<Piece>();
            Check = false;
            capturedPieces = new HashSet<Piece>();
            InsertPieces();
            Finished = false;
        }

        #endregion

        #region Methods

        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePart(origin);
            piece.AddMovementQuantity();
            Piece capturePiece = Board.RemovePart(destination);
            Board.PutPiece(piece, destination);
            if (capturePiece != null)
                capturedPieces.Add(capturePiece);
            return capturePiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = Board.RemovePart(destination);
            p.RemoveMovementQuantity();
            if(capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destination);
                capturedPieces.Remove(capturedPiece);
            }
            Board.PutPiece(p, origin);
        }

        public void MakeTheMovement(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);

            if(ItsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardExceptions("Can´t put yourself in check!");
            }
            if (ItsInCheck(FoeColor(CurrentPlayer)))
                Check = true;
            else
                Check = false;
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in capturedPieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
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

        private Color FoeColor(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if(x is King)
                    return x;
            }
            return null;
        }

        public bool ItsInCheck(Color color)
        {
            Piece k = King(color);
            if (k == null)
                throw new BoardExceptions("Doesn't have king with the color " + color);
            foreach (Piece x in PiecesInGame(FoeColor(color)))
            {
                bool[,] matrix = x.PossibleMovements();
                if (matrix[k.Position.Row, k.Position.Column])
                    return true;
            }
            return false;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new BoardPosition(column, row).ToPosition());
            pieces.Add(piece);
        }

        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Tower(Board, Color.White));
            InsertNewPiece('c', 2, new Tower(Board, Color.White));
            InsertNewPiece('d', 2, new Tower(Board, Color.White));
            InsertNewPiece('e', 2, new Tower(Board, Color.White));
            InsertNewPiece('e', 1, new Tower(Board, Color.White));
            InsertNewPiece('d', 1, new King(Board, Color.White));


            InsertNewPiece('c', 7, new Tower(Board, Color.Black));
            InsertNewPiece('c', 8, new Tower(Board, Color.Black));
            InsertNewPiece('d', 7, new Tower(Board, Color.Black));
            InsertNewPiece('e', 7, new Tower(Board, Color.Black));
            InsertNewPiece('e', 8, new Tower(Board, Color.Black));
            InsertNewPiece('d', 8, new King(Board, Color.Black));
        }
        #endregion


    }
}
