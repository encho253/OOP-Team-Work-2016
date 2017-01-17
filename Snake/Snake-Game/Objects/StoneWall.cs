namespace Snake_Game.Objects
{
    using System.Collections.Generic;
    using Snake_Game.Contracts;
    using Snake_Game.Struct;
    using Snake_Game.Engine;

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

        public bool IsHittingInStoneWall(ConsoleGameEngine start)
        {
            if (this.StonesList[0].Position.Row <= start.snake.Tail.Neck.Row &&
                this.StonesList[0].Position.Col <= start.snake.Tail.Neck.Col &&
                this.StonesList[this.StonesList.Count - 1].Position.Row >= start.snake.Tail.Neck.Row &&
                this.StonesList[this.StonesList.Count - 1].Position.Col >= start.snake.Tail.Neck.Col)
            {
                return true;
            }

            return false;
        }
    }
}