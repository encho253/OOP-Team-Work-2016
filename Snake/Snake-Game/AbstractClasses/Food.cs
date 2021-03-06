﻿namespace Snake_Game.AbstractClasses
{
    using System;
    using Snake_Game.Struct;
    using System.Threading;

    public abstract class Food : GameObject
    {
        protected ConsoleColor color = ConsoleColor.White;

        public ConsoleColor Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }

        public override void Draw()
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
            Thread.Sleep(5);
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