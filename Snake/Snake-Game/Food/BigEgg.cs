using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Food;
namespace Snake_Game.Food
{
    class BigEgg: AbstractClasses.Food
    {
        public BigEgg()
        {
            this.Position = NewPosition();
            this.Name = "O";
            this.color = ConsoleColor.Red;
        }

    }
    
}
