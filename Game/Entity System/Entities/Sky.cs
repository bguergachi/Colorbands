using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{
    public class Sky
    {
        //Rectangle of sky ordered from top to bottom
        private RectangleF[] SkyRectangles = new RectangleF[4];
        // Rectangle of ground ordered from top to bottom
        private RectangleF[] GroundRectangles = new RectangleF[4];
        //Sky colors ordered from top to bottom
        private Color[] SkyColors = new Color[4];
        //Ground colors ordered from top to bottom
        private Color[] GroundColor = new Color[4];
        //Screen panel
        private Panel screen;

        /// <summary>
        /// Renders the shapes and colors in the World object
        /// </summary>
        /// <param name="position">Position change in the ground</param>
        //public void RenderWorld(float position)
        //{
        //    //Colors for the sky
        //    SkyColors = ColorConversion(SkyColors[0], 's');
        //    //Colors for the ground
        //    GroundColor = ColorConversion(GroundColor[0], 'g');

            //Shapes for the sky bands
            //SkyRectangles[0] = new RectangleF(0, 0, screen.Width, screen.Height / 4);
            //SkyRectangles[1] = new RectangleF(0, SkyRectangles[0].Height, screen.Width, screen.Height / 8);
            //SkyRectangles[2] = new RectangleF(0, SkyRectangles[1].Height + SkyRectangles[0].Height, screen.Width, screen.Height / 16);
            //SkyRectangles[3] = new RectangleF(0, SkyRectangles[2].Height + SkyRectangles[1].Height + SkyRectangles[0].Height, screen.Width, screen.Height / 16);
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

        //    //Render the frame rate
        //    g.DrawString("" + Utility.CalculateFrameRate(),
        //    new Font(FontFamily.GenericSansSerif, 28, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Wheat, new PointF(0, 0));
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
