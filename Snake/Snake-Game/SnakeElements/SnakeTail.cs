namespace Snake_Game.SnakeElements
{
    using Snake_Game.Struct;
    using System.Collections.Generic;
    using System.Linq;

    public class SnakeTail
    {
        public const int InitialTailSize = 5;
        public const char ElementSymbol = '*';

        public SnakeTail(int tailSize)
        {
            this.TailSize = tailSize;        
        }

        public Queue<Position> TailElements { get; set; }       

        public int TailSize { get; set; }

        public SnakeTail Tail { get; set; }

        public Position Neck
        {
            get
            {
                return this.TailElements.Last();
            }
        }
    }
}