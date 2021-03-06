﻿using System;
using System.Collections.Generic;
using System.Linq;


public partial class LeetCodeUtil {
    public static TreeNode ParseTreeNode(string s) {
        if (s.Length < 2) return null;
        var splits = s.Substring(1, s.Length - 2).Split(',');
        TreeNode root = null;
        if (splits.Length > 0 && splits[0] != "null") {
            root = new TreeNode(Int32.Parse(splits[0]));
            var list = new Queue<TreeNode>();
            list.Enqueue(root);
            var index = 1;
            while (list.Count > 0) {
                if (index >= splits.Length)
                    break;

                var node = list.Dequeue();
                var value = splits[index];
                if (index < splits.Length && splits[index] != "null") {
                    node.left = new TreeNode(Int32.Parse(splits[index]));
                    list.Enqueue(node.left);
                }
                ++index;
                if (index < splits.Length && splits[index] != "null") {
                    node.right = new TreeNode(Int32.Parse(splits[index]));
                    list.Enqueue(node.right);
                }
                ++index;
            }
        }
        return root;
    }

    public static ListNode ParseListNode(string s) {
        if (s.Length == 0) return null;
        var values = s.Split(',');
        var head = new ListNode(-1);
        var ret = head;
        for (int i = 0; i < values.Length; i++) {
            var newNode = new ListNode(Int32.Parse(values[i]));
            head.next = newNode;
            head = head.next;
        }
        return ret.next;
    }

    public static int[] ParseArrayOfInt32(string s) {
        if (s.Length < 2) return new int[] { };
        s = s.Substring(1, s.Length - 2);
        return s.Split(',').Select((v) => { return Int32.Parse(v); }).ToArray();
    }

    public static IList<IList<int>> ParseListOfInt32Lists(string s) {
        var ret = new List<IList<int>>();
        if (s.Length <= 2) return ret;
        s = s.Substring(1, s.Length - 2);
        List<int> list = null;
        int value = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '[') {
                list = new List<int>();
            } else if (s[i] == ']') {
                list.Add(value);
                value = 0;
                ret.Add(list);
                list = null;
            } else if (s[i] >= '0' && s[i] <= '9') {
                value = value * 10 + (s[i] - '0');
            } else if (s[i] == ',' && list != null) {
                list.Add(value);
                value = 0;
            }
        }
        return ret;
    }

    public static Int32[][] ParseArrayOfInt32Arrays(string s) {
        var list = ParseListOfInt32Lists(s);
        var array = new Int32[list.Count][];
        for (int i = 0; i < list.Count; i++) {
            array[i] = list[i].ToArray();
        }
        return array;
    }

    public static List<string> ParseListOfStrings(string s) {
        if (s.Length < 2) return new List<string>();
        var ret = new List<string>();
        s = s.Substring(1, s.Length - 2);
        bool isInString = false;
        string tmp = "";
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '"') {
                if (isInString) {
                    ret.Add(tmp);
                    tmp = "";
                    isInString = false;
                } else {
                    isInString = true;
                }
            } else if (s[i] == ',') {
                if (isInString) {
                    tmp += s[i];
                }
            } else {
                tmp += s[i];
            }
        }
        return ret;
    }

    public static string[] ParseArrayOfStrings(string s) {
        var list = ParseListOfStrings(s);
        return list.ToArray();
    }

    public static char[][] ParseArrayOfCharArrays(string s) {
        s = s.Replace("\"", "");
        s = s.Substring(1, s.Length - 2);
        var list = new List<char[]>();
        List<char> current = null;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '[') {
                current = new List<char>();
            } else if (Char.IsDigit(s[i])) {
                current.Add(s[i]);
            } else if (s[i] == ']') {
                list.Add(current.ToArray());
            }
        }
        return list.ToArray();
    }
}