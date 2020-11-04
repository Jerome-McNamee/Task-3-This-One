using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    abstract class Item : Tile
    {
        public Item(int x, int y) : base(x, y, TileType.ITEM) { }

        public abstract override string ToString();

    }

}

