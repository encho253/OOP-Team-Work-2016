﻿namespace Snake_Game.Struct
{
    public struct Position
    {
        public int row { get;  set; }
        public int col { get;  set; }
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
