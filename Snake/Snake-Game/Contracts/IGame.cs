namespace Snake_Game.Contracts
{
    public interface IGame
    {
        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

        void ExecuteSnakeMove();  
    }
}