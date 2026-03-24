using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace SnakeGamePro.Utilities
{
    public class ScoreManager
    {
        private string file = "scores.txt";

        public void SaveScore(int score)
        {
            try
            {
                File.AppendAllText(file, score + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetHighScore()
        {
            try
            {
                if (!File.Exists(file))
                    return 0;

                var scores = File.ReadAllLines(file)
                                 .Select(int.Parse);

                return scores.Max();
            }
            catch
            {
                return 0;
            }
        }
    }
}
