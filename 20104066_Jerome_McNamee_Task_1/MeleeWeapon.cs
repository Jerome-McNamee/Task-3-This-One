using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{
    class MeleeWeapon: Weapon
    {
        public MeleeWeapon(MeleeWeaponType meleeWeaponType, int x = 0, int y = 0): base(x, y)
        {
            if(meleeWeaponType == MeleeWeaponType.DAGGER)
            {
                durability = 10;
                damage = 3;
                cost = 3;
                name = "Dagger";
            }

            else if (meleeWeaponType == MeleeWeaponType.LONGSWORD)
            {
                durability = 6;
                damage = 4;
                cost = 5;
                name = "LongSword";
            }
            range = 1;
        }

        public override string ToString()
        {
            return name;
        }

        
    }
    public enum MeleeWeaponType
    {
        DAGGER,
        LONGSWORD
    }
}
