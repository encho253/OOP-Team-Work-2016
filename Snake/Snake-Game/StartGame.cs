using Snake_Game.Struct;

namespace Snake_Game
{
    using Food;
    using Engine;
    using System;
    using System.Threading;
    using Timer;
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
            int foodDissapearTime = 8000;
            
            Mouse mouse = new Mouse();
            Rabbit rabbit = new Rabbit();

            do
            {
                smallPosition = FoodTimer.NewSmallFood(smallPosition, lastSmallFoodTime, foodDissapearTime);
                lastSmallFoodTime = FoodTimer.lastFoodTime;
                bigPosition = FoodTimer.NewBigFood(bigPosition, lastBigFoodTime, foodDissapearTime);
                lastBigFoodTime = FoodTimer.lastFoodTime;

                if (mouse.MoveFood.Position.Row == 0 || mouse.MoveFood.Position.Row == Console.WindowWidth - 2 ||
                      mouse.MoveFood.Position.Col == 0 || mouse.MoveFood.Position.Col == Console.WindowHeight - 2)
                {
                    Position oldPosition = mouse.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                    Console.Write(" ");
                    mouse.MoveFood.Position = mouse.MoveFood.NewPosition();
                }

                if (rabbit.MoveFood.Position.Row == 0 || rabbit.MoveFood.Position.Row == Console.WindowWidth - 2 ||
                    rabbit.MoveFood.Position.Col == 0 || rabbit.MoveFood.Position.Col == Console.WindowHeight - 2)
                {
                    Position oldPosition = rabbit.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                    Console.Write(" ");
                    rabbit.MoveFood.Position = rabbit.MoveFood.NewPosition();
                }

                Position lastPositionMouse = mouse.MoveFood.Position;
                Position lastastPositionRabbit = rabbit.MoveFood.Position;
                mouse.Move();
                rabbit.Move();
                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

                Console.SetCursorPosition(lastPositionMouse.Row, lastPositionMouse.Col);
                Console.Write(" ");

                Console.SetCursorPosition(lastastPositionRabbit.Row, lastastPositionRabbit.Col);
                Console.Write(" ");
                //Console.CursorVisible = false;

                double sleepTime = 150;
                Thread.Sleep((int)sleepTime);
            }
            while (!Console.KeyAvailable);
        }
    }
}