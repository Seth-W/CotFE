namespace CFE
{
    using UnityEngine;

    class InputManager : MonoBehaviour
    {
        public delegate void inputData(FrameInputData data);

        public static inputData FrameInputEvent;

        void Update()
        {
            FrameInputEvent(new FrameInputData(Input.mousePosition));
        }

    }
}
