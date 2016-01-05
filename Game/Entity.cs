using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Game
{

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
        //Event delegate signature
        public delegate void EntityChanged(object sender, EventArgs args);
        //when a component is added
        public event EntityChanged ComponentAdded;
        //when a component is removed retrieve
        public event EntityChanged ComponentRemoved;
        //Identification value of components
        public int identification = 0;
        //Property used to get the identification value
        public int Identification { get { return identification; } }

        private List<IComponent> list = new List<IComponent>();


        protected virtual void OnComponentAdded()
        {
            if (ComponentAdded != null)
                ComponentAdded(this, EventArgs.Empty);
        }

        protected virtual void OnComponentRemoved()
        {
            if (ComponentAdded != null)
                ComponentAdded(this, EventArgs.Empty);
        }

        /// <summary>
        /// Add component to entity
        /// </summary>
        /// <param name="component">Component added</param>
        public void Add(IComponent component)
        {
            if (component == null) throw new NullReferenceException("Component can't be null");
            identification++;
            list.Add(component);
            OnComponentAdded();
        }

        /// <summary>
        /// Remove component from entity
        /// </summary>
        /// <param name="component">component removed</param>
        public void Remove(IComponent component)
        {
            if (identification < 0) throw new ArgumentException("Nothing to remove");
            identification--;
            list.Remove(component);
            OnComponentRemoved();

        }

        /// <summary>
        /// Replace component 1 with component 2
        /// </summary>
        /// <param name="component1">Component to replace</param>
        /// <param name="component2">Component to place</param>
        public void Replace(IComponent component1, IComponent component2)
        {
            list.Remove(component1);

            list.Add(component2);
        }


        /// <summary>
        /// Call or remove component at id
        /// </summary>
        /// <param name="index">Id value</param>
        /// <returns>Component called</returns>
        public IComponent this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = null;
            }
        }
    }

    public interface IComponent
    {

    }
}
