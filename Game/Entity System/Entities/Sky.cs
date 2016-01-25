using Game.Entity_System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{
    public class Sky : Entity
    {
        //Rectangle of sky ordered from top to bottom
        protected RectangleF[] Rectangles = new RectangleF[4];
        //Sky colors ordered from top to bottom
        protected Color[] Colors = new Color[4];
        //Screen panel
        protected Panel screen;

        public Sky(Color Color,Panel screen)
        {
            this.screen = screen;
            this.Colors[0] = Color;
        }

        public  void DrawSky(Graphics g)
        {
            //Colors for the sky
            Colors = ColorConversion(Colors[0], 's');
            //Shapes for the sky bands
            Rectangles[0] = new RectangleF(0, 0,(float)screen.Width, (float) screen.Height / 4);
            Rectangles[1] = new RectangleF(0, Rectangles[0].Height,(float) screen.Width, (float) screen.Height / 8);
            Rectangles[2] = new RectangleF(0, Rectangles[1].Height + Rectangles[0].Height, (float) screen.Width, (float)screen.Height / 16);
            Rectangles[3] = new RectangleF(0, Rectangles[2].Height + Rectangles[1].Height + Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 16);
            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(Colors[i]), Rectangles[i]);
            }

        }

        /// <summary>
        /// Renders the shapes and colors in the World object
        /// </summary>
        /// <param name="position">Position change in the ground</param>
        //public void RenderWorld(float position)
        //{

        //    //Colors for the ground
        //    GroundColor = ColorConversion(GroundColor[0], 'g');


        ////Shapes for the ground bands
        //GroundRectangles[0] = new RectangleF(0, screen.Height / 2, screen.Width, screen.Height / 4);
        //GroundRectangles[1] = new RectangleF(0, screen.Height / 2 + GroundRectangles[0].Height, screen.Width, screen.Height / 8);
        //GroundRectangles[2] = new RectangleF(0, screen.Height / 2 + GroundRectangles[1].Height + GroundRectangles[0].Height, screen.Width, screen.Height / 16);
        //GroundRectangles[3] = new RectangleF(0, screen.Height / 2 + GroundRectangles[2].Height + GroundRectangles[1].Height + +GroundRectangles[0].Height, screen.Width, screen.Height / 16);

        //Graphics g = screen.CreateGraphics();

        //Loop to render the world with all the shapes
        //    for (int i = 0; i < 4; i++)
        //    {
        //        g.FillRectangle(new SolidBrush(SkyColors[i]), SkyRectangles[i]);
        //        g.FillRectangle(new SolidBrush(GroundColor[i]), GroundRectangles[i]);
        //    }
        //}

        /// <summary>
        /// Used to create the appropriate Color array for the sky or ground gradient
        /// based on the initial Color value given the World class
        /// </summary>
        /// <param name="c">First color given World class</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s'</param>
        /// <returns>Array of 4 Colors</returns>
        public Color[] ColorConversion(Color c, char chose)
        {
            Color[] colors = new Color[4];
            colors[0] = c;
            for (int i = 1; i < 4; i++)
            {
                colors[i] = Color.FromArgb((int)(c.R*ColorBandTheme.RedValue(i + 1, chose)),
                    (int)(c.G * ColorBandTheme.GreenValue(i + 1, chose)), 
                    (int)(c.B * ColorBandTheme.BlueValue(i + 1, chose)));
            }
            return colors;
        }
    }
}
