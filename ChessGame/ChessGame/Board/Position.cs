namespace board
{
    class Position
    {
        #region Attributes

        public int Row { get; set; }
        public int Column { get; set; }

        #endregion

        #region Constructor

        public Position (int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        #endregion

        #region Methods

        public void DefineValues(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public override string ToString()
        {
            return Row + "," + Column;
        }
        #endregion
    }
}
