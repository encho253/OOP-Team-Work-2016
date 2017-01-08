using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.AbstractClasses;
using Snake_Game.Struct;

namespace Snake_Game.SnakeBody
{
    public class SnakeTailElement : SnakeElement
    {
        private char symbol;
        private Position elementPosition;

        public SnakeTailElement(int row, int col) : base(row, col)
        {
            this.symbol = '*';
        }

        public override char Symbol
        {
            get { return this.symbol; }
            set { this.symbol = value; }
        }

        public override Position ElementPosition
        {
            get { return this.elementPosition; }
            set { this.elementPosition = value; }
        }
    }
}
