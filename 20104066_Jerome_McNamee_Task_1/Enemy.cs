using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    abstract class Enemy : Character
    {
        static protected Random random = new Random();

        public Enemy(int x, int y, int damage, int hp) : base(x, y, TileType.ENEMY)
        {
            this.damage = damage;
            this.hp = hp;
            this.maxHP = hp; //maxHP will be equal to initial hp.
        }

        public override string ToString()
        {
            return GetType() + "at [" + x + ", " + y + " ] (" + damage + ")";
        }
    }
}
