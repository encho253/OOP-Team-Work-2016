namespace Snake_Game.Food
{
    using System;
    using AbstractClasses;

    public class BigEgg : Food
    {
        public BigEgg()
        {
            this.Position = NewPosition();
            this.Name = "O";
            this.color = ConsoleColor.Red;
        }
    }
}
