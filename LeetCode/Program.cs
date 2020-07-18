using Microsoft.Win32;
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

    public void Dump() {
        while (!IsEmpty) {
            Console.Write(Pop() + ", ");
        }
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
        if (left < values.Count && (right >= values.Count || ShouldPopUp(left, right)) && ShouldPopUp(left, index)) {
            Swap(left, index);
            HeapifyDown(left);
        }
        else if (right < values.Count && (left >= values.Count || ShouldPopUp(right, left)) && ShouldPopUp(right, index)) {
            Swap(right, index);
            HeapifyDown(right);
        }
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


public class Solution {
    string str1;
    string str2;
    string anim;
    int index1;
    int index2;
    bool success;

    void Trackback() {
        if (success) return;
        if (index1 + index2 == anim.Length) {
            success = true;
        } else {
            if (index1 < str1.Length && anim[index1 + index2] == str1[index1]) {
                index1++;
                Trackback();
                index1--;
            }
            if (index2 < str2.Length && anim[index1 + index2] == str2[index2]) {
                index2++;
                Trackback();
                index2--;
            }
        }
    }

    public bool IsValid(string str1, string str2, string anim) {
        this.str1 = str1;
        this.str2 = str2;
        this.anim = anim;
        Trackback();
        return success;
    }
}

class Program {
    static void Main(string[] args) {

        //while (true) {
        //    //var inputString = Console.ReadLine();
        //    //if (inputString == "exit") break;

        //    try {
        //        var str1 = Console.ReadLine();
        //        var str2 = Console.ReadLine();
        //        var anim = Console.ReadLine();
        //        var s = new Solution();
        //        var result = s.IsValid(str1, str2, anim);
        //        LeetCodeUtil.Dump(result);
        //    } catch (Exception e) {
        //        Console.WriteLine(e.Message);
        //    }
        //}
        var rand = new Random();
        var stack = new SortedHeap<int>();
        for (int i = 0; i < 10; i++) {
            var r = rand.Next(1, 100);
            stack.Push(r);
        }
        stack.Dump();
        Console.ReadLine();
    }
}