using System;
using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.AbstractClasses
{
    public abstract class Food : IDrawing
    {
        private Position position;
        private string name;

        public Position Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        abstract public void DrawingFood();

        public Position NewPosition()
        {
            Position foodposition;
            Random randomNumbersGenerator = new Random();
            do
            {
                foodposition = new Position(randomNumbersGenerator.Next(0, Console.WindowWidth),
                   randomNumbersGenerator.Next(0, Console.WindowHeight));
            }
            while (false); //(snakeElements.Contains(food) || obstacles.Contains(food));
            return foodposition;
        }
    }
}