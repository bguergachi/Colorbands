using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Game.Entity_System.Components
{
    public delegate void DrawDelegate(Graphics g);

    public class Drawing : IComponent
    {
        private DrawDelegate drawer;
        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public DrawDelegate drawDelegate
        {
            get { return drawer; }
            set { drawer = value; }
        }

        public Drawing(DrawDelegate drawer)
        {
            this.drawer = drawer;
        }

        public Drawing(Image image)
        {
            this.image = image;
        }
    }
}
