using System;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20104066_Jerome_McNamee_Task_1
{
    public partial class frmGame : Form
    {
        GameEngine gameEngine;
        Map map;


        public frmGame()
        {
            Debug.WriteLine("Game Engine constructed");
            gameEngine = new GameEngine();
            
            InitializeComponent();
            
        }

        

        private void frmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'w')
            {
                MoveUp();
            }
            else if (e.KeyChar == 'd')
            {
                MoveRight();
            }
            else if (e.KeyChar == 's')
            {
                MoveDown();
            }
            else if (e.KeyChar == 'a')
            {
                MoveLeft();
            }
            else if (e.KeyChar == 'i')
            {
                AttackUp();
            }
            else if (e.KeyChar == 'j')
            {
                AttackLeft();
            }
            else if (e.KeyChar == 'k')
            {
                AttackDown();
            }
            else if (e.KeyChar == 'l')
            {
                AttackRight();
            }
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Movement.UP);
            lblMap.Text = gameEngine.View;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Movement.LEFT);
            lblMap.Text = gameEngine.View;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Movement.RIGHT);
            lblMap.Text = gameEngine.View;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Movement.DOWN);
            lblMap.Text = gameEngine.View;
        }

        private void MoveUp()
        {
            gameEngine.MovePlayer(Movement.UP);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }
        private void MoveDown()
        {
            gameEngine.MovePlayer(Movement.DOWN);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }
        private void MoveLeft()
        {
            gameEngine.MovePlayer(Movement.LEFT);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }
        private void MoveRight()
        {
            gameEngine.MovePlayer(Movement.RIGHT);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }

        private void AttackUp()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.UP);
            lblMap.Text = gameEngine.View;
        }
        private void AttackDown()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.DOWN);
            lblMap.Text = gameEngine.View;
        }
        private void AttackLeft()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.LEFT);
            lblMap.Text = gameEngine.View;
        }
        private void AttackRight()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.RIGHT);
            lblMap.Text = gameEngine.View;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gameEngine.Save();
        }

        private void lblLoad_Click(object sender, EventArgs e)
        {
            gameEngine.Load();
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Setting Map Text");
            lblMap.Text = gameEngine.View;
            lblBattleInfo.Text = gameEngine.HeroStats;
        }
    }
    
}
