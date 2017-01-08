using System.Threading;
using Snake_Game.Exception;
using Snake_Game.Food;

namespace Snake_Game.Engine
{
    using Snake_Game.Enum;
    using Snake_Game.SnakeBody;
    using Snake_Game.Struct;
    using System;

    public class Game
    {
        private Position[] directions;
        private Position currentDirection;

        public Game(Snake snake, Mouse mouse, Rabbit rabbit)
        {
            this.Snake = snake;
            this.Mouse = mouse;
            this.Rabbit = rabbit;
            this.directions = new Position[4];
            this.directions[0] = new Position(1, 0);//Right
            this.directions[1] = new Position(-1, 0);//Left
            this.directions[2] = new Position(0, -1);//Up
            this.directions[3] = new Position(0, 1);//Down
            this.currentDirection = this.directions[(int)Direction.Right];
        }

        public Snake Snake { get; set; }
        public Mouse Mouse { get; set; }
        public Rabbit Rabbit { get; set; }

        public void Up()
        {
            this.currentDirection = this.directions[(int)Direction.Up];
        }

        public void Down()
        {
            this.currentDirection = this.directions[(int)Direction.Down];
        }

        public void Right()
        {
            this.currentDirection = this.directions[(int)Direction.Right];
        }

        public void Left()
        {
            this.currentDirection = this.directions[(int)Direction.Left];
        }

        public void Move()
        {
            this.Snake.MyDequeue();

            var head = this.Snake.Head;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Right].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Right].Row)
                        this.Left();
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Left].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Left].Row)
                        this.Right();
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Down].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Down].Row)
                        this.Up();
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Up].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Up].Row)
                        this.Down();
                }
            }

            var newPosition = new Position(head.Col + currentDirection.Col, head.Row + currentDirection.Row);

            if (newPosition.Col < 0) newPosition.Col = Console.WindowWidth - 1;
            if (newPosition.Row < 0) newPosition.Row = Console.WindowHeight - 2;
            if (newPosition.Row >= Console.WindowHeight - 1) newPosition.Row = 0;
            if (newPosition.Col >= Console.WindowWidth) newPosition.Col = 0;

            //game over
            if (this.Snake.TailElements.Contains(newPosition))
            {
               throw new GameOverException("Your snake has bitten itself :(");
            }

            this.Snake.Enqueue(newPosition);
        }
    }
}