using System;
using System.Collections.Generic;

public class MinHeap<T> where T : IComparable<T>
{
    private List<T> heap = new List<T>();
    public int Count => heap.Count;

    public void Insert(T value)
    {
        heap.Add(value);
        HeapUp(heap.Count-1);
    }
    
    public T PullRoot()
    {
        if (heap.Count == 0)
            throw new Exception("heap.Count == 0");
        
        T root = heap[0];
        heap[0] = heap[heap.Count-1];
        heap.RemoveAt(heap.Count-1);
        HeapDown(0);
        return root;
    }
    
    public bool TryPullRoot(out T value)
    {
        if (heap.Count == 0)
        {
            value = default;
            return false;
        }
        
        value = heap[0];
        heap[0] = heap[heap.Count-1];
        heap.RemoveAt(heap.Count-1);
        HeapDown(0);
        
        return true;
    }
    
    private void HeapDown(int index)
    {
        while (index < heap.Count)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int next = -1;
            
            if (leftChild < heap.Count && heap[index].CompareTo(heap[leftChild]) > 0) 
                next = leftChild;
            
            if (rightChild < heap.Count && heap[index].CompareTo(heap[rightChild]) > 0)
                next = rightChild;

            if (next != -1)
            {
                Swap(index, next);
                index = next;
                continue;
            }
            
            break;
        }
    }
    
    private void HeapUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index-1) / 2;

            if (heap[parentIndex].CompareTo(heap[index]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                continue;
            }
            
            break;
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = heap[index2];
        heap[index2] = heap[index1];
        heap[index1] = temp;
    }

    public void Clear()
    {
        heap.Clear();
    }
}