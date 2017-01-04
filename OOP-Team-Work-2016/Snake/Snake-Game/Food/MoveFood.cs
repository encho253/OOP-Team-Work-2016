using System;

namespace Snake_Game.Food
{
    public class MoveFood : AbstractClasses.Food
    {
        private ConsoleColor color;
        public MoveFood(string name, ConsoleColor color)
        {
            this.Position = NewPosition();
            this.Name = name;
            this.Color = color;
        }

        public ConsoleColor Color { get; set; }

        public override void DrawingFood()
        {
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.Position.Row, this.Position.Col);
            Console.WriteLine(this.Name);
        }     
    }
}