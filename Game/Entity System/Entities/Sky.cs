using Game.Entity_System;
using Game.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{
    public class Sky : Entity
    {
        //RGB increment constants
        private readonly int[,] INCREMENT_CONST = { { 16, 18, 0 }, { 38, 81, 39 }, { 13, 7, -2 } };
        //Rectangle of sky ordered from top to bottom
        protected RectangleF[] Rectangles = new RectangleF[4];
        //Sky colors ordered from top to bottom
        protected Color[] Colors = new Color[4];
        //Screen panel
        protected World screen;
        //Choice of Sky or ground for color conversion
        protected char choice;

        public Sky(Color Color, World screen)
        {
            this.screen = screen;
            this.Colors[0] = Color;
            this.choice = 's';
        }

        public void RenderSky(Color SunColor)
        {
            this.Colors[0] = SunColor;
        }

        public virtual void DrawSky(Graphics g)
        {
            //Colors for the sky
            Colors = ColorConversion();
            //Shapes for the sky bands
            Rectangles[0] = new RectangleF(0, 0, (float)screen.Width, (float)screen.Height / 4);
            Rectangles[1] = new RectangleF(0, Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 8);
            Rectangles[2] = new RectangleF(0, Rectangles[1].Height + Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 16);
            Rectangles[3] = new RectangleF(0, Rectangles[2].Height + Rectangles[1].Height + Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 16);
            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(Colors[i]), Rectangles[i]);
            }

        }



        /// <summary>
        /// Used to create the appropriate Color array for the sky or ground gradient
        /// based on the initial Color value given the World class
        /// </summary>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s'</param>
        /// <returns>Array of 4 Colors</returns>
        public Color[] ColorConversion()
        {
            Color[] colors = new Color[4];
            colors[0] = Colors[0];
            for (int i = 1; i < 4; i++)
            {
                if (colors[i - 1].R + INCREMENT_CONST[0, i - 1] <= 255)
                {
                    colors[i] = Color.FromArgb(colors[i - 1].R + INCREMENT_CONST[0, i - 1], colors[i].G, colors[i].B);

                }
                else
                {
                    colors[i] = Color.FromArgb(255, colors[i].G, colors[i].B);

                }


                if (colors[i - 1].G + INCREMENT_CONST[1, i - 1] <= 255)
                {

                    colors[i] = Color.FromArgb(colors[i].R, colors[i - 1].G + INCREMENT_CONST[1, i-1], colors[i].B);


                }
                else
                {
                    colors[i] = Color.FromArgb(colors[i].R, 255, colors[i].B);
                }


                if (colors[i - 1].B + INCREMENT_CONST[2, i - 1] <= 255)
                {
                    colors[i] = Color.FromArgb(colors[i].R, colors[i].G, colors[i - 1].B + INCREMENT_CONST[2, i - 1]);
                }
                else
                {
                    colors[i] = Color.FromArgb(colors[i].R, colors[i].G, 255);
                }
            }

            return colors;
        }
    }
}
