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
        //Rectangle of sky and ground
        private Rectangle Topp;
        private Rectangle Mid;
        private Rectangle Base1;
        private Rectangle Base2;
        //Main color based on sky
        private Color TopSkyColor { get; set; }
        //All colors derived from sky color
        private Color MidSkyColor;
        private Color Base1SkyColor;
        private Color Base2SkyColor;
        //Main color based on ground
        private Color TopGroundColor { get; set; }
        //All colors derived from ground color;
        private Color MidGroundColor;
        private Color Base1GroundColor;
        private Color Base2GroundColor;
        //Screen panel
        private Panel screen;
        
        private World(Color SkyColor, Color GroundColor, Panel screen)
        {
            if (SkyColor == null||GroundColor == null || screen == null)
            {
                throw new ArgumentException("Input values for world is not acceptable");
            }
            TopSkyColor = SkyColor;
            TopGroundColor = GroundColor;
            this.screen = screen;
        }
        public static World instantiate(Color SkyColor, Color GroundColor, Panel screen)
        {
            return new World(SkyColor, GroundColor,screen);
        }

        public void RenderWorld()
        {
            Graphics g = screen.CreateGraphics();

            g.FillRectangle(new SolidBrush(TopSkyColor), Topp);
            g.FillRectangle(new SolidBrush(MidSkyColor), Mid);
            g.FillRectangle(new SolidBrush(Base1SkyColor), Base1);
            g.FillRectangle(new SolidBrush(Base2SkyColor), Base2);

            g.FillRectangle(new SolidBrush(TopGroundColor), new Rectangle(0, screen.Height / 2, Topp.Width, Topp.Height));
            g.FillRectangle(new SolidBrush(MidGroundColor), new Rectangle(0, screen.Height / 2 + Topp.Height, Mid.Width, Mid.Height));
            g.FillRectangle(new SolidBrush(Base1GroundColor), new Rectangle(0, screen.Height / 2 + Topp.Height + Mid.Height, Base1.Width, Base1.Height));
            g.FillRectangle(new SolidBrush(Base2GroundColor), new Rectangle(0, screen.Height / 2 + Topp.Height + Mid.Height + Base1.Height, Base2.Width, Base2.Height));

            g.DrawString("" + Utility.CalculateFrameRate(),
           new Font(FontFamily.GenericSansSerif, 28, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Wheat, new PointF(0, 0));
        }

        public void UpdateWorld()
        {
            Topp = new Rectangle(0, 0, screen.Width, screen.Height / 4);
            Mid = new Rectangle(0, Topp.Height, screen.Width, screen.Height / 8);
            Base1 = new Rectangle(0, Mid.Height + Topp.Height, screen.Width, screen.Height / 16);
            Base2 = new Rectangle(0, Base1.Height + Mid.Height + Topp.Height, screen.Width, screen.Height / 16);
        }

        public void BuildWorld()
        {

            MidSkyColor = System.Drawing.ColorTranslator.FromHtml("#C61951");
            Base1SkyColor = System.Drawing.ColorTranslator.FromHtml("#741938");
            Base2SkyColor = System.Drawing.ColorTranslator.FromHtml("#56132A");

            MidGroundColor = System.Drawing.ColorTranslator.FromHtml("#66A96B");
            Base1GroundColor = System.Drawing.ColorTranslator.FromHtml("#98E19A");
            Base2GroundColor = System.Drawing.ColorTranslator.FromHtml("#C5F5C2");
        }



    }
}
