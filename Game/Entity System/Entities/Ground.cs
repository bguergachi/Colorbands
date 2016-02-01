using Game.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{

    class Ground:Sky
    {
        public Ground(Color color, World screen) : base(color,screen)
        {
            this.choice = 'g';
        }


    }
}
