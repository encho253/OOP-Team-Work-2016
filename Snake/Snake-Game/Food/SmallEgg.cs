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
            this.position = NewPosition();
            this.name = "o";
            this.color = ConsoleColor.Yellow;
        }

        protected Position NewPosition()
        {
            Position foodposition;
            Random randomNumbersGenerator = new Random();
            do
            {
                foodposition = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                   randomNumbersGenerator.Next(0, Console.WindowWidth));
            }
            while (false); //(snakeElements.Contains(food) || obstacles.Contains(food));
            return foodposition;
        }
        public override void DrawingFood()
        {
            Console.SetCursorPosition(position.col, position.row);
            Console.ForegroundColor = color;
            Console.Write(name);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }       
    }
}
