namespace Snake_Game.Engine
{
    using SnakeBody;
    using System;
    using System.Threading;

    public class ConsoleGameEngine
    {
        private Snake snake;
        private Game game;

        public ConsoleGameEngine()
        {
            this.Setup();
            this.game = new Game(new Snake());
            this.snake = this.game.Snake;
        }

        public void Run()
        {
            while (true)
            {
                this.Draw();
                this.game.Move();
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
