using System;
using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.Food
{
    public class Rabbit : IMovable
    {
        public Rabbit()
        {
            this.MoveFood = new MoveFood("$", ConsoleColor.Green);
        }

        public MoveFood MoveFood { get; set; }

        public void Move()
        {
            if (this.MoveFood.Position.Row <= 0 || this.MoveFood.Position.Row >= Console.WindowWidth - 1 ||
                   this.MoveFood.Position.Col <= 0 || this.MoveFood.Position.Col - 1 > Console.WindowHeight)
            {
                Position oldPosition = this.MoveFood.Position;
                Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                Console.Write(" ");
                this.MoveFood.Position = this.MoveFood.NewPosition();
            }

            Position lastastPositionRabbit = this.MoveFood.Position;

            Position newPosition = new Position(this.MoveFood.Position.Row + 1, this.MoveFood.Position.Col);
            this.MoveFood.Position = newPosition;

            Console.SetCursorPosition(lastastPositionRabbit.Row, lastastPositionRabbit.Col);
            Console.Write(" ");
        }
    }
}
