using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class TwoPointer
    {
        //11
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1,MaxWater = 0;
            while(left < right)
            {
                int min = Math.Min(height[left],height[right]);
                MaxWater = Math.Max(MaxWater, min * (right - left));
                if (height[left] < height[right]) left++;
                else right--;
            }
            return MaxWater;
        }
        //42
        public static int Trap(int[] height)
        {
            //420325  two pointer
            int n = height.Length;
            if(n == 0) return 0;
            int l = 0,r = n - 1,maxLeft = height[l],maxRight = height[r],ans = 0;
            while (l < r)
            {
                if(maxLeft < maxRight)
                {
                    l += 1;
                    maxLeft = Math.Max(maxLeft, height[l]);
                    ans += maxLeft - height[l];
                }
                else
                {
                    r -= 1;
                    maxRight = Math.Max(maxRight, height[r]);
                    ans += maxRight - height[r];
                }
            }
            return ans;
        }
        //923
        public static int ThreeSumMulti(int[] nums,int target)
        {
            //1122334455   //here we will use outer while loop in order to increase i with more than 1
            Dictionary<int,int> counter = new Dictionary<int,int>();
            foreach(int c in nums)
            {
                if(!counter.ContainsKey(c)) counter.Add(c,1);
                else counter[c]++;
            }
            Array.Sort(nums);
            int i = 0,n = nums.Length,ans = 0;
            while(i < n-2)
            {
                int j = i,k = n-1;
                while (j < k)//this loop has a run time of o(n)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > target) k--;
                    else if(sum < target) j++;
                    else
                    {
                        if (nums[i] == nums[j] && nums[j] == nums[k])
                        {
                            //math.comb(counti,3);//permutation of counti and number of elements need
                            ans += (counter[nums[i]] * (counter[nums[i]] - 1) * (counter[nums[i]] - 2))/6; // divided by permutation of 3
                        }
                        else if (nums[i] == nums[j] && nums[j] != nums[k])
                        {
                            //math.comb(counti,2);//permutation of counti and number of elements needed here 2elements are equal
                            ans += (counter[nums[i]] * (counter[nums[i]] - 1) * counter[nums[k]]) /2; //divided by permutation of 2
                        }
                        else if (nums[i] != nums[j] && nums[j] == nums[k])
                        {
                            //math.comb(counti,3);//permutation of counti and number of elements need
                            ans += (counter[nums[i]] * counter[nums[j]] * (counter[nums[j]] - 1))/2;//divided by permutation of 2
                        }
                        else   //when none of the values is equal to the other
                        {
                            ans += counter[nums[i]] * counter[nums[j]] * counter[nums[k]];
                        }
                        j += counter[nums[j]];
                        k -= counter[nums[k]];
                    }
                }
                i += counter[nums[i]];
            }
            return ans%1000000007;
        }
        //1877
        public static int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            int l = 0, r = nums.Length - 1, ans = 0;
            while(l < r)
            {
                ans = Math.Max(ans, nums[l] + nums[r]);
                l++;
                r--;
            }
            return ans;
        }
        //881
        public static int NumRescueBoats(int[] nums,int limit)
        {
            //1223
            //1111
            //there are two possibilities here,,when left+right > limit --> then decrement right
            //when left + right <= limit decrement right and increment left
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1,ans = 0;
            while(left <= right)
            {
                if (nums[left] + nums[right] <= limit)
                {
                    left++;
                    right--;
                }
                else right--;
                ans += 1;
            }
            return ans;
        }
        //633
        public static bool JudgeSquareSumTwoPointer(int c)
        {
            //here we only need to use sqrt as right pointer and zero as left pointer
            //if the square of left + right == c return true
            int sqr = (int)Math.Sqrt(c);
            int left = 0;
            int right = (int)Math.Sqrt(c);

            while(left < right)
            {
                int toCheck = left * left + right * right;
                if(toCheck == c) return true;
                if (toCheck > c) right--;
                else left--;
            }
            return false;
        }
        public static bool JudgeSquareSum(int c)
        {
            //we can use 2 pointer,hashmap or sqrt to solve the solution
            //sqrt works beacuase if the exist a^2 + b^2 = c then
            //the result we get from sqrt(c-a) will be a double and will be equal to the intiger of that value
            int sqr = (int)Math.Sqrt(c);
            for(int i = 0;i < sqr; ++i)
            {
                double b = Math.Sqrt(c - i * i);
                if(b == (int)b) return true;
            }
            return false;
        }
        //1498
        public static int NumSubSeq(int[] nums,int target)
        {
            Array.Sort(nums);
            int n  = nums.Length,ans = 0;
            int mod = 1000000007;
            int[] pow2 = new int[n];
            pow2[0] = 1;
            for (int i = 1; i < n; i++) pow2[i] = pow2[i - 1] * 2 % mod;//This helps to get all the non-empty
            //subarrays at each index or as the element count increases.

            int left = 0, right = n - 1;
            while(left <= right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    ans = (ans + pow2[right - left]) % mod;
                    left++;
                }
                else right--;
            }
            return ans;
        }
        //18
        public static IList<IList<int>> FourSumusingDictionary(int[] nums,int target)
        {
            int n = nums.Length;
            if(n < 4) return new List<IList<int>>();
            var result = new List<IList<int>>();
            Array.Sort(nums);
            var check = new Dictionary<int, int>();
            for (int i = 0; i < n; i++) check.Add(i, nums[i]);

            for(int i = 0;i < n - 3; i++)
            {
                for(int j = i + 1;j < n - 2; j++)
                {
                    for( int k = j + 1; k < n - 1; k++)
                    {
                        int toFind = target - (nums[i] + nums[j] + nums[k]);
                        if(check.ContainsValue(toFind) && check.Last(kv => kv.Value == toFind).Key > k)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[k], toFind });
                        }
                        k = check.Last(kv => kv.Value == nums[k]).Key;
                    }
                    j = check.Last(kv => kv.Value == nums[j]).Key;//this avoids same values from being used more than once
                }
                i = check.Last(kv => kv.Value == nums[i]).Key;//this have been duplicated 3 times you can use a separate method
                //to get the index of last occurrence of a value ...private static int GetIndexOfValue...
            }
            return result;
        }
        //18 4Sum
        public static IList<IList<int>> FourSum(int[] nums,int target)
        {
            //Two pointer
            IList<IList<int>> result = new List<IList<int>>();
            int n = nums.Length;
            if(n < 4) return new List<IList<int>>();
            Array.Sort(nums);

            for(int i = 0;i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for(int j = i+1;j < n - 2; j++)
                {
                    if (j != i +1 && nums[j] == nums[j - 1]) continue;
                    int left = j+1, right = n - 1;
                    while(left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if(sum == target) result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right]});
                        if(sum > target)
                        {
                            right--;
                            while(left < right && nums[right] == nums[right - 1]) right--;
                        }
                        else
                        {
                            left++;
                            while(left < right && nums[left] == nums[left - 1]) left++;
                        }
                    }
                }
            }
            return result;
        }
        //15 3Sum
        public static IList<IList<int>> ThreeSumusingDictionary(int[] nums)
        {
            //using hash map
            int n = nums.Length;
            Array.Sort(nums);
            if (n < 3) return new List<IList<int>>();
            IList<IList<int>> list = new List<IList<int>>();
            Dictionary<int,int> check = new Dictionary<int,int>();
            for(int i = 0;i < n; i++) check.Add(i, nums[i]);
            for(int i = 0;i < n - 2; i++)
            {
                if (nums[i] > 0) return list;
                //if (i > 0 && nums[i - 1] == nums[i]) continue;
                for (int j = i + 1; j < n - 1; j++)
                {
                   // if (j != i+1 && nums[j - 1] == nums[j]) continue;
                    int remaining = 0 - (nums[i] + nums[j]);
                    if(check.ContainsValue(remaining) && check.Last(kv => kv.Value == remaining).Key > j)
                    {
                        list.Add(new List<int> { nums[i], nums[j],remaining });
                    }
                    j = check.Last(kv => kv.Value == nums[j]).Key;//this checks for duplicates
                }
                i = check.Last(kv => kv.Value == nums[i]).Key;//this checks for duplicates
            }
            return list;
            //instead of using the 2 if statements we assign index i and j to the last occurrence of their previous values in the map
        }
        //15 3Sum
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //-4,-1,-1,0,1,2
            //-1,0,1,2,-1,-4
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            int n = nums.Length;
            //using two pointer
            if(n < 3) return list;
            if (nums[0] > 0) return list;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;
                if (nums[i] > 0) return list;
                int j = i + 1,k = n - 1;
                while(j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if(sum == 0) list.Add(new List<int> { nums[i], nums[j], nums[k]});
                    if(sum > 0)
                    {
                        k--;
                        while(j < k && nums[k] == nums[k+1]) k--;
                    }
                    else
                    {
                        j++;
                        while (j < k && (nums[j] == nums[j - 1])) j++;
                    }
                }
            }
            return list;
        }
        //167 Two-sum II
        public static int[] TwoSum(int[] nums,int target)
        {
            int l = 0,r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[l] + nums[r];
                if(sum == target) return new int[] {l + 1,r + 1};
                if (sum > target) r -= 1;
                else l += 1;
            }
            return new int[] {};
        }
    }
}
