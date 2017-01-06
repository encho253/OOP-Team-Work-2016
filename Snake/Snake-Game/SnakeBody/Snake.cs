namespace Snake_Game.SnakeBody
{
    using Struct;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
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

        public void Enqueue(Position position)
        {
            this.tailElements.Enqueue(position);
        }

        public Position Dequeue()
        {
            return this.tailElements.Dequeue();
        }
    }
}
