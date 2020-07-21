using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

public class BinarySearchTree {
    TreeNode root;
    int size;
    public void AddNode(int value) {
        size++;
        if (root == null) {
            root = new TreeNode(value);
            return;
        }
        Insert(root, value);
    }
    public TreeNode Root => root;
    public int Size => size;

    public BinarySearchTree Duplicate() {
        var ret = new BinarySearchTree();
        var root = Copy(this.root);
        ret.root = root;
        ret.size = this.size;
        return ret;
    }

    TreeNode Copy(TreeNode node) {
        if (node == null) return node;
        var newNode = new TreeNode(node.val);
        newNode.left = Copy(node.left);
        newNode.right = Copy(node.right);
        return newNode;
    }

    void Insert(TreeNode p, int value) {
        if (value < p.val) {
            if (p.left == null) {
                p.left = new TreeNode(value);
            }
            else {
                Insert(p.left, value);
            }
        }
        else if (value > p.val) {
            if (p.right == null) {
                p.right = new TreeNode(value);
            }
            else {
                Insert(p.right, value);
            }
        }
    }
}

public class Stack {
    List<int> values = new List<int>();
    public void Push(int i) {
        values.Add(i);
    }

    public int Pop() {
        var i = values[values.Count - 1];
        values.RemoveAt(values.Count - 1);
        return i;
    }
    public bool Empty => values.Count == 0;
    public int Size => values.Count;
    public Stack Duplicate() {
        var s = new Stack();
        s.values = new List<int>(values);
        return s;
    }
    public List<int> GetList() {
        return new List<int>(values);
    }
}

public class Solution {
    List<TreeNode> MakeRoots(int low, int high) {
        var ret = new List<TreeNode>();
        if (low <= high) {
            for (int i = low; i <= high; i++) {
                var lefts = MakeRoots(low, i - 1);
                var rights = MakeRoots(i + 1, high);
                foreach (var l in lefts) {
                    foreach (var r in rights) {
                        var root = new TreeNode(i);
                        root.left = l;
                        root.right = r;
                        ret.Add(root);
                    }
                }
            }
        }
        else {
            ret.Add(null);
        }
        return ret;
    }

    public IList<TreeNode> GenerateTrees(int n) {
        if (n == 0) return new List<TreeNode>();
        return MakeRoots(1, n);
    }
}


class Program {
    static void Main(string[] args) {

        var s = new Solution();
        var r = s.GenerateTrees(3);
        LeetCodeUtil.Dump(r);

        Console.ReadLine();
    }
}