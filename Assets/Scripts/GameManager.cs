using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map map;
    
    void Start()
    {
        map = new Map(4, 4);
        map[0, 0] = -1;
        map[0, 1] = -1;
        map[2, 2] = -1;
        
        Dictionary<Vector2Int, Vector2Int> cameTable = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, long> costTable = new Dictionary<Vector2Int, long>();
        
        // 测试寻路, 从(0,0) -> (3,3)
        Vector2Int from = new Vector2Int(0,0);
        DijkstraUtils.Calculate(new Vector2Int(0,0), map.board, costTable, cameTable);
        DijkstraResult result = new DijkstraResult(cameTable, costTable);

        Vector2Int to = new Vector2Int(3, 3);
        if (result.IsGridValid(to))
        {
            List<Vector2Int> path = new List<Vector2Int>();
            result.ConstructPath(to, path);
            foreach (var grid in path)
            {
                Debug.Log(grid);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
