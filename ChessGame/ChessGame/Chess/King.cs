using board;

namespace Chess
{
    class King : Piece
    {
        #region Constructor
        public King(Board board, Color color) : base(board, color) { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Above
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //Above right
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //right
            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //below right
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //below
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //below left
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //left
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            //above right
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
            return matrix;
        }
        #endregion
    }
}
