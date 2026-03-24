using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGamePro.Models
{
    public class GameBoard
    {
        private int width;
        private int height;

        public GameBoard(int w, int h)
        {
            width = w;
            height = h;
        }

        public bool this[int x, int y]
        {
            get
            {
                return x >= 0 && y >= 0 && x < width && y < height;
            }
        }
    }
}
