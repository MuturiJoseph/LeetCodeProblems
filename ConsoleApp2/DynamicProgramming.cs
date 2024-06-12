using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class DynamicProgramming
    {
        public stat int MctFromLeafValues(int[] arr)
        {
            int n = arr.Length;
            int[,] dp = new int[n, n];
            int[,] maxLeaf = new int[n, n];

            // Initialize the maxLeaf array
            for (int i = 0; i < n; i++)
            {
                maxLeaf[i, i] = arr[i];
                for (int j = i + 1; j < n; j++)
                {
                    maxLeaf[i, j] = Math.Max(maxLeaf[i, j - 1], arr[j]);
                }
            }

            // Fill the dp array
            for (int l = 1; l < n; l++)
            { // l is the length of the subarray
                for (int i = 0; i < n - l; i++)
                { // i is the starting index of the subarray
                    int j = i + l; // j is the ending index of the subarray
                    dp[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + maxLeaf[i, k] * maxLeaf[k + 1, j]);
                    }
                }
            }

            return dp[0, n - 1];
        }
        //public static int MctFromLeafValues(int[] arr)
        //{
        //    int n = arr.Length;
        //    Pair[,] dp = new Pair[n, n];
        //    Pair Dfs(int l, int r)
        //    {
        //        if (dp[l, r] != null) return dp[l, r];

        //        if (l == r)
        //        {
        //            dp[l, r] = new Pair(arr[l], 0);
        //            return dp[l, r];
        //        }

        //        int resSum = int.MaxValue;
        //        int resMax = int.MinValue;
        //        for (int i = l; i < r; i++)
        //        {
        //            Pair left = Dfs(l, i);
        //            Pair right = Dfs(i + 1, r);
        //            int total = left.sum + right.sum + (left.max * right.max);
        //            if (total < resSum)
        //            {
        //                resSum = total;
        //                resMax = Math.Max(left.max, right.max);
        //            }
        //        }
        //        dp[l, r] = new Pair(resMax, resSum);
        //        return dp[l, r];
        //    }
        //    return Dfs(0, n - 1).sum;
        //}
        public static int FindNumberOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] lis = new int[n];
            int[] count = new int[n];
            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
                count[i] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        if (lis[j] + 1 > lis[i])
                        {
                            lis[i] = lis[j] + 1;
                            count[i] = 0;
                        }
                        if (lis[j] + 1 == lis[i])
                        {
                            count[i] += count[j];
                        }
                    }
                }
            }
            int maxValue = lis.Max();
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                if (lis[i] == maxValue)
                {
                    ans += count[i];
                }
            }
            return ans;
        }

        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            if (obstacleGrid[m - 1][n - 1] == 1) return 0;
            int[,] result = new int[m + 1, n + 1];
            result[m, n - 1] = 1;
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (obstacleGrid[i][j] == 0)
                    {
                        if (result[i + 1, j] < 0 || result[i, j + 1] < 0)
                        {
                            result[i, j] = Math.Max(result[i + 1, j], result[i, j + 1]);
                        }
                        else if (result[i + 1, j] < 0 && result[i, j + 1] < 0)
                        {
                            result[i, j] = 0;
                        }
                        else
                        {
                            result[i, j] = result[i + 1, j] + result[i, j + 1];
                        }
                    }
                    else
                    {
                        result[i, j] = -1;
                    }
                }
            }
            return result[0, 0];
        }
    }
    public class Pair
    {
        public  int max;
        public  int sum;
        public Pair(int max, int sum)
        {
            this.max = max;
            this.sum = sum;
        }
    }
}

