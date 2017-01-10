namespace Snake_Game.Engine
{
    using System.IO;

    public class FileScore
    {
        public static void SaveMaxScore(long scoreMax)
        {
            using (StreamWriter file = new StreamWriter(@"../../../MaxScore.txt"))
            {
                file.WriteLine(scoreMax.ToString());
            }
        }

        public static int LoadMaxScore()
        {
            using (StreamReader fileLoad = new StreamReader(@"../../../MaxScore.txt"))
            {
                return int.Parse(fileLoad.ReadLine());
            }
        }
    }
}