using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20104066_Jerome_McNamee_Task_1
{
    [Serializable]
    class Map
    {
        /* public Map mapReference
        {
            get { return this;  } 

        } */

        Tile[,] map;
        Hero hero;
        Enemy[] enemies;
        Item[] items;

        int width;
        int height;

        Random random = new Random();

        public Hero Hero{
            get { return hero; }
        }

        public Enemy[] Enemies
        {
            get { return enemies; }
        }

        public int Height
        {get { return height; } 
        }

        public int Width
        {
            get { return width; }
        }


        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItems, int numWeapons)
        {
            width = random.Next(minWidth, maxWidth + 1);
            height = random.Next(minHeight, maxHeight + 1);

            map = new Tile[width, height];
            enemies = new Enemy[numEnemies];
            items = new Item[numItems + numWeapons];
            InitializeMap();
            hero = (Hero) Create(TileType.HERO);

            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy) Create(TileType.ENEMY);
            }

            for (int i = 0; i < numItems; i++)
            {
                items[i] = (Item)Create(TileType.GOLD);
            }
            for( int i = numItems; i < items.Length; i++)
            {
                items[i] = (Item)Create(TileType.WEAPON);
            }

            UpdateVision();
        }

        private void InitializeMap()
        {
            for(int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        map[x, y] = new Obstacle(x, y);
                    }
                    else
                    {
                        map[x, y] = new EmptyTile(x, y);
                    }
                }
            }
        }

        private Tile Create(TileType type )
        {
            int x = random.Next(0, width);
            int y = random.Next(0, height);
            

            while(map[x, y].Type != TileType.EMPTY)
            {
                x = random.Next(0, width);
                y = random.Next(0, height);
            }

            if(type == TileType.HERO)
            {
                map[x, y] = new Hero(x, y, 10);
                return map[x, y];
            }
            else if( type == TileType.ENEMY)
            {
                int i = random.Next(0, 3);
                if (i == 1)
                {
                    map[x, y] = new Goblin(x, y);
                    return map[x, y];
                }
                else if (i == 2)
                {
                    map[x, y] = new Mage(x, y);
                    return map[x, y];
                }
                else
                {
                    Leader leader = new Leader(x, y);
                    leader.Target = hero;
                    map[x, y] = leader;
                    return map[x, y];
                }

            }
            else if(type == TileType.GOLD)
            {
                map[x, y] = new Gold(x,y);
                return map[x, y];
            }

            else if (type == TileType.WEAPON)
            {
                int weaponType = random.Next(0, 2);
                int weaponVariant = random.Next(0, 2);

                if ( weaponType == 0)
                {
                    RangedWeaponType rangedType = (RangedWeaponType)weaponVariant;
                    map[x, y] = new RangedWeapon(rangedType, x, y);
                }
                else
                {
                    MeleeWeaponType meleeType = (MeleeWeaponType)weaponVariant;
                    map[x, y] = new MeleeWeapon(meleeType, x, y);
                }

                return map[x, y];
            }

            return new EmptyTile(x, y);
        }
        public void UpdateVision() 
        {
            

            for(int i = 0; i< enemies.Length; i++)
            {
                UpdateCharacterVision(enemies[i]);
            }

            UpdateCharacterVision(hero);
        }

        private void UpdateCharacterVision(Character character)
        {
            Tile tileUP = null;
            Tile tileDown = null;
            Tile tileLeft = null;
            Tile tileRight = null;

            if (character.Y - 1 >= 0) // up
            {
                tileUP = map[character.X, character.Y - 1];
            }
            if (character.Y + 1 < height) // down
            {
               tileDown = map[character.X, character.Y + 1];
            }
            
            if (character.X - 1 >= 0) // left
            {
                tileLeft = map[character.X - 1, character.Y];
            }
            if (character.X + 1 < width) // right
            {
                tileRight = map[character.X + 1, character.Y];
            }
            character.SetVision(tileUP, tileDown, tileLeft, tileRight);
        }

        public void Update()
        {
            InitializeMap();

            map[hero.X, hero.Y] = hero;
            for(int i = 0; i < enemies.Length; i++)
            {
                Enemy currentEnemy = enemies[i];
                map[currentEnemy.X, currentEnemy.Y] = enemies[i];
            }

            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                if (item != null)
                {
                    map[item.X, item.Y] = items[i];
                }
            }
            UpdateVision();
        }

        public override string ToString()
        {
            string mapString = "";
            
            for(int y = 0; y < height; y++){
                for (int x = 0; x < width; x++)
                {
                    TileType currentType = map[x, y].Type;
                    if (Hero.X == x && hero.Y == y)
                    {
                        mapString += 'H';
                        continue;
                    }
                    if (currentType == TileType.ENEMY)
                    {
                        Enemy enemy = (Enemy)map[x, y];
                        if (enemy.IsDead())
                        {
                            mapString += '\u2020';
                        }
                        else
                        {
                            if (enemy is Goblin)
                            {
                                mapString += 'G';
                            }
                            else if (enemy is Mage)
                            {
                                mapString += 'M';
                            }
                            else if( enemy is Leader)
                            {
                                mapString += 'L';
                            }
                        } 
                    }
                    else if (currentType == TileType.EMPTY)
                    {
                        mapString += '.';
                    }
                    else if (map[x, y].Type == TileType.OBSTACLE)
                    {
                        mapString += 'O';
                    }
                    else if (map[x, y].Type == TileType.GOLD)
                    {
                        Debug.WriteLine("Item");
                       
                        Gold gold = (Gold)map[x, y];
                        mapString += gold.GoldAmount; // Testing
                        
                    }
                    else if (map[x, y].Type == TileType.WEAPON)
                    {
                        Weapon weapon = (Weapon)map[x, y];
                        

                        if (weapon is MeleeWeapon)
                        {
                            if (weapon.Name == "LongSword")
                            {
                                mapString += '/';
                            }
                            else
                            {
                                mapString += '|';
                            }
                        }

                        else if (weapon is RangedWeapon)
                        {
                            if (weapon.Name == "Rifle")
                            {
                                mapString += 'R';
                            }
                            else
                            {
                                mapString += '}';
                            }
                        }
                    }

                }
                mapString += "\n";
            }
            return mapString;
        }
        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    continue;
                }
                else if(items[i].X == x && items[i].Y == y)
                {
                    Item tempItem = items[i];
                    items[i] = null;
                    return tempItem;
                }
            }
            return null;
        }
        
    }
}
