namespace Snake_Game.Engine
{
    using Snake_Game.Enum;
    using Snake_Game.SnakeBody;
    using Snake_Game.Struct;
    using System;
    using Snake_Game.Contracts;
    using Snake_Game.Exception;
    using Snake_Game.Food;

    public class Game : IGame
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

        public event EventHandler eventPointsReached;

        public virtual void StartEvent(EventArgs e)
        {
            eventPointsReached?.Invoke(this, e);
        }

        public void MoveUp()
        {
            this.currentDirection = this.directions[(int)Direction.Up];
        }

        public void MoveDown()
        {
            this.currentDirection = this.directions[(int)Direction.Down];
        }

        public void MoveRight()
        {
            this.currentDirection = this.directions[(int)Direction.Right];
        }

        public void MoveLeft()
        {
            this.currentDirection = this.directions[(int)Direction.Left];
        }

        public void ExecuteSnakeMove()
        {
            this.Snake.Dequeue();

            var neck = this.Snake.Tail.Neck;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Right].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Right].Row)
                        this.MoveLeft();
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Left].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Left].Row)
                        this.MoveRight();
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Down].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Down].Row)
                        this.MoveUp();
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (this.currentDirection.Col != this.directions[(int)Direction.Up].Col &&
                        this.currentDirection.Row != this.directions[(int)Direction.Up].Row)
                        this.MoveDown();
                }
            }

            var newPosition = new Position(neck.Col + currentDirection.Col, neck.Row + currentDirection.Row);

            if (newPosition.Col < 0) newPosition.Col = Console.WindowWidth - 2;
            if (newPosition.Row < 0) newPosition.Row = Console.WindowHeight - 2;
            if (newPosition.Row >= Console.WindowHeight - 1) newPosition.Row = 0;
            if (newPosition.Col >= Console.WindowWidth - 1) newPosition.Col = 0;

            //game over
            if (this.Snake.Tail.TailElements.Contains(newPosition))
            {
                throw new GameOverException("Your snake has bitten itself :(");
            }

            this.Snake.Enqueue(newPosition);

            this.Snake.SHead.Head = newPosition;
        }
    }
}