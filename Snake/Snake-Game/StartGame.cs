namespace Snake_Game
{
    using Contracts;
    using Food;
    using Engine;
    using System;
    using System.Threading;
    using Snake_Game.Timer;
    using Struct;

    public class StartGame
    {
        public static void Main()
        {
            //IDrawing adas;
            GameEngine.SetConsoleWindow();
            Console.CursorVisible = false;
            Position smallPosition = new Position(0, 0);
            Position bigPosition = new Position(0, 0);
            int lastSmallFoodTime = 0;
            int lastBigFoodTime = 0;
            int foodDissapearTime = 1000;
            do
            {
                smallPosition=FoodTimer.NewSmallFood(smallPosition, lastSmallFoodTime, foodDissapearTime);
                lastSmallFoodTime=FoodTimer.lastFoodTime;
                bigPosition =FoodTimer.NewBigFood(bigPosition, lastBigFoodTime, foodDissapearTime);
                lastBigFoodTime= FoodTimer.lastFoodTime;
            }
            while (!Console.KeyAvailable);
        }
    }
}
