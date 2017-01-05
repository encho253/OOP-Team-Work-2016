namespace Snake_Game
{
    using Contracts;
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
        }
    }
}
