using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    public enum TileType // outside as it allows easy access
    {
        HERO,
        ENEMY,
        GOLD,
        WEAPON,
        OBSTACLE,
        EMPTY,
        ITEM
    }
    abstract class Tile
    {
        protected int x;
        protected int y;

        protected TileType type;

        public int X     // public accessor
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public TileType Type
        {
            get { return type; }
        }

        public Tile(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

    }
}
