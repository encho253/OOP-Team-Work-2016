namespace Snake_Game.Contracts
{
    using Enum;

    public interface IGame
    {
        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

        void ExecuteSnakeMove();  
    }
}
