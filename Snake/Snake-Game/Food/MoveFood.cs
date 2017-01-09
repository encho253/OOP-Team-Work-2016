using System;
using Snake_Game.Contracts;
using Snake_Game.Enum;
using Snake_Game.Struct;

namespace Snake_Game.Food
{
    //Decorator pattern
    public class MoveFood : IMovable
    {
        public MoveFood(AbstractClasses.Food food, Direction moveDirection)
        {
            this.Food = food;
            this.MoveDirection = moveDirection;
        }

        public AbstractClasses.Food Food { get; private set; }
        public Direction MoveDirection { get; set; }

        public void Move()
        {
            Position position = new Position();
            switch ((int)MoveDirection)
            {
                case 0: //Right
                    position.Col = 1;
                    position.Row = 0;
                    break;
                case 1: //Left
                    position.Col = -1;
                    position.Row = 0;
                    break;
                case 2: //Up
                    position.Col = 0;
                    position.Row = -1;
                    break;
                case 3: //Down
                    position.Col = 0;
                    position.Row = 1;
                    break;
                case 4: //UpLeft
                    position.Col = -1;
                    position.Row = -1;
                    break;
                case 5: //UpRight
                    position.Col = 1;
                    position.Row = -1;
                    break;
                case 6: //DownRight
                    position.Col = 1;
                    position.Row = 1;
                    break;
                case 7: //DownLeft
                    position.Col = -1;
                    position.Row = 1;
                    break;
            }

            if (this.Food.Position.Col == 0 || this.Food.Position.Col == Console.WindowWidth - 1 ||
                this.Food.Position.Row == 0 || this.Food.Position.Row == Console.WindowHeight - 1)
            {
                Position oldPosition = this.Food.Position;
                Console.SetCursorPosition(oldPosition.Col, oldPosition.Row);
                Console.Write(" ");
                this.Food.Position = AbstractClasses.Food.NewPosition();
            }

            Position lastPositionMouse = this.Food.Position;

            Position newPosition = new Position(this.Food.Position.Col + position.Col,
                this.Food.Position.Row + position.Row);
            this.Food.Position = newPosition;

            Console.SetCursorPosition(lastPositionMouse.Col, lastPositionMouse.Row);
            Console.Write(" ");
        }
    }
}