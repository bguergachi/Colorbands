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

    public class World
    {

        //World that can only be instantiated once
        private static World world;
        //Screen panel
        private Panel screen;
        //List of entities
        List<Entity> entities = new List<Entity>();



        private World(Panel screen)
        {
            if (screen == null)
            {
                throw new ArgumentException("Input values for world is not acceptable");
            }
            this.screen = screen;
        }

        /// <summary>
        /// Method used to allow instantiation of the World class once.
        /// </summary>
        /// <param name="SkyColor">Color of the sky</param>
        /// <param name="GroundColor">Color of ground</param>
        /// <param name="screen">The panel the world is to be drawn on</param>
        /// <returns></returns>
        public static World instantiate(Panel screen)
        {
            //Allow world to be instantiated once
            if (world == null)
            {
                world = new World(screen);
            }
            else
            {
                throw new NullReferenceException("This object can only be instantiated once");
            }
            return world;
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
        Physics entityLocation;
        Drawing entityDrawing;

        public void RenderWorld()
        {
            foreach (Entity entity in entities)
            {
                if (entity.Paint)
                {
                    foreach (IComponent component in entity.components)
                    {
                        if (component is Physics)
                        {
                            entityLocation = (Physics)component;
                        }
                        if (component is Drawing)
                        {
                            entityDrawing = (Drawing)component;
                        }
                    }
                    drawEntity(entityDrawing, entityLocation);
                }
            }
        }


        private void drawEntity(Drawing entityDrawing, Physics entityLocation)
        {
            if (entityDrawing != null && entityLocation != null)
            {
                Graphics g = screen.CreateGraphics();

                if (entityDrawing.Image != null)
                {
                    g.DrawImage(entityDrawing.Image, entityLocation.Point);
                }
                else if (entityDrawing.drawDelegate != null)
                {
                    entityDrawing.drawDelegate(g);
                }
            }
        }
    }
}
