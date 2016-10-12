namespace CFE
{
    using UnityEngine;

    class IndicatorView : MonoBehaviour, IObjectView 
    {
        [SerializeField, Range(-1, 1)]
        float zOffset;

        [SerializeField]
        int xIndex, yIndex;
        

        void OnEnable()
        {
            InputManager.FrameInputEvent += OnFrameInput;
        }

        void OnDisable()
        {
            InputManager.FrameInputEvent -= OnFrameInput;
        }

        void OnFrameInput(FrameInputData data)
        {
            setPosition(data.tilePos.tilePosition);
            xIndex = data.tilePos.xIndex;
            yIndex = data.tilePos.yIndex;
        }


        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public void OnActivate()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public void OnDeactivate()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse is no longer hovering over this gameObject when it previously had been
        *</summary>
        */
        public void OnHoverOff()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse hovers over this gameObject
        *</summary>
        */
        public void OnHoverOn()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks down while hovering over this gameObject
        *</summary>
        */
        public void OnPrimaryInputDown()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called on the first frame for the mouseclicked object that
        *-- while the left mouse button is held down-- 
        *the mousepicked object does not equal the mouseclicked object
        *</summary>
        */
        public void OnPrimaryInputDownRevert()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks up after left clicking down on this object
        *</summary>
        */
        public void OnPrimaryInputUp()
        {
            Debug.LogWarning("The requested method is not implemented");
        }

        /**
        *<summary>
        *Updates the position of the indicator to a given transform
        *</summary>
        */
        void setPosition(Vector3 newPos)
        {
            newPos.z = zOffset;
            transform.position = newPos;
        }
    }
}