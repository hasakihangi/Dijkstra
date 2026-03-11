using System;
using UnityEngine;

// 需要一个接口,

public struct Node
{
    public Vector2Int grid; // 这个是id..
    public long cost;

    public Node(Vector2Int grid, long cost)
    {
        this.grid = grid;
        this.cost = cost;
    }
}