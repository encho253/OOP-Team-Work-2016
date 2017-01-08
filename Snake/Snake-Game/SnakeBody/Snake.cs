using Snake_Game.Contracts;

namespace Snake_Game.SnakeBody
{
    using Struct;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Snake : IEating
    {
        public const int InitialTailSize = 5;
        public const char ElementSymbol = '*';

        private Queue<Position> tailElements;
        private int tailSize;

        public Snake(int tailSize)
        {
            this.tailSize = tailSize;
            this.tailElements = new Queue<Position>();
           
            for (int i = 0; i < this.tailSize; i++)
            {
                this.tailElements.Enqueue(new Position(i, 0));
            }
        }

        public Snake() : this(InitialTailSize)
        {

        }

        public Queue<Position> TailElements
        {
            get
            {
                return new Queue<Position>(this.tailElements);
            }             
        }
        public Position Head
        {
            get
            {
                return this.tailElements.Last();
            }
        }

        public void Eat(Position position)
        {
            this.Enqueue(position);
        }

        public void Enqueue(Position position)
        {
            this.tailElements.Enqueue(position);
            Console.SetCursorPosition(position.Col, position.Row);
            Console.Write("*");
        }

        public Position MyDequeue()
        {
            var temp = this.tailElements.Dequeue();
            Console.SetCursorPosition(temp.Col, temp.Row);
            Console.Write(" ");
            return temp;
        }       
    }
}