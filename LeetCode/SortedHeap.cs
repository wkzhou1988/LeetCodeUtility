using System;
using System.Collections.Generic;
public class SortedHeap<T> where T : IComparable<T> {
    List<T> values;
    public SortedHeap() {
        values = new List<T>();
    }

    public void Push(T obj) {
        values.Add(obj);
        HeapifyUp(values.Count - 1);
    }

    public bool IsEmpty => values.Count == 0;

    public T Pop() {
        if (values.Count == 0) {
            throw new Exception("Stack is empty");
        }
        var lastIndex = values.Count - 1;
        Swap(lastIndex, 0);
        var ret = values[lastIndex];
        values.RemoveAt(lastIndex);
        HeapifyDown(0);
        return ret;
    }

    private void HeapifyUp(int index) {
        var parent = (index - 1) / 2;
        if (parent < 0) return;
        if (ShouldPopUp(index, parent)) {
            Swap(index, parent);
            HeapifyUp(parent);
        }
    }

    private void HeapifyDown(int index) {
        var left = index * 2 + 1;
        var right = index * 2 + 2;
        // in 2 chid nodes, try to pick a node to bubble up
        var bubbleUpIndex = GetBubbleUpIndex(left, right, index);
        if (bubbleUpIndex != index) {
            Swap(index, bubbleUpIndex);
            HeapifyDown(bubbleUpIndex);
        }
    }

    private int GetBubbleUpIndex(int leftIndex, int rightIndex, int parentIndex) {
        if (leftIndex < values.Count
            // child must be larger/smaller than parent to bubble up
            && values[leftIndex].CompareTo(values[parentIndex]) < 0
            // child must no smaller/no larger than the other child
            && (rightIndex >= values.Count || values[leftIndex].CompareTo(values[rightIndex]) <= 0)) {
            return leftIndex;
        }
        else if (rightIndex < values.Count
          && values[rightIndex].CompareTo(values[parentIndex]) < 0
          && (leftIndex >= values.Count || values[rightIndex].CompareTo(values[leftIndex]) <= 0)) {
            return rightIndex;
        }
        return parentIndex;
    }

    private bool ShouldPopUp(int index, int parent) {
        return values[index].CompareTo(values[parent]) < 0;
    }

    private void Swap(int x, int y) {
        var temp = values[x];
        values[x] = values[y];
        values[y] = temp;
    }
}