namespace CFE
{
    using UnityEngine;

    class MouseInputData
    {
        public bool mouse0up, mouse0down, mouse0, mouse1up, mouse1down, mouse1;

        public MouseInputData(string someNonsense)
        {
            mouse0 = Input.GetMouseButton(0);
            mouse0down = Input.GetMouseButtonDown(0);
            mouse0up = Input.GetMouseButtonUp(0);

            mouse1 = Input.GetMouseButton(1);
            mouse1down = Input.GetMouseButtonDown(1);
            mouse1up = Input.GetMouseButtonUp(1);
        }
    }
}
