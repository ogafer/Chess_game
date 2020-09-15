using board;

namespace Chess
{
    class Tower : Piece
    {
        #region Constructor
        public Tower(Board board, Color color) : base(board, color) { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "T";
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
            while (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }
            

            //Below
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }
            

            //Right
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            //Left
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Board.PositionIsValid(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }





            return matrix;
        }
        #endregion
    }
}