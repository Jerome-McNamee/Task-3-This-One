using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace _20104066_Jerome_McNamee_Task_1
{
    enum AttackDirection
    {
        UP,
        LEFT,
        RIGHT,
        DOWN
    }
    class GameEngine
    {
        
        Map map;
        const string Save_File = "gamesave.txt";

        public GameEngine()
        {
            map = new Map(12, 24, 12, 24, 20, 12, 5);
        }

        
        public void Save()
        {
            FileStream outFile = new FileStream(
                Save_File, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(outFile, map);

            outFile.Close();
        }

        public void Load()
        {
            FileStream inFile = new FileStream(
                Save_File, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            map = (Map)bf.Deserialize(inFile);
 
            inFile.Close();

            
        }

        public string View
        {
            get { return map.ToString(); }
        }

        public string HeroStats
        {
            get { return map.Hero.ToString(); }
        }

        public bool MovePlayer(Movement desiredMove)
        {
            Movement allowedMove = map.Hero.ReturnMove(desiredMove);
            Debug.WriteLine(allowedMove);
            map.Hero.Move(allowedMove);

            MoveEnemies(); // Moves enemies
            map.Update();
            EnemyAttacks();

            Item item = map.GetItemAtPosition(map.Hero.X, map.Hero.Y);
            if(item != null)
            {
                map.Hero.Pickup(item);
            }

            map.Update();

            if(allowedMove == Movement.NO_MOVEMENT)
            {
                return false;
            }

            return true;
        }

        public string PlayerAttack(AttackDirection direction)
        {
            int visionIndex = (int)direction;
            string failMessage = "Hero attack failed";

            if(map.Hero.Vision[visionIndex].Type == TileType.ENEMY)
            {
                Enemy enemy = (Enemy)map.Hero.Vision[visionIndex];
                if (enemy.IsDead())
                {
                    return failMessage;
                }
                map.Hero.Attack(enemy);
                EnemyAttacks();
                map.Update();

                if (enemy.IsDead())
                {
                    return "Hero killed enemy";
                }
                return "Hero attacked Enemy\n" +
                    "Enemy HP: " + enemy.HP + "/" + enemy.MaxHP;
            }
            return failMessage;
        }

        public void EnemyAttacks() 
        {
            foreach (Enemy enemy in map.Enemies)
            {
                for (int i = 0; i < enemy.Vision.Length; i++)
                {
                    if ( enemy.Vision[i] == null)
                    {
                        continue;
                    }

                    if (enemy is Goblin && enemy.Vision[i] is Hero)
                    {
                        enemy.Attack(map.Hero);
                    }

                    if (enemy is Mage && enemy.Vision[i] is Character)
                    {
                        Character target = (Character)enemy.Vision[i];
                        enemy.Attack(target);
                    }
                }
            }
        }

        public void MoveEnemies()
        {
            foreach(Enemy enemy in map.Enemies)
            {
                if (enemy.IsDead())
                {
                    continue;
                }
                Movement allowedMove = enemy.ReturnMove();
                enemy.Move(allowedMove);
            }
        }

    }
}
