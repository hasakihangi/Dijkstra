
using System.Collections.Generic;
using UnityEngine;

public struct DijkstraResult
{
    public Dictionary<Vector2Int, Vector2Int> cameTable; 
    // public Dictionary<Vector2Int, long> costTable;


    public DijkstraResult(Dictionary<Vector2Int, Vector2Int> cameTable/*, Dictionary<Vector2Int, long> costTable*/)
    {
        this.cameTable = cameTable;
        // this.costTable = costTable;
    }

    public bool IsGridValid(Vector2Int grid)
    {
        if (cameTable.ContainsKey(grid))
            return true;
        
        return false;
    }
    
    public void ConstructPath(Vector2Int to, List<Vector2Int> path)
    {
        Vector2Int current = to;
        path.Add(current);
        while (true)
        {
            if (cameTable.TryGetValue(current, out Vector2Int previous))
            {
                current = previous;
                path.Add(current);
                continue;
            }
            
            break;
        }
        path.Reverse();
    }
}