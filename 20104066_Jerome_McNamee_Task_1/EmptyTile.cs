using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{   [Serializable]
    class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x, y, TileType.EMPTY) { }
    }
}
