using System;
using Snake_Game.AbstractClasses;
using Snake_Game.Struct;

namespace Snake_Game.Objects
{
    public class Stone : GameObject
    {
        public Stone(Position position) : base()
        {
            this.Position = position;
            this.Name = "~";
        }

        public override void Draw()
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.WriteLine(this.Name);
        }

    }
}
