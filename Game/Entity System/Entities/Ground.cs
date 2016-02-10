using Game.Entity_System;
using Game.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Game.Entity_System.Components;

namespace Game
{

    class Ground : Entity
    {
        private Color[] grassBlock = new Color[]{Color.FromArgb(59,95,65),
                                                 Color.FromArgb(102,169,107),
                                                 Color.FromArgb(118,216,120),
                                                 Color.FromArgb(143,236,138)};
        private World screen;
        private RectangleF[] Rectangles = new RectangleF[4];

        public Ground( World screen)
        {
            this.screen = screen;
        }
        public virtual void DrawGround(Graphics g)
        {
            //Shapes for the sky bands
            Rectangles[0] = new RectangleF(0, screen.Height/2, (float)screen.Width, (float)screen.Height / 4);
            Rectangles[1] = new RectangleF(0, screen.Height/2+ Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 8);
            Rectangles[2] = new RectangleF(0, screen.Height/2 + Rectangles[1].Height + Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 16);
            Rectangles[3] = new RectangleF(0, screen.Height/2 + Rectangles[2].Height + Rectangles[1].Height + Rectangles[0].Height, (float)screen.Width, (float)screen.Height / 16);
            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(grassBlock[i]), Rectangles[i]);
            }

        }

    }
}
