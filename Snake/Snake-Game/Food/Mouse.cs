namespace Snake_Game.Food
{
    using System;
    using AbstractClasses;

    public class Mouse : Food
    {
        public Mouse()
        {
            this.Position = NewPosition();
            this.Name = "&";
            this.color = ConsoleColor.Magenta;
        }
    }
}