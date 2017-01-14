namespace Snake_Game.AbstractClasses
{
    public abstract class SnakeElement
    {
        public SnakeElement(char symbol)
        {
            this.Symbol = symbol;
        }

        public char Symbol { get; private set; }

    }
}