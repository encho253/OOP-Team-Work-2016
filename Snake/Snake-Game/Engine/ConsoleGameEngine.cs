using Snake_Game.Food;
using Snake_Game.Struct;

namespace Snake_Game.Engine
{
    using SnakeBody;
    using System;
    using System.Threading;

    public class ConsoleGameEngine
    {
        private Snake snake;
        private Game game;
        private Mouse mouse;
        private Rabbit rabbit;

        public ConsoleGameEngine()
        {
            this.Setup();
            this.game = new Game(new Snake(), new Mouse(), new Rabbit());
            this.snake = this.game.Snake;
            this.mouse = this.game.Mouse;
            this.rabbit = this.game.Rabbit;
        }

        public void Run()
        {
            while (true)
            {
                this.Draw();
                this.game.Move();

                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

                Console.CursorVisible = false;
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        public void Draw()
        {
            foreach (var position in this.snake.TailElements)
            {
                Console.SetCursorPosition(position.Row, position.Col);
                Console.WriteLine(Snake.ElementSymbol);
            }
        }

        public void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
    }
}