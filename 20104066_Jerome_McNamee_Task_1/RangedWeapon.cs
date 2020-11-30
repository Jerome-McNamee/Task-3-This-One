using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    class RangedWeapon:Weapon
    {
        public RangedWeapon(RangedWeaponType rangedWeaponType, int x = 0, int y = 0) : base(x, y)
        {
            //ANOTHER CONSTRUCTOR IS NEEDED

            if (rangedWeaponType == RangedWeaponType.RIFLE)
            {
                durability = 3;
                damage = 5;
                cost = 7;
                range = 3;
                name = "Rifle";
            }

            else if (rangedWeaponType == RangedWeaponType.LONGBOW)
            {
                durability = 4;
                range = 2;
                damage = 4;
                cost = 6;
                name = "LongBow";
            }
            range = 1;
        }

        public override string ToString()
        {
            return name;
        }

        
    }
    public enum RangedWeaponType
    {
        RIFLE,
        LONGBOW
    }
}
