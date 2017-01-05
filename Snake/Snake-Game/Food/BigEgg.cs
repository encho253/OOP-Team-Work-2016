using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Food;
namespace Snake_Game.Food
{
    class BigEgg: SmallEgg
    {
        public BigEgg()
        {
            this.position = NewPosition();
            this.name = "O";
            this.color = ConsoleColor.Red;
        }

    }
    
}
