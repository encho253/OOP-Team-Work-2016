namespace Snake_Game.Timer
{
    using AbstractClasses;
    using System;

    public class FoodTimer : Food
    {
        public static int NewFood(Food food, int lastTimeFood, int foodDissapearTime)
        {
            if (Environment.TickCount - lastTimeFood >= foodDissapearTime)
            {

                Console.SetCursorPosition(food.Position.Col, food.Position.Row);
                Console.Write(" ");
                var egg = NewPosition();
                food.Position = egg;
                food.Draw();
                lastTimeFood = Environment.TickCount;
            }

            return lastTimeFood;
        }

    }
}