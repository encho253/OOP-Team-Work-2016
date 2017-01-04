using Snake_Game.Struct;

namespace Snake_Game
{
    using Food;
    using Engine;
    using System;
    using System.Threading;
    public class StartGame
    {
        public static void Main()
        {

            //IDrawing adas;
            GameEngine.SetConsoleWindow();
            Thread.Sleep(50);
            var egg = new SmallEgg();
            egg.DrawingFood();
            Thread.Sleep(50);
            var bigegg = new BigEgg();
            bigegg.DrawingFood();

            Mouse mouse = new Mouse();
            Rabbit rabbit = new Rabbit();

            while (true)
            {
                if (mouse.MoveFood.Position.Row <= 0 || mouse.MoveFood.Position.Row >= Console.WindowWidth - 1 ||
                      mouse.MoveFood.Position.Col <= 0 || mouse.MoveFood.Position.Col - 1 > Console.WindowHeight)
                {
                    Position oldPosition = mouse.MoveFood.Position;
                    Console.SetCursorPosition(oldPosition.Row, oldPosition.Col);
                    Console.Write(" ");
                    mouse.MoveFood.Position = mouse.MoveFood.NewPosition();
                }

                if (rabbit.MoveFood.Position.Row <= 0 || rabbit.MoveFood.Position.Row >= Console.WindowWidth - 1 ||
                    rabbit.MoveFood.Position.Col <= 0 || rabbit.MoveFood.Position.Col - 1 > Console.WindowHeight)
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
                Console.CursorVisible = false;

                double sleepTime = 150;
                Thread.Sleep((int)sleepTime);
            }
        }
    }
}