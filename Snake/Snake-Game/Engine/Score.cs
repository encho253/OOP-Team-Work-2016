namespace Snake_Game.Engine
{
    public static class Score
    {
        private static long points = 0;

        public static long Points
        {
            get { return points; }
        }

        public static void AddPoints(long newPoints)
        {
            points += newPoints;
        }
    }
}
