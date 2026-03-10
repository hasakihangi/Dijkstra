using System;
using System.Collections.Generic;

public class Heap
{
    private List<Node> heap = new List<Node>();
    public int Count => heap.Count;


    public bool TryPullRoot(out Node node)
    {
        
    }
    
    private void HeapDown(int index)
    {
        
    }
    
    private void HeapUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index-1) / 2;
            if (heap[parentIndex].cost < heap[index].cost)
                break;
            
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        Node temp = heap[index2];
        heap[index2] = heap[index1];
        heap[index1] = temp;
    }
}