using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Contracts;
using Snake_Game.Struct;

namespace Snake_Game.AbstractClasses
{
    public abstract class Food : IDrawing
    {
        public Position position;
        public string name;

        public Position Position
        {
            get { return this.position; }
            private set { this.position = value; }
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        abstract public void DrawingFood();
        
    }
}
