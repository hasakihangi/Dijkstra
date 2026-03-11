using System;
using System.Collections.Generic;

public class IndexedMinHeap<T> where T: IComparable<T>
{
    private List<T> heap = new List<T>();
    public int Count => heap.Count;
}