using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Game.Entity_System;
using Game.Entity_System.Components;

namespace Game.Rendering
{

    public class World : Panel

    {

        //World that can only be instantiated once
        private static World world;
        //List of entities
        List<Entity> entities = new List<Entity>();



        public World()
        {
            this.DoubleBuffered = true;
        }

        

        public void AddEntity(Entity entity)
        {
            if (entity == null) throw new NullReferenceException("Component can't be null");
            entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            if (entities.Capacity == 0) throw new ArgumentException("Nothing to remove");
            entities.Remove(entity);
        }
        Physics entityPhysics;
        Drawing entityDrawing;

        public void RenderWorld()
        {
            Invalidate();


        }


        protected override void OnPaint(PaintEventArgs e)
        {

            foreach (Entity entity in entities)
            {
                if (entity.Paint)
                {
                    foreach (IComponent component in entity.components)
                    {
                        if (component is Physics)
                        {
                            entityPhysics = (Physics)component;
                        }
                        if (component is Drawing)
                        {
                            entityDrawing = (Drawing)component;
                            drawEntity(e.Graphics);

                        }

                    }

                }
            }
            
            e.Graphics.DrawString("" + Utility.CalculateFrameRate(),
            new Font(FontFamily.GenericSansSerif, 28, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, new PointF(0, 0));

            base.OnPaint(e);
        }

        private void drawEntity(Graphics g)
        {
            if (entityDrawing != null && entityPhysics != null)
            {


                if (entityDrawing.Image != null)
                {
                    g.DrawImage(entityDrawing.Image, entityPhysics.Point);

                }
                else if (entityDrawing.drawDelegate != null)
                {
                    entityDrawing.drawDelegate(g);
                }
            }
        }
    }
}
