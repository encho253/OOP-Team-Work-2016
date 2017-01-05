using System;
using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.Food
{
    class Rabbit : IMovable
    {
        public Rabbit() 
        {
            this.MoveFood = new MoveFood("$", ConsoleColor.Green);
        }

        public MoveFood MoveFood { get; set; }

        public void Move()
        {
            Position newPosition = new Position(this.MoveFood.Position.Row + 1, this.MoveFood.Position.Col);
            this.MoveFood.Position = newPosition;
        }
    }
}