using Game.Entity_System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{

    /// <summary>
    /// Player class
    /// </summary>
    public sealed class Player : Entity
    {
        //Moment speed consents
        readonly int MOVEMENT_SPEED = 10;
        readonly int RUN_SPEED = 20;
        //Movement boolean
        bool right;
        bool left;
        bool up;
        bool down;
        bool run;
        //Screen panel
        private Panel screen;
        //Position of player
        private PointF position;


        public void player_KeyPushed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    right = true;
                    break;
                case Keys.A:
                    left = true;
                    break;
                case Keys.W:
                    up = true;
                    break;
                case Keys.S:
                    down = true;
                    break;
                case Keys.ShiftKey:
                    run = true;
                    break;
            }
        }

        public void player_KeyReleased(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.D:
                    right = false;
                    break;
                case Keys.A:
                    left = false;
                    break;
                case Keys.W:
                    up = false;
                    break;
                case Keys.S:
                    down = false;
                    break;
                case Keys.ShiftKey:
                    run = false;
                    break;
            }
        }



    }
}
