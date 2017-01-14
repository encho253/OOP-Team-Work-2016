namespace Snake_Game.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Snake_Game.Contracts;
    using Snake_Game.Enum;
    using Snake_Game.Exception;
    using Snake_Game.Food;
    using Snake_Game.Objects;
    using Snake_Game.Struct;
    using SnakeBody;
    using System;
    using System.Threading;
    using Timer;
    using SnakeElements;
    using AbstractClasses;

    public class ConsoleGameEngine : IRunnable
    {
        internal Snake snake;
        private Game game;
        private Mouse mouse;
        private Rabbit rabbit;
        public static int key { get; set; }
        //private List<Food> eggs;

        static ConsoleGameEngine()
        {
            key = 0;
        }

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
            int dynamicCol = Console.WindowWidth / 4;
            int dynamicRow = (Console.WindowHeight / 2) - 1;
            StoneWall bigStoneOne = new StoneWall(new Stone(new Position(dynamicCol, dynamicRow)), 1, 60);
            StoneWall bigStomeTwo = new StoneWall(new Stone(new Position(dynamicCol, dynamicRow + 1)), 1, 60);

            Stone stone = new Stone(new Position(20, 10));
            int eventPointsSize = 100;
            int sleepTime = 100;
            try
            {
                while (true)
                {
                    start.Draw();

                    lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                    lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);

                    //relocate the smallEgg if the smallEgg and the bigEgg are on the same position
                    if (key == 0 ? smallEgg.IsRelocatePositionShort(bigEgg, moveFoodRabbit.Food, moveFoodMouse.Food, stone) :
                        smallEgg.IsRelocatePosition(bigStoneOne, bigStomeTwo, bigEgg, moveFoodRabbit.Food, moveFoodMouse.Food, stone))
                    /*smallEgg.Position.Equals(bigEgg.Position)
                    || smallEgg.Position.Equals(moveFoodRabbit.Food.Position)
                    || smallEgg.Position.Equals(moveFoodMouse.Food.Position))*/
                    {
                        lastTimeSmallEgg = FoodTimer.DrawNewFood(smallEgg, lastTimeSmallEgg);
                    }

                    //relocate the bigEgg if the smallEgg and the bigEgg are on the same position
                    if (key == 0 ? bigEgg.IsRelocatePositionShort(moveFoodRabbit.Food, moveFoodMouse.Food, stone) :
                        bigEgg.IsRelocatePosition(bigStoneOne, bigStomeTwo, smallEgg, moveFoodRabbit.Food, moveFoodMouse.Food, stone))
                    /*bigEgg.Position.Equals(smallEgg.Position)
                    || bigEgg.Position.Equals(moveFoodRabbit.Food.Position)
                    || bigEgg.Position.Equals(moveFoodMouse.Food.Position))*/
                    {
                        lastTimeBigEgg = FoodTimer.DrawNewFood(bigEgg, lastTimeBigEgg);
                    }

                    if (key == 0 ? moveFoodMouse.Food.IsRelocatePositionShort(smallEgg, moveFoodRabbit.Food, bigEgg, stone) :
                        moveFoodMouse.Food.IsRelocatePosition(bigStoneOne, bigStomeTwo, smallEgg, moveFoodRabbit.Food, bigEgg, stone))
                    {
                        moveFoodMouse.Food.Position = Food.NewPosition();
                    }

                    if (key == 0 ? moveFoodRabbit.Food.IsRelocatePositionShort(smallEgg, moveFoodMouse.Food, bigEgg, stone) :
                        moveFoodRabbit.Food.IsRelocatePosition(bigStoneOne, bigStomeTwo, smallEgg, moveFoodMouse.Food, bigEgg, stone))
                    {
                        moveFoodRabbit.Food.Position = Food.NewPosition();
                    }

                    //eating the snake
                    if (start.snake.Tail.Neck.Row == smallEgg.Position.Row && start.snake.Tail.Neck.Col == smallEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        lastTimeSmallEgg = FoodTimer.DrawNewFood(smallEgg, lastTimeSmallEgg);
                        Score.AddPoints(100);
                        sleepTime -= 15;
                    }
                    else if (start.snake.Tail.Neck.Row == bigEgg.Position.Row && start.snake.Tail.Neck.Col == bigEgg.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        lastTimeBigEgg = FoodTimer.DrawNewFood(bigEgg, lastTimeBigEgg);
                        Score.AddPoints(150);
                        sleepTime -= 15;
                    }
                    else if (start.snake.Tail.Neck.Row == moveFoodMouse.Food.Position.Row &&
                             start.snake.Tail.Neck.Col == moveFoodMouse.Food.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        moveFoodMouse.Food.Position = Food.NewPosition();
                        Score.AddPoints(200);
                        sleepTime -= 15;
                    }
                    else if (start.snake.Tail.Neck.Row == moveFoodRabbit.Food.Position.Row &&
                             start.snake.Tail.Neck.Col == moveFoodRabbit.Food.Position.Col)
                    {
                        start.snake.Eat(start.snake.Tail.TailElements.Last());
                        moveFoodRabbit.Food.Position = Food.NewPosition();
                        Score.AddPoints(250);
                        sleepTime -= 15;
                    }
                    else
                    {
                        start.game.ExecuteSnakeMove();
                    }

                    //check if snake is hit in stone wall
                    if ((key == 0 ? false : bigStoneOne.IsHittingInStoneWall(start)) || (key == 0 ? false : bigStomeTwo.IsHittingInStoneWall(start)) ||
                        start.snake.Tail.Neck.Equals(stone.Position))
                    {
                        throw new GameOverException("Your snake hit the stone wall :(");
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

                    if (ConsoleGameEngine.key == 1)
                    {
                        bigStoneOne.Draw();
                        bigStomeTwo.Draw();
                    }
                    stone.Draw();
                    start.game.eventPointsReached += Event_PointsReached;
                    if (Score.Points >= eventPointsSize) start.game.StartEvent(EventArgs.Empty);
                    if (sleepTime < 0)
                    {
                        sleepTime = 14;
                    }
                    Thread.Sleep(sleepTime);
                    //Console.Clear();
                }
            }
            catch (GameOverException ex)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("GAME OVER!!!");
                Console.WriteLine(ex.Message);
                long maxScore = FileScore.LoadMaxScore();
                if (Score.Points >= maxScore)
                {
                    FileScore.SaveMaxScore(Score.Points);
                    Console.WriteLine("Your score is maximum: {0}", Score.Points);
                }
                else
                {
                    Console.WriteLine("Your score: {0}", Score.Points);
                    Console.WriteLine("Max score is: {0}", maxScore);

                }

                Thread.Sleep(sleepTime);
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
                Console.WriteLine(this.snake.Tail.Symbol);
            }

            Console.SetCursorPosition(this.snake.SnakeHead.Head.Col, snake.SnakeHead.Head.Row);
            Console.WriteLine(this.snake.SnakeHead.Symbol);
        }
        public void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void Event_PointsReached(object sender, EventArgs e)
        {
            key = 1;
        }
    }
}