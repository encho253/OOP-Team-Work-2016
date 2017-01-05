namespace Snake_Game.Struct
{
    public struct Position
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public Position(int col, int row)
        {
            this.Col = col;
            this.Row = row;           
        }      
    }
}