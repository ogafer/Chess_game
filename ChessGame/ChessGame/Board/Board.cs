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
    }
}
