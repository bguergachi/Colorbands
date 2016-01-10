using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entity_System.Components
{
    /// <summary>
    /// Location of entity based on x, y coordinates
    /// </summary>
    public class Physics : IComponent
    {
        private PointF location = new PointF();
        private Size size = new Size();
        public PointF Point
        {
            get { return location; }
            set { location = value; }
        }

        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        public Physics(float x, float y)
        {
            this.location.X = x;
            this.location.Y = y;

        }
        public Physics(PointF point)
        {
            this.location = point;
        }

        public Physics(PointF point, Size size)
        {
            this.location = point;
            this.size = size;
        }
    }
}
