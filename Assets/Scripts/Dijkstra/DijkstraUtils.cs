using System;
using System.Collections.Generic;
using UnityEngine;


public static class DijkstraUtils
{
    private struct Direction
    {
        public Vector2Int offset;
        public int distance;

        public Direction(Vector2Int offset, int distance)
        {
            this.offset = offset;
            this.distance = distance;
        }
    }
    
    private static readonly Direction[] directions = new []
    {
        new Direction(new Vector2Int(0,-1), 1000),
        new Direction(new Vector2Int(0,1), 1000),
        new Direction(new Vector2Int(1,-1), 1414),
        new Direction(new Vector2Int(1,0), 1000),
        new Direction(new Vector2Int(1,1), 1414),
        new Direction(new Vector2Int(-1,-1), 1414),
        new Direction(new Vector2Int(-1,0), 1000),
        new Direction(new Vector2Int(-1,1), 1414),
    };
    
    private static MinHeap<Node> openSet = new MinHeap<Node>();

    public static void Calculate(Vector2Int from, int[,] board, Dictionary<Vector2Int, long> costTable,
        Dictionary<Vector2Int, Vector2Int> cameTable)
    {
        openSet.Clear();
        costTable[from] = 0;
        openSet.Insert(new Node(from, 0));
        while (openSet.Count > 0)
        {
            Node node = openSet.PullRoot();
            Vector2Int current = node.grid;
            
            if (costTable.TryGetValue(current, out long costInTable))
            {
                if (costInTable < node.cost)
                    continue;
            }

            foreach (var direction in directions)
            {
                Vector2Int neighbor = current + direction.offset;
                if (!IsGridValid(board, neighbor))
                    continue;
                int destCost = board[neighbor.x, neighbor.y];
                if (destCost < 0) // < 0 表示是障碍物
                    continue;
                
                int distance = direction.distance;
                long deltaCost = distance * destCost;
                long cost = costTable[current] + deltaCost;

                if (!costTable.ContainsKey(neighbor) || costTable[neighbor] > cost) // 如果没有记录, 或者记录的比这个值大
                {
                    costTable[neighbor] = cost;
                    cameTable[neighbor] = current;
                    openSet.Insert(new Node(neighbor, cost));
                }
            }
        }
    }

    private static bool IsGridValid<T>(T[,] board, Vector2Int grid)
    {
        if (grid.x < 0 || grid.x >= board.GetLength(0) || grid.y < 0 || grid.y >= board.GetLength(1))
            return false;
        
        return true;
    }
}