namespace Snake_Game.SnakeBody
{
    using Struct;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Snake_Game.Contracts;
    using SnakeElements;

    public class Snake : IEating
    {            
        public Snake(int tailSize)
        {
            this.Tail = new SnakeTail(tailSize);
            this.Tail.TailElements = new Queue<Position>();
            
            for (int i = 0; i < this.Tail.TailSize; i++)
            {
                this.Tail.TailElements.Enqueue(new Position(i, 0));
            }

            this.SnakeHead = new SnakeHead(this.Tail.TailSize);
        }

        public Snake() : this(SnakeTail.InitialTailSize)
        {

        }

        public SnakeTail Tail { get; set; }

        public SnakeHead SnakeHead { get; set; }

        public void Eat(Position position)
        {
            this.Enqueue(position);
        }

        public void Enqueue(Position position)
        {
            this.Tail.TailElements.Enqueue(position);       
        }

        public Position Dequeue()
        {
            var temp = this.Tail.TailElements.Dequeue();
            Console.SetCursorPosition(temp.Col, temp.Row);
            Console.Write(" ");
            return temp;
        }
    }
}