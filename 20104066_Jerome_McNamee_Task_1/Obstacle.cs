using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    class Obstacle : Tile
    {
        public Obstacle(int x, int y) : base(x, y, TileType.OBSTACLE) { }
    }
}
