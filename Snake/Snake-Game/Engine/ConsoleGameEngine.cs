namespace Snake_Game.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Snake_Game.Contracts;
    using Snake_Game.Enum;
    using Snake_Game.Exception;
    using Snake_Game.Food;
    using SnakeBody;
    using System;
    using System.Threading;
    using Timer;
    using SnakeElements;
    using AbstractClasses;

    public class ConsoleGameEngine : IRunnable
    {
        private Snake snake;
        private Game game;
        private Mouse mouse;
        private Rabbit rabbit;
        private List<Food> eggs;

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

            Food smallEgg = new SmallEgg();
            Food bigEgg = new BigEgg();
            int lastTimeSmallEgg = 0;
            int lastTimeBigEgg = 0;
            int foodDissapearTime = 8000;

            MoveFood moveFoodMouse = new MoveFood(mouse, Direction.UpLeft);
            MoveFood moveFoodRabbit = new MoveFood(rabbit, Direction.DownRight);

            try
            {
                while (true)
                {
                    start.Draw();

                    lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                    lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);

                    //relocate the smallEgg if the smallEgg and the bigEgg are on the same position
                    if (smallEgg.Position.Equals(bigEgg.Position)
                        || smallEgg.Position.Equals(moveFoodRabbit.Food.Position)
                        || smallEgg.Position.Equals(moveFoodMouse.Food.Position))
                    {
                        smallEgg.Position = Food.NewPosition();
                    }

                    //relocate the bigEgg if the smallEgg and the bigEgg are on the same position
                    if (bigEgg.Position.Equals(smallEgg.Position)
                        || bigEgg.Position.Equals(moveFoodRabbit.Food.Position)
                        || bigEgg.Position.Equals(moveFoodMouse.Food.Position))
                    {
                        bigEgg.Position = Food.NewPosition();
                    }

                    //eating the snake
                    if (start.snake.Tail.Neck.Row == smallEgg.Position.Row && start.snake.Tail.Neck.Col == smallEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        smallEgg.Position = Food.NewPosition();
                        Score.AddPoints(100);
                    }
                    else if (start.snake.Tail.Neck.Row == bigEgg.Position.Row && start.snake.Tail.Neck.Col == bigEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        bigEgg.Position = Food.NewPosition();
                        Score.AddPoints(150);
                    }
                    else if (start.snake.Tail.Neck.Row == moveFoodMouse.Food.Position.Row &&
                             start.snake.Tail.Neck.Col == moveFoodMouse.Food.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        moveFoodMouse.Food.Position = Food.NewPosition();
                        Score.AddPoints(200);
                    }
                    else if (start.snake.Tail.Neck.Row == moveFoodRabbit.Food.Position.Row &&
                             start.snake.Tail.Neck.Col == moveFoodRabbit.Food.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        moveFoodRabbit.Food.Position = Food.NewPosition();
                        Score.AddPoints(250);
                    }
                    else
                    {
                        start.game.ExecuteSnakeMove();
                    }


                    Random random = new Random();
                    if (random.Next(1, 1000) % 2 == 0 && random.Next(1, 1000) % 3 == 0)
                    {
                        moveFoodRabbit.Move();
                    }

                    if (random.Next(1, 1000) % 5 == 0)
                    {
                        moveFoodMouse.Move();
                    }

                    moveFoodMouse.Food.Draw();
                    moveFoodRabbit.Food.Draw();

                    Thread.Sleep(100);
                    //Console.Clear();
                }
            }
            catch (GameOverException ex)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("GAME OVER!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Your score: {0}", Score.Points);
                Thread.Sleep(10000);
            }

            finally
            {
                Environment.Exit(0);
            }
        }

        public void Draw()
        {
            foreach (var position in this.snake.Tail.TailElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.WriteLine(SnakeTail.ElementSymbol);
            }

            Console.SetCursorPosition(this.snake.SHead.Head.Col, snake.SHead.Head.Row);
            Console.WriteLine(SnakeHead.Symbol);
        }

        public void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
    }
}