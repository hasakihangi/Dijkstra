using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<Node> heap = new List<Node>();
    public int Count => heap.Count;

    public Node PullRoot()
    {
        if (heap.Count == 0)
            throw new Exception("heap.Count == 0");
        
        Node root = heap[0];
        heap[0] = heap[heap.Count-1];
        heap.RemoveAt(heap.Count-1);
        HeapDown(0);
        return root;
    }
    
    public bool TryPullRoot(out Node node)
    {
        if (heap.Count == 0)
        {
            node = default;
            return false;
        }
        
        node = heap[0];
        heap[0] = heap[heap.Count-1];
        heap.RemoveAt(heap.Count-1);
        HeapDown(0);
        
        return true;
    }
    
    private void HeapDown(int index)
    {
        while (index < heap.Count)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int next = -1;
            
            if (left < heap.Count && heap[index].cost > heap[left].cost)
                next = left;
            
            if (right < heap.Count && heap[index].cost > heap[right].cost)
                next = right;
            
            if (next == -1)
                break;
            
            Swap(index, next);
            index = next;
        }
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

    public void Clear()
    {
        heap.Clear();
    }
}