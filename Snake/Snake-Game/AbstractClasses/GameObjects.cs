namespace Snake_Game.AbstractClasses
{
    using System.Linq;
    using Snake_Game.Objects;
    using Snake_Game.Struct;
    using Snake_Game.Contracts;

    public abstract class GameObject : IDrawing
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public abstract void Draw();


        public bool IsRelocatePosition(StoneWall stoneWallFirst, StoneWall stoneWallSecond, params GameObject[] otherObject)
        {
            if (stoneWallFirst.StonesList.Any(r => this.Position.Equals(r.Position)) ||
                stoneWallSecond.StonesList.Any(r => this.Position.Equals(r.Position)) ||
                otherObject.Any(obj => this.Position.Equals(obj.Position)))
            {
                return true;
            }

            return false;
        }
        public bool IsRelocatePositionShort(params GameObject[] otherObject)
        {
            if (otherObject.Any(obj => this.Position.Equals(obj.Position)))
            {
                return true;
            }

            return false;
        }
    }
}