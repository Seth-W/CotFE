namespace CFE
{
    using UnityEngine;

    class TileModel : ObjectModel 
    {
        bool pathfindingEnabled;
        TilePosition tilePos;

        public int xIndex
        {
            get { return tilePos.xIndex; }
        }
        public int yIndex
        {
            get { return tilePos.yIndex; }
        }

        void Start()
        {
            tilePos = new TilePosition(transform.position);
        }
        
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

        /**
        *<summary>
        *Returns whether or not this tile is passable and if pathfinding should factor check this tile
        *</summary>
        */
        public bool getPathfindingEnabled()
        {
            return pathfindingEnabled;
        }
    }
}