namespace Snake_Game.Timer
{
    using AbstractClasses;
    using System;

    public class FoodTimer : Food
    {
        public int NewFood( int lastTimeFood, int foodDissapearTime)
        {
            this.Draw();
            if (Environment.TickCount - lastTimeFood >= foodDissapearTime)
            {
                lastTimeFood= DrawNewFood(lastTimeFood);
            }
            return lastTimeFood;
        }
        public int DrawNewFood( int lastTimeFood)
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.Write(" ");
            var egg = NewPosition();
            this.Position = egg;
            this.Draw();
            lastTimeFood = Environment.TickCount;
            return lastTimeFood;
        }
    }
}
