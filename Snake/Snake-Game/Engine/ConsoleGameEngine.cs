using System.Collections.Generic;
using System.Linq;
using Snake_Game.Exception;
using Snake_Game.Food;
using Snake_Game.Struct;

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
        private List<AbstractClasses.Food> eggs;

        public ConsoleGameEngine()
        {
            this.Setup();
            this.game = new Game(new Snake(), new Mouse(), new Rabbit());
            this.snake = this.game.Snake;
            this.mouse = this.game.Mouse;
            this.rabbit = this.game.Rabbit;
            eggs = new List<AbstractClasses.Food>();
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

            try
            {
                while (true)
                {
                    start.Draw();


                    lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                    lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);

                    //relocate the smallEgg if the smallEgg and the bigEgg are on the same position
                    if (smallEgg.Position.Equals(bigEgg.Position)
                        || smallEgg.Position.Equals(rabbit.MoveFood.Position)
                        || smallEgg.Position.Equals(mouse.MoveFood.Position))
                    {
                        smallEgg.Position = AbstractClasses.Food.NewPosition();
                    }

                    //relocate the bigEgg if the smallEgg and the bigEgg are on the same position
                    if (bigEgg.Position.Equals(smallEgg.Position)
                        || bigEgg.Position.Equals(rabbit.MoveFood.Position)
                        || bigEgg.Position.Equals(mouse.MoveFood.Position))
                    {
                        bigEgg.Position = AbstractClasses.Food.NewPosition();
                    }

                    //eating the snake
                    if (start.snake.Head.Row == smallEgg.Position.Row && start.snake.Head.Col == smallEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.TailElements.Last());
                        smallEgg.Position = AbstractClasses.Food.NewPosition();
                        Score.AddPoints(100);
                    }
                    else if (start.snake.Head.Row == bigEgg.Position.Row && start.snake.Head.Col == bigEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.TailElements.Last());
                        bigEgg.Position = AbstractClasses.Food.NewPosition();
                        Score.AddPoints(150);
                    }
                    else if (start.snake.Head.Row == mouse.MoveFood.Position.Row &&
                             start.snake.Head.Col == mouse.MoveFood.Position.Col)
                    {
                        start.snake.Eat(start.snake.TailElements.Last());
                        mouse.MoveFood.Position = AbstractClasses.Food.NewPosition();
                        Score.AddPoints(200);
                    }
                    else if (start.snake.Head.Row == rabbit.MoveFood.Position.Row &&
                             start.snake.Head.Col == rabbit.MoveFood.Position.Col)
                    {
                        start.snake.Eat(start.snake.TailElements.Last());
                        rabbit.MoveFood.Position = AbstractClasses.Food.NewPosition();
                        Score.AddPoints(250);
                    }
                    else
                    {
                        start.game.ExecuteSnakeMove();
                    }


                    Random random = new Random();
                    if (random.Next(1, 1000)%2 == 0 && random.Next(1, 1000) % 3 == 0)
                    {
                        rabbit.Move();
                    }

                    if (random.Next(1, 1000)%5 == 0)
                    {
                        mouse.Move();
                    }

                    mouse.MoveFood.Draw();
                    rabbit.MoveFood.Draw();




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
            foreach (var position in this.snake.TailElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
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