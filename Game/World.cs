using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;




namespace Game
{
    public class World
    {
        //Top sky color constant
        private readonly int TOP_SKY_COLOR_CONST = 255;
        //Top ground color constant
        private readonly int TOP_GROUND_COLOR_CONST = 65;
        //World that can only be instantiated once
        private static World world;
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

        private World(Color SkyColor, Color GroundColor, Panel screen)
        {
            if (SkyColor == null || GroundColor == null || screen == null)
            {
                throw new ArgumentException("Input values for world is not acceptable");
            }
            this.SkyColors[0] = SkyColor;
            this.GroundColor[0] = GroundColor;
            this.screen = screen;
        }

        /// <summary>
        /// Method used to allow instantiation of the World class once.
        /// </summary>
        /// <param name="SkyColor">Color of the sky</param>
        /// <param name="GroundColor">Color of ground</param>
        /// <param name="screen">The panel the world is to be drawn on</param>
        /// <returns></returns>
        public static World instantiate(Color SkyColor, Color GroundColor, Panel screen)
        {
            //Allow world to be instantiated once
            if (world != null)
            {
                world = new World(SkyColor, GroundColor, screen);
            }
            else
            {
                throw new NullReferenceException("This object can only be instantiated once");
            }
            return world;
        }

        /// <summary>
        /// Renders the shapes and colors in the World object
        /// </summary>
        public void RenderWorld()
        {
            Graphics g = screen.CreateGraphics();

            //Loop to render the world with all the shapes
            for(int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(SkyColors[i]), SkyRectangles[i]);
                g.FillRectangle(new SolidBrush(GroundColor[i]), GroundRectangles[i]);
            }
            
            //Render the frame rate
           g.DrawString("" + Utility.CalculateFrameRate(),
           new Font(FontFamily.GenericSansSerif, 28, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Wheat, new PointF(0, 0));
        }

        /// <summary>
        /// Updates position and size of the Shapes in the World object
        /// </summary>
        public void UpdateWorld()
        {
            //Shapes for the sky bands
            SkyRectangles[0] = new RectangleF(0, 0, screen.Width, screen.Height / 4);
            SkyRectangles[1] = new RectangleF(0, SkyRectangles[0].Height, screen.Width, screen.Height / 8);
            SkyRectangles[2] = new RectangleF(0, SkyRectangles[1].Height + SkyRectangles[0].Height, screen.Width, screen.Height / 16);
            SkyRectangles[3] = new RectangleF(0, SkyRectangles[2].Height + SkyRectangles[1].Height + SkyRectangles[0].Height, screen.Width, screen.Height / 16);
            //Shapes for the ground bands
            GroundRectangles[0] = new RectangleF(0, screen.Height/2, screen.Width, screen.Height / 4);
            GroundRectangles[1] = new RectangleF(0,screen.Height/2 + GroundRectangles[0].Height, screen.Width, screen.Height / 8);
            GroundRectangles[2] = new RectangleF(0, screen.Height / 2 + GroundRectangles[1].Height+ GroundRectangles[0].Height, screen.Width, screen.Height / 16);
            GroundRectangles[3] = new RectangleF(0,screen.Height/2 + GroundRectangles[2].Height + GroundRectangles[1].Height + +GroundRectangles[0].Height, screen.Width, screen.Height / 16);


        }



        /// <summary>
        /// Builds the world based on implied Colors in the World object
        /// </summary>
        public void BuildWorld()
        {
            //Colors for the sky
            SkyColors = ColorConversion(SkyColors[0],'s');
            //Colors for the ground
            GroundColor = ColorConversion(GroundColor[0], 'g');

        }


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
                colors[i] = Color.FromArgb((int)(c.R*RedValue(i + 1, chose)), (int)(c.G * GreenValue(i + 1, chose)), (int)(c.B * BlueValue(i + 1, chose)));
            }
            return colors;
        }



        /// <summary>
        /// The following functions are used to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s'</param>
        /// <returns>The R value</returns>
        private double RedValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (62.8 * Math.Pow(value, 1 / 3) + 158.9)/TOP_SKY_COLOR_CONST;
            }
            else if (chose == 'g')
            {
                return (43.4 * value + 21.5) / TOP_GROUND_COLOR_CONST;
            }
            return 0;
        }
        /// <summary>
        /// The following functions to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
        /// <returns>The R value</returns>
        private double GreenValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (1.414 * Math.Pow(-0.01118 * value - 3.548, 6) - 2809)/ TOP_SKY_COLOR_CONST;
            }
            else if (chose == 'g')
            {
                return (-1.023 * Math.Pow(-0.5101 * value + 4.109, 4) + 265.7) / TOP_GROUND_COLOR_CONST;
            }
            return 0;
        }
        /// <summary>
        /// The following functions to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
        /// <returns>The R value</returns>
        private double BlueValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (0.3583 * Math.Pow(1.306 * value - 5.073, 3) + 90.01) / TOP_SKY_COLOR_CONST;
            }
            else if (chose == 'g')
            {
                return (46.4 * value + 11.5)/ TOP_GROUND_COLOR_CONST;
            }
            return 0;
        }
    }
}
