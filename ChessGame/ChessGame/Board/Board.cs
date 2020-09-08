namespace board
{
    class Board
    {
        #region Attributes

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        #endregion

        #region Constructor

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            pieces = new Piece[rows, columns];
        }

        #endregion

        #region Methods
        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }
        public Piece piece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (PieceExistsInPosition(pos))
                throw new BoardExceptions("Already exists a piece in this position!");
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePart(Position position)
        {
            if (piece(position) == null)
                return null;
            Piece aux = piece(position);
            aux.Position = null;
            pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool PositionIsValid(Position pos)
        {
            if(pos.Row<0 || pos.Column > Columns || pos.Column < 0 || pos.Column >= Columns)
                return false;

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!PositionIsValid(pos))
                throw new BoardExceptions("Position not valid!");
        }

        public bool PieceExistsInPosition(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        #endregion
    }
}
