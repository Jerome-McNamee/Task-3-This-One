using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base (x, y, 1, 10) { }

        public override Movement ReturnMove(Movement move = Movement.NO_MOVEMENT)
        {
            int dir = random.Next(0, 4);

            int maxTries = 10;
            int tries = 0;
            for (int i = 0; i < vision.Length; i++)
            {
                Debug.WriteLine(vision[i] == null);
            }
            while(vision[dir].Type != TileType.EMPTY && tries < maxTries)
            {
                dir = random.Next(0, 4);
                tries++;
                if( tries == maxTries)
                {
                    return Movement.NO_MOVEMENT;
                }
            }

            return (Movement)dir;
        }
    }
}
