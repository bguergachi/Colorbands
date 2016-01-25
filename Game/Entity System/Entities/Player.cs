using Game.Entity_System;
using Game.Entity_System.Components;
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
        readonly float MOVEMENT_SPEED = 10f;
        readonly float RUN_SPEED = 20f;
        //Movement boolean
        bool right;
        bool left;
        bool up;
        bool down;
        //Allow running
        bool run;
        //Screen panel
        private Panel screen;
        //Player physics
        public Physics playerPhysics;
        //Position of character
        private PointF point;


        public float Left
        {
            get
            {
                return point.X;
            }
            set
            {
                point.X = value;
            }
        }

        public float Top
        {
            get
            {
                return point.Y;
            }
            set
            {
                point.Y = value;
            }
        }
        public Player(Panel screen)
        {
            this.screen = screen;

        }


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

        public void Movment()
        {
            playerPhysics = (Physics)list.Find(x => x.GetType() == typeof(Physics));

            if (run)
            {
                Move(RUN_SPEED);
            }
            else
            {
                Move(MOVEMENT_SPEED);
            }

          }

        private void Move(float speed)
        {

            point = playerPhysics.Point;


            if (right && !(Left >= (screen.Size.Width - playerPhysics.Size.Width)))
            {
                Left += speed;
            }
            else if (left && !(Left <= 0))
            {
                Left -= speed;
            }
            else if (up && !(Top <= 0))
            {
                Top -= speed;
            }
            else if (down && !(Top >= (screen.Size.Height - playerPhysics.Size.Height)))
            {
                Top += speed;
            }

            playerPhysics.Point = point;
        }

    }
}
