using Game.Entity_System;
using Game.Entity_System.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Game.Rendering
{
    public class Sun : Entity
    {
        private readonly int[] firstColor = { 255, 0, 0 };
        private readonly int[] lastColor = { 0, 0, 139};
        private readonly int speed = 100;


        private readonly Vector horizon;
        //The one sun
        private static Sun sun;
        //Screen panel
        private Panel screen;
        //Sun color
        private Color SunColor;
        //Vector of the center of sun to center of panel
        private Vector position;
        //Center of the sun
        public PointF center;
        //Radius of sun
        private double radius;

        public Sun(Panel screen)
        {
            this.screen = screen;
            this.radius = 100;
            center = new PointF(0, 0);
            this.horizon = new Vector(screen.Width / 2, screen.Height / 2);
        }

        public virtual void DrawSun(Graphics g)
        {
            RectangleF circle = new RectangleF();
            circle.Height = (float)radius;
            circle.Width = (float)radius;
            circle.X = center.X;
            circle.Y = center.Y;


            g.FillEllipse(SunColorGenerator(), circle);
        }

        private Brush SunColorGenerator()
        {
            return Brushes.OrangeRed;
        }

        public Color HorizonColorGenerator()
        {

            return Color.FromArgb((int)(((lastColor[0] - firstColor[0]) * t) / speed + firstColor[0]),
                                  (int)(((lastColor[1] - firstColor[1]) * t) / speed + firstColor[1]),
                                  (int)(((lastColor[2] - firstColor[2]) * t) / speed + firstColor[2]));
        }


        private double t=0;
        private double i = 0;
        private bool increment = true;
        private double theta;



        public void Update()
        {
            //Change sun position

            theta = Math.PI / speed;
            position = new Vector(screen.Width / 2 + (screen.Height/2) * Math.Cos(theta*i+Math.PI/2),
                                  screen.Height / 2 - (screen.Height/2) * Math.Sin(theta*i +Math.PI / 2));
            center.X = (float)(position.X);
            center.Y = (float)(position.Y);
            i++;
            //Increment value
            if (t == speed)increment = false;
            if (t == 0) increment = true;
            if(increment)t++;
            if (!increment) t--;

        }

        /// <summary>
        /// Event handler when scroll wheel goes up or down.
        /// </summary>
        /// <param name="sender">Object to send</param>
        /// <param name="e">Mouse argument</param>
        public void sun_MouseWheel(object sender, MouseEventArgs e)
        {
            

        }
    }
}
