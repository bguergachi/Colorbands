using Game.Entity_System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Rendering
{
    public class Sun : Entity
    {
        //The one sun
        private static Sun sun;
        //Screen panel
        private Panel screen;
        //Sun color
        private Color SunColor;

        public static Sun instantiate(Panel screen)
        {

            if(sun != null)
            {
                sun = new Sun(screen);
            }
            else
            {
                throw new NullReferenceException("This object can only be instantiated once");
            }
            return sun;
        }

        private Sun(Panel screen)
        {
            this.screen = screen;
        }


        //public Color HorizonColorGenerator()
        //{
        //    return null;
        //}

    }
}
