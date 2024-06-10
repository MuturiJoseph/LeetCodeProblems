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
    }
}
