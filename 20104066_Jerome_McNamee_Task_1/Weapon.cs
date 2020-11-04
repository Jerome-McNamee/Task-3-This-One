using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    abstract class Weapon: Item
    {
        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string name;

        public int Damage 
        {
            get
            {
                return damage;
            }
        }

        public int Range
        {
            get
            {
                return range;
            }
        }
        public int Durability
        {
            get
            {
                return durability;
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }



        public Weapon (int x = 0, int y = 0): base(x, y)
        {
            this.type = TileType.WEAPON;
        }
    }
}
