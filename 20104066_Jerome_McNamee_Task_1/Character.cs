using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20104066_Jerome_McNamee_Task_1
{   [Serializable]
    abstract class Character : Tile
    {
        protected int hp;
        protected int maxHP;
        protected int damage;
        protected Tile[] vision;
        protected Movement movement;
        protected int goldPurse = 0;

        public int GoldPurse
        {
            get { return goldPurse; }
            set { goldPurse = value; }
        }

        public int HP // this allows the hp to actually be set as it is protected
        {
            get { return hp; }
            set { hp = value; }
        }

        public int MaxHP
        {
            get { return maxHP; }
        }


        public Tile[] Vision
        {
            get { return vision; }
            set { vision = value; }
        }
        public Character(int x, int y, TileType type) : base(x, y, type) 
        {
            vision = new Tile[4];
        }

        public virtual void Attack(Character target)
        {
            target.hp -= this.damage;
        }

        public bool IsDead() //checks to see if the hero is alive or not depending on their hp value
        {
            return hp <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return DistanceTo(target) <= 1;
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(x - target.X) + Math.Abs(y - target.Y); //jesus christ, this hurts..... Math.abs throws away the minus so it is a positive value.
        }

        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.UP: y -= 1; break;
                case Movement.DOWN: y += 1; break;
                case Movement.LEFT: x -= 1; break;
                case Movement.RIGHT: x += 1;break;
            }
            
        }


        public void SetVision( Tile up, Tile down, Tile left, Tile right)
        {
            vision[0] = up;
            vision[1] = down;
            vision[2] = left;
            vision[3] = right;
        }

        public void Pickup(Item i)
        {
            if (i is Gold)
            {
                Gold gold = (Gold)i;
                goldPurse += gold.GoldAmount;
            }
        }

        public abstract Movement ReturnMove(Movement move = 0); // no implementation therefore no {}

        public abstract override string ToString(); // this forces the class that inherits from this to provide implementation

    }

    public enum Movement
    {
        
        UP, //0
        DOWN, //1
        LEFT, //2
        RIGHT, //3
        NO_MOVEMENT

    }
}
