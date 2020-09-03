using board;

namespace Chess
{
    class BoardPosition
    {
        #region Attributes
        public char Column { get; set; }
        public int Row { get; set; }
        #endregion

        #region Constructor
        public BoardPosition(char column, int row)
        {
            this.Column = column;
            this.Row = row;
        }
        #endregion

        #region Methods

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }

        #endregion
    }
}
