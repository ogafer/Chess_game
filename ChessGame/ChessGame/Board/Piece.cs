namespace board
{
    abstract class Piece
    {
        #region Attributes
        public Position Position { get; set; }
        public Color Color { get; protected set; } //only set for the subclasses of this class
        public int QuantityOfMovements { get; protected set; } //only set for the subclasses of this class
        public Board Board { get; protected set; } //only set for the subclasses of this class

        #endregion

        #region Constructor

        public Piece(Board board, Color color)
        {
            this.Position = null;
            this.Board = board;
            this.Color = color;
            this.QuantityOfMovements = 0;
        }

        public void AddMovementQuantity()
        {
            QuantityOfMovements++;
        }

        public void RemoveMovementQuantity()
        {
            QuantityOfMovements--;
        }

        public bool ExistPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PieceCanMoveToPosition(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }
        public abstract bool[,] PossibleMovements();

        #endregion
    }
}
