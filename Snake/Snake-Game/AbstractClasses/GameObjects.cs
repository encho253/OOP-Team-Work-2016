namespace Snake_Game.AbstractClasses
{
    using Snake_Game.Contracts;

    public abstract class GameObject : IDrawing
    {
       public abstract void Draw();
    }
}
