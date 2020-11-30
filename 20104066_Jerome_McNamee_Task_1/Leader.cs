using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    class Leader:Enemy
    {
        private Tile target;

        public Tile Target
        {
            get { return target; }

            set { target = value; }
        }

        public Leader(int x, int y) : base(x, y, 2, 20) { }


        public override Movement ReturnMove(Movement move = 0) 
        {
            int dir = 4;

            if ( target.X > x)
            {
                dir = 3;
            }
            else if (target.X < x)
            {
                dir = 2;
            }
            else if(target.Y > y)
            {
                dir = 1;
            }
            else if (target.Y < y)
            {
                dir = 0;
            }

            if (dir != 4 && vision[dir].Type == TileType.EMPTY)
            {
                return (Movement)dir;
            }


            int tries = 0;
            int maxTries = 10;

            while(vision[dir].Type != TileType.EMPTY && tries < maxTries)
            {
                dir = random.Next(0, 4);
                tries++;
                if( tries == maxTries)
                {
                    return Movement.NO_MOVEMENT;
                }
            }
            return Movement.NO_MOVEMENT;

        }

        
    }
}
