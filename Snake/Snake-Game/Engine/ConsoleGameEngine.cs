using Snake_Game.Food;
using Snake_Game.Struct;

namespace Snake_Game.Engine
{
    using SnakeBody;
    using System;
    using System.Threading;
    using AbstractClasses;    
    using Timer;
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
            Console.CursorVisible = false;
            var Start = new ConsoleGameEngine();

            var smallEgg = new SmallEgg();
            var bigEgg = new BigEgg();
            int lastTimeSmallEgg = 0;
            int lastTimeBigEgg = 0;
            int foodDissapearTime = 8000;

            Mouse mouse = new Mouse();
            Rabbit rabbit = new Rabbit();
            
            while (true)
            {
                Start.Draw();
                Start.game.Move();

                lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);

                if (mouse.MoveFood.Position.Col == 0 || mouse.MoveFood.Position.Col >= Console.WindowWidth - 1 ||
                     mouse.MoveFood.Position.Row == 0 || mouse.MoveFood.Position.Row - 1 > Console.WindowHeight)
                {
                    Position oldPosition = mouse.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Col, oldPosition.Row);
                    Console.Write(" ");
                    mouse.MoveFood.Position = Food.NewPosition();
                }

                if (rabbit.MoveFood.Position.Col == 0 || rabbit.MoveFood.Position.Col >= Console.WindowWidth - 1 ||
                    rabbit.MoveFood.Position.Row == 0 || rabbit.MoveFood.Position.Row - 1 > Console.WindowHeight)
                {
                    Position oldPosition = rabbit.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Col, oldPosition.Row);
                    Console.Write(" ");
                    rabbit.MoveFood.Position = Food.NewPosition();
                }

                Position lastPositionMouse = mouse.MoveFood.Position;
                Position lastastPositionRabbit = rabbit.MoveFood.Position;
                mouse.Move();
                rabbit.Move();
                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

                Console.SetCursorPosition(lastPositionMouse.Col, lastPositionMouse.Row);
                Console.Write(" ");

                Console.SetCursorPosition(lastastPositionRabbit.Col, lastastPositionRabbit.Row);
                Console.Write(" ");
                Console.CursorVisible = false;

                Thread.Sleep(100);
                //Console.Clear();
            }
        }

        public void Draw()
        {
            foreach (var position in this.snake.TailElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.WriteLine(Snake.ElementSymbol);
            }
        }

        public void Setup()
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth=125;
        }
    }
}
