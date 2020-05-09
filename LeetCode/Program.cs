using System;
using System.Collections.Generic;

public class Solution {
    int result = 0;
    int[,] maxrect;

    public int MaximalSquare(char[][] matrix) {
        if (matrix.Length == 0) return 0;
        maxrect = new int[matrix.Length, matrix[0].Length];
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[0].Length; c++) {
                if (matrix[r][c] == '0') {
                    maxrect[r, c] = 0;
                } else {
                    int up = r == 0 ? 0 : maxrect[r - 1, c];
                    int left = c == 0 ? 0 : maxrect[r, c - 1];
                    int upleft = (r == 0 || c == 0) ? 0 : maxrect[r - 1, c - 1];
                    maxrect[r, c] = Math.Min(upleft, Math.Min(up, left)) + 1;
                    result = Math.Max(result, maxrect[r, c]);
                }
            }
        }
        return result * result;
    }
}

class Program {
    static void Main(string[] args) {
        
        while (true) {
            var inputString = Console.ReadLine();
            if (inputString == "exit") break;

            try {
                var input = LeetCodeUtil.ParseArrayOfCharArrays(inputString);
                var s = new Solution();
                var result = s.MaximalSquare(input);
                LeetCodeUtil.Dump(result);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        Console.ReadLine();
    }
}