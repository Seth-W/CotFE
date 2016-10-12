namespace CFE
{
    using UnityEngine;

    struct TilePosition
    {
        public Vector3 tilePosition;
        public int xIndex, yIndex;

        public TilePosition(Vector3 worldPosition)
        {
            xIndex = Mathf.FloorToInt(worldPosition.x + 0.5f);
            yIndex = Mathf.FloorToInt(worldPosition.y + 0.5f);

            xIndex = Mathf.Clamp(xIndex, -Pathfinder.width / 2, Pathfinder.width / 2);
            yIndex = Mathf.Clamp(yIndex, -Pathfinder.height / 2, Pathfinder.height / 2);

            tilePosition = new Vector3();

            tilePosition.x = xIndex;
            tilePosition.y = yIndex;
            tilePosition.z = 0;

            xIndex += Pathfinder.width / 2;
            yIndex += Pathfinder.height / 2;

            //clampIndex();
            //Debug.Log(tilePosition);
            //Debug.Log(xIndex + "," + yIndex);

        }

        public TilePosition(int xIndex, int yIndex)
        {
            this.xIndex = xIndex;
            this.yIndex = yIndex;

            xIndex = Mathf.Clamp(xIndex, -Pathfinder.width / 2, Pathfinder.width /2);
            yIndex = Mathf.Clamp(yIndex, -Pathfinder.height / 2, Pathfinder.height / 2);

            tilePosition = new Vector3();

            tilePosition.x = xIndex - Pathfinder.width / 2;
            tilePosition.y = yIndex - Pathfinder.height / 2;
            tilePosition.z = 0;
            //clampIndex();
        }

        public override string ToString()
        {
            return xIndex + "," + yIndex;
        }

        void clampIndex()
        {
            xIndex = Mathf.Clamp(xIndex, 0, Pathfinder.width);
            yIndex = Mathf.Clamp(yIndex, 0, Pathfinder.height);

            tilePosition.x = xIndex;
            tilePosition.y = yIndex;
        }
    }
}