using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.AbstractClasses;

namespace Snake_Game.SnakeBody
{
    public class SnakeHead : SnakeElement
    {
        public SnakeHead(int row, int col) : base(row, col)
        {
            this.symbol = '#';
        }
    }
}
