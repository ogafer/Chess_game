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
        #endregion
    }
}