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
        #endregion
    }
}
