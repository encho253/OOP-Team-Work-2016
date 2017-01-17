namespace Snake_Game.SnakeBody
{
    using Snake_Game.Struct;
    using AbstractClasses;

    public class SnakeHead : SnakeElement
    {
        private Position head;

        public SnakeHead(int tailSize, char symbol = '@')
            : base(symbol)
        {
            this.head = new Position(tailSize, 0);
        }

        public Position Head
        {
            get
            {
                return this.head;
            }
            set
            {
                this.head = value;
            }
        }
    }
}