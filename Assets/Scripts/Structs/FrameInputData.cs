namespace CFE
{
    using UnityEngine;

    struct FrameInputData
    {
        public Vector3 mousePosWorld, mousePosScreen;
        public MouseInputData mouseData;
        public TilePosition tilePos;

        public FrameInputData(Vector3 screenPosition)
        {
            mousePosScreen = screenPosition;
            mouseData = new MouseInputData("ignore this");

            mousePosWorld = Camera.main.ScreenToWorldPoint(screenPosition);
            tilePos = new TilePosition(mousePosWorld);
        }

    }
}
