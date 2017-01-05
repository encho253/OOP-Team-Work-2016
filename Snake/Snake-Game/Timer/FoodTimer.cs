using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Timer
{
    using System.Threading;
    using Food;
    using Struct;
    class FoodTimer
    {
        public static int lastFoodTime { get; set; }
        public static Position NewSmallFood(Position position, int lastFoodTime, int foodDissapearTime)
        {

            if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
            {

                Console.SetCursorPosition(position.Row, position.Col);
                Console.Write(" ");
                Thread.Sleep(50);
                var egg = new SmallEgg();
                position.Col = egg.Position.Col;
                position.Row = egg.Position.Row;
                egg.DrawingFood();
                FoodTimer.lastFoodTime = Environment.TickCount;
            }
            return position;
        }
        public static Position NewBigFood(Position position, int lastFoodTime, int foodDissapearTime)
        {
            if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
            {

                Console.SetCursorPosition(position.Row, position.Col);
                Console.Write(" ");
                Thread.Sleep(50);
                var bigegg = new BigEgg();
                position.Col = bigegg.Position.Col;
                position.Row = bigegg.Position.Row;
                bigegg.DrawingFood();
                FoodTimer.lastFoodTime = Environment.TickCount;
            }
            return position;
        }
    }
}
