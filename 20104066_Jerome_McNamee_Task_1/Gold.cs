using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    class Gold : Item
    {
        private int goldAmount; // member variables are also called fields

        public int GoldAmount // accessors / properties / getters and setters
        {
            get
            {
                return goldAmount;
            }
        }

        static private Random rnd = new Random();

        public Gold(int x, int y) : base(x, y)
        {
            goldAmount = rnd.Next(1, 6);
            type = TileType.GOLD;
        }
        public override string ToString()
        {
            return GetType() + "";
        }
    }
}
