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
        //Bars on screen
        protected Rectangle Topp;
        protected Rectangle Mid;
        protected Rectangle Base1;
        protected Rectangle Base2;
        //Colors on screen
        protected Color TopSkyColor;
        protected Color MidSkyColor;
        protected Color Base1SkyColor;
        protected Color Base2SkyColor;
        protected Color TopGroundColor;
        protected Color MidGroundColor;
        protected Color Base1GroundColor;
        protected Color Base2GroundColor;

        /// <summary>
        /// Instantiate world once
        /// </summary>
        /// <param name="TopSky">Main color of top sky</param>
        /// <param name="TopGround">Main color of top ground</param>
        /// <returns></returns>
        public static World Instantiate(string TopSky, string TopGround, Panel screen)
        {
            return new World(TopSky, TopGround, screen);
        }

        private World(string TopSky, string TopGround, Panel screen)
        {
            string temp;
            while (true)
            {
                
                if (TopSky[0] != '#' || TopSky.Length != 7)
                {
                    throw new ArgumentException("This must be a Hex value");
                }
            }

        }

        private void BuildWorld(int color)
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

        private void UpdateWorld()
        {

        }

        private void RenderWorld()
        {

        }


    }
}
