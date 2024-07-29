using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class DynamicProgramming
    {
        public static int GetMoneyAmount(int n)
        {
            int[,] dp = new int[n+1,n+1];
            int def(int left,int right)
            {
                if(left>= right) return 0;

                if (dp[left,right] != 0) return dp[left, right];

                int count = int.MaxValue;
                for(int i = left; i <= right; i++)
                {
                    count = Math.Min(count,i + Math.Max(def(left,i-1),def(i+1,right)));
                }
                dp[left, right] = count;
                return count;
            }

            return def(1, n);
        }
        public static int GetMoneyAmountDp(int n)
        {
            int[,] dp = new int[n + 1, n + 1];
            for(int i = 1; i < n; i++)
            {
                dp[i, i + 1] = i;
            }
            for(int len = 3; len <= n; len++)
            {
                for(int i = 1; i <= n - len + 1; i++)
                {
                    int count = int.MaxValue;
                    int j = len + i - 1;
                    for(int k = i; k <= j; k++)
                    {
                        count = Math.Min(count, k + Math.Max((k - 1 >= i ? dp[i, k - 1] : 0), (k + 1 <= j ? dp[k + 1, j] : 0)));
                    }
                    dp[i, j] = count;
                }
            }
            return dp[1, n];
        }
        public static int RemoveBoxesRec(int[] boxes)
        {
            int n = boxes.Length;   
            int[,,] dp = new int[n,n,n];
            int def(int l,int r,int count)
            {
                if(l>r) return 0;
                if (dp[l,r,count] != 0) return dp[l,r,count];
                while(l < r && boxes[l] == boxes[l + 1])
                {
                    l++;
                    count++;
                }
                int res = (count + 1) * (count + 1) + def(l+1,r,0);
                for(int i = l+1; i <= r; i++)
                {
                    if (boxes[l] == boxes[i])
                    {
                        res = Math.Max(res,def(i,r,count+1) + def(l+1,i-1,0));
                    }
                }
                dp[l, r, count] = res;
                return res;
            }
            return def(0,n-1,0);
        }
        public static int RemoveBoxes(int[] boxes)
        {
            Array.Sort(boxes);
            int res = 0, i = 0, n = boxes.Length;
            for (; i < n;)
            {
                int count = 1;
                while (i < n - 1 && boxes[i] == boxes[i + 1])
                {
                    count++;
                    i++;
                }
                res += count * count;
                i++;
            }
            return res;
        }
        public static int NumberOfUniqueBinaryTree(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for(int j = 1;j <= i; j++)
                {
                    dp[i] += dp[j-1] * dp[i-j];
                }
            }

            return dp[n];
        }
        public static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> st = new Stack<int>();
            int[] left = new int[n];
            int[] right = new int[n];

            for (int i = 0; i < n; i++)
            {
                while (st.Count > 0 && heights[st.Peek()] > heights[i])
                {
                    st.Pop();
                }
                left[i] = st.Count > 0 ? st.Peek() : -1;
                st.Push(i);
            }

            st.Clear();

            for (int i = n - 1; i >= 0; i--)
            {
                while (st.Count > 0 && heights[st.Peek()] >= heights[i])
                {
                    st.Pop();
                }
                right[i] = st.Count > 0 ? st.Peek() : n;
                st.Push(i);
            }

            int area = 0;
            for (int i = 0; i < n; i++)
            {
                int width = right[i] - left[i] - 1;
                int currentArea = heights[i] * width;
                area = Math.Max(area, currentArea);
            }

            return area;
        }
        public static int MctGreedy(int[] arr)
        {
            int n = arr.Length;
            int res = 0;
            while(n > 1)
            {
                int index = Array.IndexOf(arr, arr.Min());
                int minNeig= (index > 0 && index < n - 1) ? Math.Min(arr[index + 1], arr[index - 1]) : arr[index == 0 ? index + 1 : index - 1];
                res += minNeig * arr[index];
                arr = arr.Take(index).Concat(arr.Skip(index+1)).ToArray();
                n--;
            }
            return res;
        }
        public static int MctFromLeafValues(int[] arr)
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
                for (int i = 0; i + l < n ; i++)
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

