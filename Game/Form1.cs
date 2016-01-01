using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        readonly int MOVEMENT_SPEED = 10;
        readonly int RUN_SPEED = 20;
        bool right;
        bool left;
        bool up;
        bool down;
        bool run;
        private Rectangle Top;
        private Rectangle Mid;
        private Rectangle Base1;
        private Rectangle Base2;
        private Color TopSkyColor;
        private Color MidSkyColor;
        private Color Base1SkyColor;
        private Color Base2SkyColor;
        private Color TopGroundColor;
        private Color MidGroundColor;
        private Color Base1GroundColor;
        private Color Base2GroundColor;
        private bool done =true;

        public Form1()
        {
            InitializeComponent();
            BuildWorld();
        }

    

        private void RenderGame()
        {
            Graphics g = screen.CreateGraphics();

            g.FillRectangle(new SolidBrush(TopSkyColor), Top);
            g.FillRectangle(new SolidBrush(MidSkyColor), Mid);
            g.FillRectangle(new SolidBrush(Base1SkyColor), Base1);
            g.FillRectangle(new SolidBrush(Base2SkyColor), Base2);

            g.FillRectangle(new SolidBrush(TopGroundColor), new Rectangle(0, screen.Height / 2, Top.Width, Top.Height));
            g.FillRectangle(new SolidBrush(MidGroundColor), new Rectangle(0, screen.Height / 2 + Top.Height, Mid.Width, Mid.Height));
            g.FillRectangle(new SolidBrush(Base1GroundColor), new Rectangle(0, screen.Height / 2 + Top.Height + Mid.Height, Base1.Width, Base1.Height));
            g.FillRectangle(new SolidBrush(Base2GroundColor), new Rectangle(0, screen.Height / 2 + Top.Height + Mid.Height + Base1.Height, Base2.Width, Base2.Height));

            g.DrawString("" + Utility.CalculateFrameRate(),
           new Font(FontFamily.GenericSansSerif, 28, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Wheat, new PointF(0, 0));
        }

        private void UpdateGame()
        {
            Top = new Rectangle(0, 0, screen.Width, screen.Height / 4);
            Mid = new Rectangle(0, Top.Height, screen.Width, screen.Height / 8);
            Base1 = new Rectangle(0, Mid.Height + Top.Height, screen.Width, screen.Height / 16);
            Base2 = new Rectangle(0, Base1.Height + Mid.Height + Top.Height, screen.Width, screen.Height / 16);
        }

        private void BuildWorld()
        {

            TopSkyColor = System.Drawing.ColorTranslator.FromHtml("#F64662");
            MidSkyColor = System.Drawing.ColorTranslator.FromHtml("#C61951");
            Base1SkyColor = System.Drawing.ColorTranslator.FromHtml("#741938");
            Base2SkyColor = System.Drawing.ColorTranslator.FromHtml("#56132A");

            TopGroundColor = System.Drawing.ColorTranslator.FromHtml("#3B5F41");
            MidGroundColor = System.Drawing.ColorTranslator.FromHtml("#66A96B");
            Base1GroundColor = System.Drawing.ColorTranslator.FromHtml("#98E19A");
            Base2GroundColor = System.Drawing.ColorTranslator.FromHtml("#C5F5C2");
        }

        public void character_KeyPushed(object sender, KeyEventArgs e)
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


        public void character_KeyReleased(object sender, KeyEventArgs e)
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGame();
            RenderGame();
            if (run)
            {
                Move(RUN_SPEED);
            }
            else
            {
                Move(MOVEMENT_SPEED);
            }
        
           

        }



        private void Move(int speed)
        {
            if (right && !(character.Left >= (screen.Size.Width - character.Width)))
            {
                character.Left += speed;
            }
            else if (left && !(character.Left <= 0))
            {
                character.Left -= speed;
            }
            else if (up && !(character.Top <= 0))
            {
                character.Top -= speed;
            }
            else if (down && !(character.Top >= (screen.Size.Height - character.Height)))
            {
                character.Top += speed;
            }
        }
    }
}
