using Game.Entity_System;
using Game.Entity_System.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Item : Entity
    {

        public Item()
        {

        }
        public virtual void ShapeToDraw(Graphics g)
        {
            Physics itemPhysics = (Physics)list.Find(x => x.GetType() == typeof(Physics));
            double rect_ratio = 0.3;
            g.FillRectangle(Brushes.AliceBlue, new RectangleF(itemPhysics.Point,
                new SizeF((float)(itemPhysics.Size.Width * rect_ratio), (float)(itemPhysics.Size.Height * rect_ratio))));

            g.FillRectangle(Brushes.Bisque, new RectangleF(new PointF(itemPhysics.Point.X, itemPhysics.Point.Y + (float)(itemPhysics.Size.Height * rect_ratio)),
             new SizeF((float)(itemPhysics.Size.Width * rect_ratio), (float)(itemPhysics.Size.Height * rect_ratio))));
        }
    }
}
