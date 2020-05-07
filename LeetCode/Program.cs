using System;
using System.Collections.Generic;

public class Solution {
    public int[] LevelOrder(TreeNode root) {
        var result = new List<int>();
        if (root == null) return result.ToArray();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            result.Add(node.val);
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
        return result.ToArray();
    }
}

class Program {
    static void Main(string[] args) {

        while (true) {
            var inputString = Console.ReadLine();
            if (inputString == "exit") break;

            try {
                var root = LeetCodeUtil.ParseTreeNode(inputString);
                var s = new Solution();
                var result = s.LevelOrder(root);
                LeetCodeUtil.Dump(result);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        Console.ReadLine();
    }
}