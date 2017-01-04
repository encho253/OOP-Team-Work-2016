using System;
using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.Food
{
    public class Mouse : IMovable
    {
        public Mouse() 
        {
            this.MoveFood = new MoveFood("&", ConsoleColor.Green);
        }

        public MoveFood MoveFood { get; set; }
        public void Move()
        {
            Position newPosition = new Position(this.MoveFood.Position.Row, this.MoveFood.Position.Col - 1);
            this.MoveFood.Position = newPosition;
        }
    }
}