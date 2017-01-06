using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
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

               
=======

namespace Snake_Game.Food
{
    class SmallEgg
    {
>>>>>>> 76c3f4fedc20263fcbff96acda293ce8a8b768f1
    }
}
