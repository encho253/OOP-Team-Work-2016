namespace Snake_Game.Food
{
    using System;

    public class SmallEgg : AbstractClasses.Food
    {
        public SmallEgg()
        {
            this.Position = NewPosition();
            this.Name = "o";
            this.color = ConsoleColor.Yellow;
        }
    }
}