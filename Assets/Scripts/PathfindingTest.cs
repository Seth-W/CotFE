namespace CFE
{
    using UnityEngine;

    class PathfindingTest : MonoBehaviour
    {
        TileModel[,] graph;
        Pathfinder pathfinder;


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
            if (data.mouseData.mouse0up)
            {
                TilePosition[] waypoints = pathfinder.findPath_Heap(new TilePosition(transform.position), data.tilePos);

                for (int i = 0; i < waypoints.Length - 1; i++)
                {
                    Debug.DrawLine(waypoints[i].tilePosition, waypoints[i + 1].tilePosition, Color.red, 120f);
                }
            }
        }

        void Start()
        {
            graph = new TileModel[27, 20];
            pathfinder = new Pathfinder(graph);
        }

        void Update()
        {

        }
    }
}
