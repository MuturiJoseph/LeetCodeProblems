using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class DynamicProgramming
    {
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
}
