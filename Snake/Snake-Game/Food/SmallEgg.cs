using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Contracts;
using Snake_Game.Struct;
using Snake_Game.AbstractClasses;

namespace Snake_Game.Food
{
    public class SmallEgg : AbstractClasses.Food
    {

        
        public SmallEgg()
        {
            this.Position = NewPosition();
            this.Name = "o";
            this.color = ConsoleColor.Yellow;
        }

               
    }
}
