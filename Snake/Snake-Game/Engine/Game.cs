using System;
using Snake_Game.Food;

namespace Snake_Game.Engine
{
    using Snake_Game.Enum;
    using Snake_Game.SnakeBody;
    using Snake_Game.Struct;

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
            this.directions[0] = new Position(0, 0);
            this.directions[1] = new Position(-1, 0);
            this.directions[2] = new Position(0, 1);
            this.directions[3] = new Position(0, -1);
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

            this.Snake.TailElements.Dequeue();
            var head = this.Snake.Head;

            var newPosition = new Position(head.Row + currentDirection.Row,head.Col + currentDirection.Col);

            this.Snake.Enqueue(newPosition);
             
            this.Mouse.Move();
            this.Rabbit.Move();
        }
    }
}