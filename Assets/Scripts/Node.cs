using System;
using UnityEngine;

public struct Node
{
    public Vector2Int grid;
    public int cost;

    public Node(Vector2Int grid, int cost)
    {
        this.grid = grid;
        this.cost = cost;
    }
}