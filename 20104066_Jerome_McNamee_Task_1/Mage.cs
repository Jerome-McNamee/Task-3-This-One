using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5)
        {

        }
        public override Movement ReturnMove(Movement move = 0)
        {
            return Movement.NO_MOVEMENT;
        }
        public override bool CheckRange(Character target)
        {
            for (int y = this.y -1 ; y <= this.y+1; y++)
            {
                for( int x = this.x - 1; x <= this.x +1; x++)
                {
                    if( x == this.x && y == this.y)
                    {
                        continue;
                    }
                    if (target.X == x && target.Y == y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
