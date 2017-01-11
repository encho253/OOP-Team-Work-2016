using System;
using System.Collections.Generic;

using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.Objects
{
    public class StoneWall : Stone
    {


        public StoneWall(Position position, int rowLenght, int colLength) : base(position)
        {
            this.StonesList = new List<Position>();
            CreateStones(position, rowLenght, colLength);
        }

        public List<Position> StonesList { get; set; }

        public void CreateStones(Position position, int rowLenght, int colLength)
        {
            Position currentPosition = position;
            for (int row = 0; row < rowLenght; row++)
            {
                currentPosition.Col = position.Col;
                currentPosition.Row = position.Row + row;

                for (int col = 0; col < colLength; col++)
                {
                    currentPosition.Col += 1;

                    StonesList.Add(new Position(currentPosition.Col, currentPosition.Row));
                }
            }
        }

        public override void Draw()
        {
            foreach (var position in this.StonesList)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.WriteLine(this.Name);
            }
        }
    }
}
