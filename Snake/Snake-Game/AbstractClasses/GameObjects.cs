using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Contracts;

namespace Snake_Game.AbstractClasses
{
    public abstract class GameObject : IDrawing
    {
       public abstract void Draw();
    }
}
