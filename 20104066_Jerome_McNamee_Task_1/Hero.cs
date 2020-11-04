using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20104066_Jerome_McNamee_Task_1
{    [Serializable]
    class Hero : Character
    {
        public Hero(int x, int y, int hp) : base(x, y, TileType.HERO)
        {
            this.damage = 2;
        }

        public override Movement ReturnMove(Movement move = 0)
        {
            int dir = (int)move;
            Tile tile = vision[dir];
            if(tile != null) 
            { 
                if(tile.Type == TileType.EMPTY || tile.Type == TileType.GOLD)
                {
                    Debug.WriteLine(move);
                    return move;
                }
            }
            return Movement.NO_MOVEMENT;
        }

        public override string ToString()
        {
            return "Player Stats: \n" + 
                "HP: " + hp + "/" + maxHP + "\n" + 
                "Damage" + damage + "\n" +
                "Gold:" + goldPurse + "\n" + 
                "[ " + x + ", " + y + "] ";  
        }
    }
}
