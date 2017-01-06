using Snake_Game.Struct;

namespace Snake_Game
{
    using Food;
    using Engine;
    using System;
    using System.Threading;
    using Timer;
    using Snake_Game.AbstractClasses;
    public class StartGame
    {
        public static void Main()
        {

            //IDrawing adas;
            GameEngine.SetConsoleWindow();
            Console.CursorVisible = false;

            var smallEgg = new SmallEgg();
            var bigEgg = new BigEgg();
            int lastTimeSmallEgg = 0;
            int lastTimeBigEgg = 0;
            int foodDissapearTime = 8000;
            
            Mouse mouse = new Mouse();
            Rabbit rabbit = new Rabbit();

            do
            {
                lastTimeSmallEgg = FoodTimer.NewFood(smallEgg, lastTimeSmallEgg, foodDissapearTime);
                lastTimeBigEgg = FoodTimer.NewFood(bigEgg, lastTimeBigEgg, foodDissapearTime);
                
                if (mouse.MoveFood.Position.Col == 0 || mouse.MoveFood.Position.Col >= Console.WindowWidth -1 ||
                      mouse.MoveFood.Position.Row == 0 || mouse.MoveFood.Position.Row >= Console.WindowHeight )
                {
                    Position oldPosition = mouse.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Col, oldPosition.Row);
                    Console.Write(" ");
                    mouse.MoveFood.Position = AbstractClasses.Food.NewPosition();
                }

                if (rabbit.MoveFood.Position.Col == 0 || rabbit.MoveFood.Position.Col >= Console.WindowWidth -1 ||
                    rabbit.MoveFood.Position.Row == 0 || rabbit.MoveFood.Position.Row >= Console.WindowHeight )
                {
                    Position oldPosition = rabbit.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Col, oldPosition.Row);
                    Console.Write(" ");
                    rabbit.MoveFood.Position = AbstractClasses.Food.NewPosition();
                }

                Position lastPositionMouse = mouse.MoveFood.Position;
                Position lastastPositionRabbit = rabbit.MoveFood.Position;
                mouse.Move();
                rabbit.Move();
                mouse.MoveFood.DrawingFood();
                rabbit.MoveFood.DrawingFood();

                Console.SetCursorPosition(lastPositionMouse.Col, lastPositionMouse.Row);
                Console.Write(" ");

                Console.SetCursorPosition(lastastPositionRabbit.Col, lastastPositionRabbit.Row);
                Console.Write(" ");
                //Console.CursorVisible = false;

                double sleepTime = 150;
                Thread.Sleep((int)sleepTime);
            }
            while (!Console.KeyAvailable);
        }
    }
}