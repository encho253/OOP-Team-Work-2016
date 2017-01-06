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
    using AbstractClasses;
    class FoodTimer:Food
    {
        public static int lastTimeFood { get; set; }
        public static int lastTimeBigFood { get; set; }
        public static int NewFood(Food food, int lastTimeFood, int foodDissapearTime)
        {            
            if (Environment.TickCount - lastTimeFood >= foodDissapearTime)
            {
                
                Console.SetCursorPosition(food.Position.Col, food.Position.Row);
                Console.Write(" ");
                Thread.Sleep(50);                
                var egg = NewPosition();
                food.Position= egg;                
                food.DrawingFood();               
                if (food.Name == "o")
                {
                    FoodTimer.lastTimeFood = Environment.TickCount;
                    lastTimeFood = FoodTimer.lastTimeFood;
                }
                else if (food.Name == "O")
                {
                    FoodTimer.lastTimeBigFood = Environment.TickCount;
                    lastTimeFood = FoodTimer.lastTimeBigFood;                  
                }
            }
            return lastTimeFood;
        }
        
    }
}
