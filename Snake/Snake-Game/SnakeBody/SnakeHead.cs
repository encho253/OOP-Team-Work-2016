namespace Snake_Game.SnakeBody
{
    using Snake_Game.Struct;

    public class SnakeHead : SnakeElements.SnakeElement
    {
        public const char Symbol = '@';
        private Position head;

        public SnakeHead(int tailSize)
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