using System;

public class Map
{
    public int[,] board;

    public int Width => board.GetLength(0);
    public int Height => board.GetLength(1);
    
    // 整数的10表示1(表示有一位小数)
    public Map(int width, int height)
    {
        board = new int[width,height];
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                board[i,j] = 10;
            }
        }
    }
    
    public ref int this[int x, int y]
    {
        get
        {
            return ref board[x,y];
        }
    }
}