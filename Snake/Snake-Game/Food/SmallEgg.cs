namespace Snake_Game.Food
{
    using System;
    using Timer;

    public class SmallEgg : FoodTimer
    {
        public SmallEgg()
        {
            this.Position = NewPosition();
            this.Name = "o";
            this.color = ConsoleColor.Yellow;
        }
    }
}
