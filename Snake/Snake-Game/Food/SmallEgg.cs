using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Contracts;
using Snake_Game.Struct;
using Snake_Game.AbstractClasses;

namespace Snake_Game.Food
{
    public class SmallEgg : AbstractClasses.Food
    {
        protected ConsoleColor color = ConsoleColor.White;

        public ConsoleColor Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }
        public SmallEgg()
        {
            this.Position = NewPosition();
            this.Name = "o";
            this.color = ConsoleColor.Yellow;
        }

       
        public override void DrawingFood()
        {
            Console.SetCursorPosition(Position.Col, Position.Row);
            Console.ForegroundColor = color;
            Console.Write(Name);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }       
    }
}
