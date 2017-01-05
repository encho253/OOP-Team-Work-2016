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

        public ConsoleGameEngine()
        {
            this.Setup();
            this.game = new Game(new Snake());
            this.snake = this.game.Snake;
        }

        public void Run()
        {
            Mouse mouse = new Mouse();
            Rabbit rabbit = new Rabbit();
            while (true)
            {
                this.Draw();
                this.game.Move();

                if (mouse.MoveFood.Position.Row <= 0 || mouse.MoveFood.Position.Row >= Console.WindowWidth - 1 ||
                     mouse.MoveFood.Position.Col <= 0 || mouse.MoveFood.Position.Col - 1 > Console.WindowHeight)
                {
                    Position oldPosition = mouse.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                    Console.Write(" ");
                    mouse.MoveFood.Position = mouse.MoveFood.NewPosition();
                }

                if (rabbit.MoveFood.Position.Row <= 0 || rabbit.MoveFood.Position.Row >= Console.WindowWidth - 1 ||
                    rabbit.MoveFood.Position.Col <= 0 || rabbit.MoveFood.Position.Col - 1 > Console.WindowHeight)
                {
                    Position oldPosition = rabbit.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                    Console.Write(" ");
                    rabbit.MoveFood.Position = rabbit.MoveFood.NewPosition();
                }

                Position lastPositionMouse = mouse.MoveFood.Position;
                Position lastastPositionRabbit = rabbit.MoveFood.Position;
                mouse.Move();
                rabbit.Move();
                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

                Console.SetCursorPosition(lastPositionMouse.Row, lastPositionMouse.Col);
                Console.Write(" ");

                Console.SetCursorPosition(lastastPositionRabbit.Row, lastastPositionRabbit.Col);
                Console.Write(" ");
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
