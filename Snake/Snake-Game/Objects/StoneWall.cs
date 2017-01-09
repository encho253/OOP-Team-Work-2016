using System;
using System.Collections.Generic;

using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.Objects
{
    public class StoneWall : IDrawing
    {
        public StoneWall(Stone stone, int rowLenght, int colLength)
        {
            this.StonesList = new List<Stone>();
            CreateStones(stone, rowLenght, colLength);
        }

        public List<Stone> StonesList { get; set; }

        public void CreateStones(Stone stone, int rowLenght, int colLength)
        {
            Position currentPosition = stone.Position;
            for (int row = 0; row < rowLenght; row++)
            {
                currentPosition.Col = stone.Position.Col;
                currentPosition.Row = stone.Position.Row + row;

                for (int col = 0; col < colLength; col++)
                {
                    currentPosition.Col += 1;

                    StonesList.Add(new Stone(currentPosition));
                }
            }
        }

        public void Draw()
        {
            foreach (var stone in this.StonesList)
            {
                stone.Draw();
            }
        }
    }
}
