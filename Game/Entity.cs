using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Game
{
    public delegate void EntityChanged(Entity entity, int identification, IComponent component);

    /**
    * A game entity is a collection object for components. Sometimes, the entities in a game
    * will mirror the actual characters and objects in the game, but this is not necessary.
    *
    * <p>Components are simple value objects that contain data relevant to the entity. Entities
    * with similar functionality will have instances of the same components. So we might have
    * a position component</p>
    *
    * <p>All entities that have a position in the game world, will have an instance of the
    * position component. Systems operate on entities based on the components they have.</p>
    */
    public class Entity
    {
        //when a component is added
        internal event EntityChanged ComponentAdded;
        //when a component is removed retrieve
        internal event EntityChanged ComponentRemoved;
        //Identification value
        internal static int identification = 0;

        internal int retrieveID { get { return identification; } }

        private List<IComponent> list = new List<IComponent>();

        

        public Entity()
        {
            identification++;
        }

        public void Add(IComponent component)
        {
            if (component == null) throw new NullReferenceException("Component can't be null");

            list.Add(component);
        }

        public void Remove(IComponent component)
        {
            list.Remove(component);

        }


        public IComponent this[int index]
        {
            get
            {
                return list[index];
            }
        }
    }

    public interface IComponent
    {

    }
}
