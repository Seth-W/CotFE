namespace CFE
{
    using UnityEngine;

    /**
    *<summary>
    *Base component class for all entities that can be interacted with in a scene
    *Implements <see cref="IObjectModel"/>
    *Stores a boolean <see cref="_active"/> and 
    *A setActive method which calls Activate/Deactivate accordingly
    *</summary>
    */
    abstract class ObjectModel : MonoBehaviour, IObjectModel
    {
        bool _active;
        public bool active
        {
            get { return _active; }
            set { setActive(value); }
        }

        public abstract void Activate();
        public abstract void Deactivate();

        /**
        *<summary>
        *Called by the set method for <see cref="active"/>
        *If no change to the value the method returns
        *else it changes the value and calls the appropriate Activate/Deactivate method
        *</summary>
        */
        private void setActive(bool b)
        {
            if (_active = b)
                return;
            _active = b;
            if (b)
                Activate();
            else
                Deactivate();
        }
    }
}
