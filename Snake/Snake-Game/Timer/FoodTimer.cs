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

                Console.SetCursorPosition(position.col, position.row);
                Console.Write(" ");
                Thread.Sleep(50);
                var egg = new SmallEgg();
                position.col = egg.Position.col;
                position.row = egg.Position.row;
                egg.DrawingFood();
                FoodTimer.lastFoodTime = Environment.TickCount;
            }
            return position;
        }
        public static Position NewBigFood(Position position, int lastFoodTime, int foodDissapearTime)
        {          
            if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
            {

                Console.SetCursorPosition(position.col, position.row);
                Console.Write(" ");
                Thread.Sleep(50);
                var bigegg = new BigEgg();
                position.col = bigegg.Position.col;
                position.row = bigegg.Position.row;
                bigegg.DrawingFood();
                FoodTimer.lastFoodTime = Environment.TickCount;
            }
            return position;
        }
    }
}
