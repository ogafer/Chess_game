namespace board
{
    class Piece
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

        #endregion
    }
}
