using Snake_Game.Food;

namespace Snake_Game.Engine
{
    using SnakeBody;
    using System;
    using System.Threading;
    using Timer;
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
            Console.CursorVisible = false;
            var start = new ConsoleGameEngine();

            var smallEgg = new SmallEgg();
            var bigEgg = new BigEgg();
            int lastTimeSmallEgg = 0;
            int lastTimeBigEgg = 0;
            int foodDissapearTime = 8000;
            
            while (true)
            {
                start.Draw();
                start.game.Move();

                lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);


                mouse.Move();
                rabbit.Move();
                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

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
            Console.BufferWidth = Console.WindowWidth =125;
        }
    }
}