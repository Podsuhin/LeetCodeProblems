using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Array.SpiralMatrixII_59
{
    public class Solution
    {
        public int[][] GenerateMatrix(int n)
        {
            var rows = new int[n][];
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new int[n];
            }

            var row = 0;
            var column = 0;
            var way = "right";
            
            for (int counter = 1; counter <= n * n; counter++)
            {
                rows[row][column] = counter;
                var (newRow, newColumn) = GetNewRowColumn(way, row, column);

                if (newRow == -1 || newRow == n
                                 || newColumn == -1 || newColumn == n
                                 || rows[row][column] != 0)
                {
                    way = GetWay(way);
                    (row, column) = GetNewRowColumn(way, row, column);
                }
                else
                {
                    row = newRow;
                    column = newColumn;
                }
            }

            return rows;
        }

        private (int, int) GetNewRowColumn(string way, int row, int column)
        {
            switch (way)
            {
                case "right":
                    return (row, column + 1);
                case "down":
                    return (row + 1, column);
                case "left":
                    return (row, column - 1);
                case "up":
                    return (row - 1, column);
                default:
                    throw new InvalidOperationException();
            }
        }

        private string GetWay(string currentWay)
        {
            switch (currentWay)
            {
                case "right":
                    return "down";
                case "down":
                    return "left";
                case "left":
                    return "up";
                case "up":
                    return "right";
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}