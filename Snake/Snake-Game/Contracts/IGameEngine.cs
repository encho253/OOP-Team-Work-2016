namespace Snake_Game.Contracts
{
    public interface IGameEngine
    {
        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

        void ExecuteSnakeMove();
    }
}
