namespace CFE
{
    using UnityEngine;

    class MouseIndicatorModel : ObjectModel 
    {
        /**
        *<summary>
        *Called by an ObjectModel Componenet's setActive(true method)
        *</summary>
        */
        public override void Activate()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by an ObjectModel Componenet's setActive(true method)
        *</summary>
        */
        public override void Deactivate()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        void Update()
        {

        }
    }
}