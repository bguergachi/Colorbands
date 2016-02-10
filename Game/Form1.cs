using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.Rendering;
using Game.Entity_System;
using Game.Entity_System.Components;

namespace Game
{
    public partial class Form1 : Form
    {
        public Sun sun;
        public Player thePlayer;
        private Item item1;


        public Form1()
        {
            InitializeComponent();
            RunGame();

        }


        /// <summary>
        /// Where the components and entities are added to run the game
        /// </summary>
        public void RunGame()
        {
            //MAKE SURE TO SET PAINT TO TRUE!!!!
            //Create the player
            thePlayer = new Player(world);
            thePlayer.Add(new Physics(new PointF(10, world.Height / 2 + Properties.Resources.character.Height/3)));
            thePlayer.Add(new Drawing(Properties.Resources.character));
            thePlayer.Paint = true;

            //Create sun
            theSun = new Sun(world);
            theSun.Add(new Physics(theSun.center));
            theSun.Add(new Drawing(theSun.DrawSun));
            theSun.Paint = true;

            //Create sky
            theSky = new Sky(Color.Red, world);
            theSky.Add(new Physics(new PointF(0, 0)));
            theSky.Add(new Drawing(theSky.DrawSky));
            theSky.Paint = true;

            //Create Ground
            theGround = new Ground(world);
            theGround.Add(new Physics(new PointF(world.Width, world.Height)));
            theGround.Add(new Drawing(theGround.DrawGround));
            theGround.Paint = true;


            world.AddEntity(theSky);
            world.AddEntity(theSun);
            world.AddEntity(theGround);
            world.AddEntity(thePlayer);

            events();

        }

        private void events()
        {
            KeyDown += new KeyEventHandler(thePlayer.player_KeyPushed);
            KeyUp += new KeyEventHandler(thePlayer.player_KeyReleased);
            world.MouseWheel += new MouseEventHandler(theSun.sun_MouseWheel);
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            world.RenderWorld();
            thePlayer.Update();
            theSun.Update();
            theSky.RenderSky(theSun.HorizonColorGenerator());

        }

    }
}

