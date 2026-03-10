using System;

public class Map
{
    public bool[,] board;

    public int Width => board.GetLength(0);
    public int Height => board.GetLength(1);
    
    public Map(int width, int height)
    {
        board = new bool[width,height];
        // InitBoard();
    }

    // private void InitBoard()
    // {
    //     for (int j = 0; j < Width; j++) // 每行
    //     {
    //         for (int i = 0; i < Height; i++) // 每列
    //         {
    //             board[i,j] = new Cell(true, 1);
    //         }
    //     }
    // }
    //
    public ref bool this[int x, int y]
    {
        get
        {
            return ref board[x,y];
        }
    }

    // public Cell this[int x, int y]
    // {
    //     get
    //     {
    //         return board[x,y];
    //     }
    //     set
    //     {
    //         board[x,y] = value;
    //     }
    // }
}