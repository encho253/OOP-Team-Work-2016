namespace Snake_Game.SnakeElements
{
    using Snake_Game.Struct;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractClasses;

    public class SnakeTail : SnakeElement
    {
        public const int InitialTailSize = 5;

        public SnakeTail(int tailSize, char symbol = '*')
            : base(symbol)
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