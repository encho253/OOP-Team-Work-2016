using System;

namespace Snake_Game.Food
{
    public class Rabbit : AbstractClasses.Food 
    {
        public Rabbit()
        {
            this.Position = NewPosition();
            this.Name = "$";
            this.color = ConsoleColor.Green;
        }
    }
}