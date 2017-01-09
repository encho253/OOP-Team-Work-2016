using Snake_Game.Struct;

namespace Snake_Game.AbstractClasses
{
    using Snake_Game.Contracts;

    public abstract class GameObject : IDrawing
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public abstract void Draw();
    }
}
