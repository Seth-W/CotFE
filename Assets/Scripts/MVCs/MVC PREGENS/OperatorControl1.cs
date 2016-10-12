namespace CFE
{
    using UnityEngine;

    class OperatorControl1 :  MonoBehaviour, IObjectControl
    {
        /**
        *<summary>
        *Called on the first frame that a ray cast from the mouse's position on the screen no longer collides with this object
        *</summary>
        */
        public void HoverOff()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called on the frame when a ray cast from the mouse's position on the screen first collides with this object
        *</summary>
        */
        public void HoverOn()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called on the first frame that the left mouse button is pressed while a ray cast from the
        *mouse's position on the screen collides with this object
        *</summary>
        */
        public void PrimaryInputDown()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called on the first frame for the mouseclicked object that
        *-- while the left mouse button is held down-- the mousepicked object does not equal the mouseclicked object
        *</summary>
        */
        public void PrimaryInputDownRevert()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called on the first frame that the left mouse button is released after MouseDown() has been called
        *</summary>
        */
        public void PrimaryInputUp()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}
