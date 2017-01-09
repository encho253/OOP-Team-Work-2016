using System;

namespace Snake_Game.Food
{
    public class Mouse : AbstractClasses.Food
    {
        public Mouse()
        {
            this.Position = NewPosition();
            this.Name = "&";
            this.color = ConsoleColor.Magenta;
        }
    }
}