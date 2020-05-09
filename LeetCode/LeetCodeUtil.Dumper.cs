using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

delegate StringBuilder LeetCodeTypeDumpFunc(object value);

public partial class LeetCodeUtil {
    static Dictionary<Type, LeetCodeTypeDumpFunc> dumpFuncs = new Dictionary<Type, LeetCodeTypeDumpFunc> {
        { typeof (Int32[]),  DumpInt32Array },
        { typeof (List<Int32>), DumpListOfInt32 },
        { typeof (List<double>), DumpListOfDouble },
        { typeof (Int32[][]), DumpArrayOfInt32Array },
        { typeof (IList<IList<int>>), DumpListOfInt32List },
        { typeof (List<IList<int>>), DumpListOfInt32List },
        { typeof (ListNode), DumpListNode },
        { typeof (TreeNode), DumpBinaryTreeNode },
        { typeof (List<TreeNode>), DumpListOfTreeNode },
        { typeof (Int32), DumpPremitives },
        { typeof (UInt32), DumpPremitives },
        { typeof (Int64), DumpPremitives },
        { typeof (UInt64), DumpPremitives },
        { typeof (float), DumpPremitives },
        { typeof (double), DumpPremitives },
        { typeof (string), DumpPremitives },
        { typeof (Char), DumpPremitives },
        { typeof (Boolean), DumpPremitives },
        { typeof (char[]), DumpCharArray },
        { typeof (char[][]), DumpArrayOfCharArrays },
        { typeof (List<string>), DumpListOfString },
    };

    public static void Dump(object o) {
        Type t = o.GetType();
        try {
            dumpFuncs.TryGetValue(t, out LeetCodeTypeDumpFunc f);
            var sb = f(o);
            Console.WriteLine(sb);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    static StringBuilder DumpListOfString(object o) {
        List<string> list = (List<string>)o;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < list.Count; i++) {
            sb.Append(list[i]);
            if (i != list.Count - 1)
                sb.Append(',');
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpCharArray(object o) {
        char[] c = (char[])o;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < c.Length; i++) {
            sb.Append('"');
            sb.Append(c[i]);
            sb.Append('"');
            if (i != c.Length - 1)
                sb.Append(',');
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpPremitives(object o) {
        return new StringBuilder(o.ToString());
    }

    static StringBuilder DumpInt32Array(object v) {
        var array = (Int32[])v;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < array.Length; i++) {
            sb.Append(array[i]);
            if (i != array.Length - 1)
                sb.Append(",");
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpListOfInt32(object v) {
        var list = (List<Int32>)v;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < list.Count; i++) {
            sb.Append(list[i]);
            if (i != list.Count - 1)
                sb.Append(",");
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpListOfDouble(object v)
    {
        var list = (List<double>)v;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(list[i]);
            if (i != list.Count - 1)
                sb.Append(",");
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpArrayOfInt32Array(object v) {
        var array = (Int32[][])v;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < array.Length; i++) {
            sb.Append('[');
            for (int j = 0; j < array[i].Length; j++) {
                sb.Append(array[i][j]);
                if (j != array[i].Length - 1)
                    sb.Append(',');
            }
            sb.Append(']');
            if (i != array.Length - 1)
                sb.Append(",");
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpListOfInt32List(object o) {
        IList<IList<int>> list = (IList <IList<int>>)o;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < list.Count; i++) {
            sb.Append('[');
            for (int j = 0; j < list[i].Count; j++) {
                sb.Append(list[i][j].ToString());
                if (j != list[i].Count - 1)
                    sb.Append(',');
            }
            sb.Append(']');
            if (i != list.Count - 1)
                sb.Append(',');
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpListNode(object v) {
        var sb = new StringBuilder();
        var n = (ListNode)v;
        if (n == null) {
            sb.Append("null");
        } else {
            while (n != null) {
                sb.Append(n.val.ToString());
                if (n.next != null)
                    sb.Append(",");
                n = n.next;
            }
        }
        return sb;
    }

    static StringBuilder DumpBinaryTreeNode(object o) {
        var node = (TreeNode)o;
        var sb = new StringBuilder();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        sb.Append('[');
        while (queue.Count > 0) {
            var n = queue.Dequeue();
            if (n == null) sb.Append("null");
            else {
                sb.Append(n.val.ToString());
                queue.Enqueue(n.left);
                queue.Enqueue(n.right);
            }
            if (queue.Count > 0)
                sb.Append(",");
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpListOfTreeNode(object o) {
        var list = (List<TreeNode>)o;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < list.Count; i++) { 
            var s = DumpBinaryTreeNode(list[i]);
            sb.Append(s.ToString());
            if (i != list.Count - 1)
                sb.Append(',');
        }
        sb.Append(']');
        return sb;
    }

    static StringBuilder DumpArrayOfCharArrays(object o) {
        var array = (char[][])o;
        var sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < array.Length; i++) {
            sb.Append(DumpCharArray(array[i]));
            if (i != array.Length - 1) {
                sb.Append(',');
            }
        }
        sb.Append(']');
        return sb;
    }
}