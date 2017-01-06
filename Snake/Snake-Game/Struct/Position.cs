namespace Snake_Game.Struct
{
    public struct Position
    {
         public Position(int col, int row)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }     
    }
}
