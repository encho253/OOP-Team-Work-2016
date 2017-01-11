namespace Snake_Game.Food
{
    using System;
    using AbstractClasses;
    using Timer;

    public class BigEgg : FoodTimer
    {
        public BigEgg()
        {
            this.Position = NewPosition();
            this.Name = "O";
            this.color = ConsoleColor.Red;
        }
    }
}
