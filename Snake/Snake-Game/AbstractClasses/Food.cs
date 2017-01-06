using System;
using Snake_Game.Contracts;
using Snake_Game.Struct;
using Snake_Game.Food;

namespace Snake_Game.AbstractClasses
{
    public abstract class Food : IDrawing
    {
        private Position position;
        private string name;
        protected ConsoleColor color = ConsoleColor.White;

        public ConsoleColor Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }
        public Position Position
        {
            get { return this.position; }
            set { this.position = value;}
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        virtual public void DrawingFood()
        {
            Console.SetCursorPosition(Position.Col, Position.Row);
            Console.ForegroundColor = Color;
            Console.Write(Name);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static Position NewPosition()
        {
            Position foodposition;
            Random randomNumbersGenerator = new Random();
            do
            {
                foodposition = new Position(randomNumbersGenerator.Next(0, Console.WindowWidth - 3) + 1,
                   randomNumbersGenerator.Next(0, Console.WindowHeight - 3) + 1);
            }
            while (false); //(snakeElements.Contains(food) || obstacles.Contains(food));
            return foodposition;
        }
    }
}