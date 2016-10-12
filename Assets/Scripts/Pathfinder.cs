namespace CFE
{
    using UnityEngine;
    using System.Collections.Generic;
    using System;

    class Pathfinder
    {
        public static int width
        { get { return _width; } }
        static int _width;

        public static int height
        { get { return _height; } }
        static int _height;

        TileModel[,] modelGraph;
        PathfindingPosition[,] graph;


        public Pathfinder(TileModel[,] modelGraph)
        {
            if(width == 0 && height == 0)
            {
                _width = modelGraph.GetLength(0);
                _height = modelGraph.GetLength(1);
            }
            this.modelGraph = modelGraph;

            graph = new PathfindingPosition[width, height];
            Debug.Log(width + "," + height);
            Debug.Log(graph.GetLength(0) + "," + graph.GetLength(1));

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    graph[i, j] = new PathfindingPosition(i, j, modelGraph);
                    //Debug.Log(graph[i, j]);
                }
            }
        }

        public TilePosition[] findPath(TilePosition start, TilePosition end)
        {
            PriorityQueue<PathfindingPosition> frontier = new PriorityQueue<PathfindingPosition>();
            resetGraph();

            Debug.Log(graph.GetLength(0) + "," + graph.GetLength(1));
            Debug.Log(end.xIndex + "," + end.yIndex);
            Debug.Log(graph[0, 0]);
            Debug.Log(graph[width - 1, height - 1]);

            PathfindingPosition startPos = graph[start.xIndex, start.yIndex];
            PathfindingPosition endPos = graph[end.xIndex, end.yIndex];

            frontier.Enqueue(startPos, 0);
            PathfindingPosition workingTile = null;

            while (!frontier.isEmpty)
            {
                workingTile = frontier.Dequeue();
                workingTile.visited = true;

                if (workingTile.xIndex == end.xIndex && workingTile.yIndex == end.yIndex)
                    return backTracePath(workingTile);

                enqueueNeighbors(frontier, workingTile, endPos);
            }

            return backTracePath(workingTile);
        }

        public TilePosition[] findPath_Heap(TilePosition start, TilePosition end)
        {
            BinaryHeap_Min<PathfindingPosition> frontier = new BinaryHeap_Min<PathfindingPosition>();
            resetGraph();

            PathfindingPosition startPos = graph[start.xIndex, start.yIndex];
            PathfindingPosition endPos = graph[end.xIndex, end.yIndex];

            frontier.Enqueue(startPos, 0);
            PathfindingPosition workingTile = null;

            while (!frontier.isEmpty)
            {
                workingTile = frontier.Dequeue();
                workingTile.visited = true;

                if (workingTile.xIndex == end.xIndex && workingTile.yIndex == end.yIndex)
                    return backTracePath(workingTile);

                enqueueNeighbors(frontier, workingTile, endPos);
            }

            return backTracePath(workingTile);
        }

        /**
        *<summary>
        *Returns the <see cref="TileModel"/> which corresponds to the given <see cref="TilePosition"/>
        *</summary>
        */
        TileModel getTileModel(TilePosition pos)
        {
            return modelGraph[pos.xIndex, pos.yIndex];
        }
        
        /**
        *<summary>
        *
        *</summary>
        */
        void enqueueNeighbors(PriorityQueue<PathfindingPosition> frontier, PathfindingPosition workingTile, PathfindingPosition endTile)
        {
            PathfindingPosition nextTile;

            if (workingTile.xIndex > 0)
            {
                nextTile = graph[workingTile.xIndex - 1, workingTile.yIndex];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.xIndex < width)
            {
                nextTile = graph[workingTile.xIndex + 1, workingTile.yIndex];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.yIndex > 0)
            {
                nextTile = graph[workingTile.xIndex, workingTile.yIndex - 1];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.yIndex < height)
            {
                //Debug.Log(workingTile.xIndex + "," + workingTile.yIndex);
                //Debug.Log(workingTile.yIndex + " : " + height + " : " + graph.GetLength(1));
                Debug.Log(workingTile.yIndex + 1);
                nextTile = graph[workingTile.xIndex, workingTile.yIndex + 1];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }
        }

        /**
        *<summary>
        *
        *</summary>
        */
        void enqueueNeighbors(BinaryHeap_Min<PathfindingPosition> frontier, PathfindingPosition workingTile, PathfindingPosition endTile)
        {
            PathfindingPosition nextTile;

            if (workingTile.xIndex > 0)
            {
                nextTile = graph[workingTile.xIndex - 1, workingTile.yIndex];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.xIndex < width)
            {
                nextTile = graph[workingTile.xIndex + 1, workingTile.yIndex];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.yIndex > 0)
            {
                nextTile = graph[workingTile.xIndex, workingTile.yIndex - 1];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }

            if (workingTile.yIndex < height)
            {
                //Debug.Log(workingTile.xIndex + "," + workingTile.yIndex);
                //Debug.Log(workingTile.yIndex + " : " + height + " : " + graph.GetLength(1));
                Debug.Log(workingTile.yIndex + 1);
                nextTile = graph[workingTile.xIndex, workingTile.yIndex + 1];
                if (nextTile.pathfindingEnabled)
                {
                    int newCost = workingTile.costSoFar + 1;
                    if (!nextTile.visited || newCost < nextTile.costSoFar)
                    {
                        nextTile.cameFrom = workingTile;
                        nextTile.costSoFar = newCost;
                        int priority = newCost + heuristicDistance(nextTile, endTile);
                        frontier.Enqueue(nextTile, priority);
                    }
                }
            }
        }

        int heuristicDistance(PathfindingPosition start, PathfindingPosition end)
        {
            return Mathf.Abs((start.xIndex - end.xIndex) + (start.yIndex - end.yIndex));
        }

        TilePosition[] backTracePath(PathfindingPosition endNode)
        {
            Stack<PathfindingPosition> path = new Stack<PathfindingPosition>();
            path.Push(endNode);
            PathfindingPosition nextPos = endNode.cameFrom;
            while(nextPos != null)
            {
                path.Push(nextPos);
                nextPos = nextPos.cameFrom;
            }
            TilePosition[] retValue = new TilePosition[path.Count];
            PathfindingPosition temp;
            for (int i = 0; i < retValue.Length; i++)
            {
                temp = path.Pop();
                retValue[i] = new TilePosition(temp.xIndex, temp.yIndex);
            }
            return retValue;
        }

        void resetGraph()
        {
            if (graph.Rank != 2)
            {
                Debug.LogError("Graph was not the expected rank");
                return;
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j].reset();

                }
            }
        }

        class PathfindingPosition
        {
            public int xIndex, yIndex, costSoFar;
            public PathfindingPosition cameFrom;
            public bool visited, pathfindingEnabled;

            public PathfindingPosition(TilePosition tilePos, TileModel[,] graph)
            {
                xIndex = tilePos.xIndex;
                yIndex = tilePos.yIndex;
                cameFrom = null;
                visited = false;
                setPathfindingEnabled(graph);
            }

            public PathfindingPosition(int xIndex, int yIndex, TileModel[,] graph)
            {
                this.xIndex = xIndex;
                this.yIndex = yIndex;
                cameFrom = null;
                visited = false;
                setPathfindingEnabled(graph);
            }

            void setPathfindingEnabled(TileModel[,] graph)
            {
                pathfindingEnabled = true;
                //pathfindingEnabled = graph[xIndex, yIndex].getPathfindingEnabled();
            }

            public void reset()
            {
                cameFrom = null;
                costSoFar = 0;
                visited = false;
            }
            public override string ToString()
            {
                return xIndex.ToString() + ',' + yIndex;
            }
        }
    }
}